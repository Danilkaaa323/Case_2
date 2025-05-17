using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;

namespace case_2._2
{
    public partial class ProjectsForm : Form
    {
        private readonly AppDbContext _db;
        private readonly int _userId;
        private Dictionary<string, TasksForm> openForms = new Dictionary<string, TasksForm>();
        public ProjectsForm(int userId)
        {
            InitializeComponent();
            _db = new AppDbContext();
            _userId = userId;
            Projects_listBox.SelectionMode = SelectionMode.One;
            LoadProjects();
        }
        private void LoadTasksForProject(ProjectData projectData, Project dbProject)
        {
            if (dbProject.Tasks != null && dbProject.Tasks.Any())
            {
                for (int i = 0; i < Math.Min(5, dbProject.Tasks.Count); i++)
                {
                    var task = dbProject.Tasks.ElementAt(i);
                    projectData.TaskNames[i] = task.Name;
                    projectData.TimerValues[i] = task.TimeSpent;
                    projectData.TimerStates[i] = task.IsRunning;
                }
            }
        }

        public async void LoadProjects()
        {
            Projects_listBox.Items.Clear();
            var projects = await _db.Projects.Where(p => p.UserId == _userId).ToListAsync();

            foreach (var project in projects)
            {
                Projects_listBox.Items.Add($"Проект: {project.Name}");
            }
        }
        private async void Add_button_Click(object sender, EventArgs e)
        {
            string projectName = Project_textBox.Text.Trim();

            if (string.IsNullOrEmpty(projectName))
            {
                MessageBox.Show("Введите название проекта.");
                return;
            }

            using (var db = new AppDbContext())
            {
                bool projectExists = await db.Projects.AnyAsync(p => p.Name == projectName && p.UserId == _userId);

                if (projectExists)
                {
                    MessageBox.Show($"Проект с названием \"{projectName}\" уже существует.");
                }
                else
                {
                    var project = new Project
                    {
                        Name = projectName,
                        UserId = _userId
                    };

                    await db.Projects.AddAsync(project);
                    await db.SaveChangesAsync();

                    Projects_listBox.Items.Add($"Проект: {projectName}");

                    var projectData = new ProjectData { Name = projectName };
                    TasksForm tasksForm = new TasksForm(projectData, this);
                    openForms.Add(projectName, tasksForm);
                    tasksForm.Show();
                    this.Hide();
                }
            }
        }

        private async void Edit_button_Click(object sender, EventArgs e)
        {
            if (Projects_listBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите проект для редактирования.");
                return;
            }

            string selectedItem = Projects_listBox.SelectedItem.ToString();
            string projectName = selectedItem.Replace("Проект: ", "");

            if (openForms.TryGetValue(projectName, out var form))
            {
                form.Show();
                this.Hide();
            }
            else
            {
                using (var db = new AppDbContext())
                {
                    var project = await db.Projects
                        .Include(p => p.Tasks)
                        .FirstOrDefaultAsync(p => p.Name == projectName && p.UserId == _userId);

                    if (project != null)
                    {
                        var projectData = new ProjectData { Name = project.Name };
                        LoadTasksForProject(projectData, project);

                        TasksForm tasksForm = new TasksForm(projectData, this);
                        openForms.Add(projectName, tasksForm);
                        tasksForm.Show();
                        this.Hide();
                    }
                }
            }
        }

        private async void Delete_button_Click(object sender, EventArgs e)
        {
            if (Projects_listBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите проект для удаления.");
                return;
            }

            string selectedItem = Projects_listBox.SelectedItem.ToString();
            string projectName = selectedItem.Replace("Проект: ", "");

            var projectToRemove = await _db.Projects.FirstOrDefaultAsync(p => p.Name == projectName && p.UserId == _userId);
            if (projectToRemove == null)
            {
                MessageBox.Show($"Проект \"{projectName}\" не найден.");
                return;
            }

            _db.Projects.Remove(projectToRemove);
            await _db.SaveChangesAsync();

            if (openForms.TryGetValue(projectName, out var form))
            {
                form.Close();
                openForms.Remove(projectName);
            }

            LoadProjects();
            MessageBox.Show($"Проект \"{projectName}\" успешно удалён.");
        }
        private void ProjectsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _db.Dispose();
            Application.Exit();
        }
    }
}
