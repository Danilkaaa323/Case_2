using Timer = System.Windows.Forms.Timer;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Document = iTextSharp.text.Document;
using Font = iTextSharp.text.Font;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace case_2._2
{
    public partial class TasksForm : Form
    {
        private Timer[] timers = new Timer[5];
        private readonly ProjectData project;
        private readonly ProjectsForm mainForm;
        public TasksForm(ProjectData project, ProjectsForm mainForm)
        {
            InitializeComponent();
            this.project = project;
            this.mainForm = mainForm;

            for (int i = 0; i < 5; i++)
            {
                int index = i;
                timers[i] = new Timer { Interval = 1000 };
                timers[i].Tick += (sender, e) =>
                {
                    project.TimerValues[index] = project.TimerValues[index].Add(TimeSpan.FromSeconds(1));
                    UpdateTimerLabel(index);
                };

                var textBox = Controls.Find($"textBox{i + 1}", true).FirstOrDefault() as TextBox;
                if (textBox != null)
                {
                    textBox.Enabled = false; 
                    textBox.Text = project.TaskNames[i] ?? "";
                }

                UpdateTimerLabel(i);
                if (project.TimerStates[i])
                    timers[i].Start();
            }
        }

        private void UpdateTimerLabel(int index)
        {
            var label = Controls.Find($"timer{index + 1}", true).FirstOrDefault() as Label;
            if (label != null)
                label.Text = project.TimerValues[index].ToString(@"hh\:mm\:ss");
        }

        private async void Back_button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                project.TimerStates[i] = timers[i].Enabled;
            }
            for (int i = 0; i < 5; i++)
            {
                var textBox = Controls.Find($"textBox{i + 1}", true).FirstOrDefault() as TextBox;
                if (textBox != null)
                {
                    project.TaskNames[i] = textBox.Text;
                }
            }

            using (var db = new AppDbContext())
            {
                var dbProject = await db.Projects.FirstOrDefaultAsync(p => p.Name == project.Name);
                if (dbProject != null)
                {
                    await project.SaveToDatabase(dbProject.Id, db);
                }
            }

            if (mainForm is ProjectsForm projectsForm)
            {
                projectsForm.LoadProjects();
            }

            this.Hide();
            mainForm.Show();
        }

        private void buttonStart1_Click(object sender, EventArgs e) => StartTimer(0);
        private void buttonStart2_Click(object sender, EventArgs e) => StartTimer(1);
        private void buttonStart3_Click(object sender, EventArgs e) => StartTimer(2);
        private void buttonStart4_Click(object sender, EventArgs e) => StartTimer(3);
        private void buttonStart5_Click(object sender, EventArgs e) => StartTimer(4);

        private void buttonPause1_Click(object sender, EventArgs e) => PauseTimer(0);
        private void buttonPause2_Click(object sender, EventArgs e) => PauseTimer(1);
        private void buttonPause3_Click(object sender, EventArgs e) => PauseTimer(2);
        private void buttonPause4_Click(object sender, EventArgs e) => PauseTimer(3);
        private void buttonPause5_Click(object sender, EventArgs e) => PauseTimer(4);
        private void StartTimer(int index) => timers[index].Start();
        private void PauseTimer(int index) => timers[index].Stop();
        private void TasksForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Back_button_Click(sender, e);
            }
        }

        private void buttonSaveToPdf_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                var textBox = Controls.Find($"textBox{i + 1}", true).FirstOrDefault() as TextBox;
                if (textBox != null)
                {
                    project.TaskNames[i] = textBox.Text;
                }
            }

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");

            Document doc = new Document();
            string fileName = $"{project.Name}.pdf";

            try
            {
                PdfWriter.GetInstance(doc, new FileStream(fileName, FileMode.Create));
                doc.Open();
                BaseFont baseFont;
                try
                {
                    baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                }
                catch
                {
                    baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.EMBEDDED);
                }

                Font titleFont = new Font(baseFont, 16, iTextSharp.text.Font.BOLD);
                Font taskFont = new Font(baseFont, 12, iTextSharp.text.Font.NORMAL);
                Font totalFont = new Font(baseFont, 14, iTextSharp.text.Font.BOLD);
                Font priceFont = new Font(baseFont, 14, iTextSharp.text.Font.BOLD);

                doc.Add(new Paragraph("Проект: " + project.Name, titleFont));
                doc.Add(Chunk.NEWLINE);
                doc.Add(new Paragraph("Задачи:", taskFont));

                int taskNumber = 1;
                for (int i = 0; i < 5; i++)
                {
                    string taskName = project.TaskNames[i] ?? "";
                    TimeSpan taskTime = project.TimerValues[i];

                    if (!string.IsNullOrWhiteSpace(taskName) || taskTime > TimeSpan.Zero)
                    {
                        string displayName = string.IsNullOrWhiteSpace(taskName) ? "Без названия" : taskName;
                        doc.Add(new Paragraph($"{taskNumber}) {displayName}: {taskTime.ToString(@"hh\:mm\:ss")}", taskFont));
                        taskNumber++;
                    }
                }
                doc.Add(Chunk.NEWLINE);
                TimeSpan totalTime = project.TimerValues.Aggregate(TimeSpan.Zero, (sum, val) => sum + val);
                doc.Add(new Paragraph($"Всего потрачено времени: {totalTime.ToString(@"hh\:mm\:ss")}", totalFont));

                decimal totalHours = (decimal)totalTime.TotalHours;
                decimal price = totalHours * 1000m;
                string priceText = $"Итоговая цена: {price.ToString("N0")} руб";
                doc.Add(new Paragraph(priceText, priceFont));

                MessageBox.Show($"Отчет сохранен как {fileName}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании PDF: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                doc.Close();
            }
        }

        private void edit_button1_Click(object sender, EventArgs e) => EnableTextBoxForEditing(0);
        private void edit_button2_Click(object sender, EventArgs e) => EnableTextBoxForEditing(1);
        private void edit_button3_Click(object sender, EventArgs e) => EnableTextBoxForEditing(2);
        private void edit_button4_Click(object sender, EventArgs e) => EnableTextBoxForEditing(3);
        private void edit_button5_Click(object sender, EventArgs e) => EnableTextBoxForEditing(4);

        private void save_button1_Click(object sender, EventArgs e) => SaveAndDisableTextBox(0);
        private void save_button2_Click(object sender, EventArgs e) => SaveAndDisableTextBox(1);
        private void save_button3_Click(object sender, EventArgs e) => SaveAndDisableTextBox(2);
        private void save_button4_Click(object sender, EventArgs e) => SaveAndDisableTextBox(3);
        private void save_button5_Click(object sender, EventArgs e) => SaveAndDisableTextBox(4);
        private void EnableTextBoxForEditing(int index)
        {
            for (int i = 0; i < 5; i++)
            {
                var tb = Controls.Find($"textBox{i + 1}", true).FirstOrDefault() as TextBox;
                if (tb != null) tb.Enabled = false;
            }

            var textBox = Controls.Find($"textBox{index + 1}", true).FirstOrDefault() as TextBox;
            if (textBox != null)
            {
                textBox.Enabled = true;
                textBox.Focus();
            }
        }
        private void SaveAndDisableTextBox(int index)
        {
            var textBox = Controls.Find($"textBox{index + 1}", true).FirstOrDefault() as TextBox;
            if (textBox != null)
            {
                project.TaskNames[index] = textBox.Text; 
                textBox.Enabled = false; 
            }
        }

        private void buttonSaveToCsv_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                var textBox = Controls.Find($"textBox{i + 1}", true).FirstOrDefault() as TextBox;
                if (textBox != null)
                {
                    project.TaskNames[i] = textBox.Text;
                }
            }

            string fileName = $"{project.Name}.csv";

            using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                writer.WriteLine("Номер;Задача;Время;Стоимость (руб)");

                int taskNumber = 1;
                for (int i = 0; i < 5; i++)
                {
                    string taskName = project.TaskNames[i] ?? "";
                    TimeSpan taskTime = project.TimerValues[i];

                    if (!string.IsNullOrWhiteSpace(taskName) || taskTime > TimeSpan.Zero)
                    {
                        string displayName = string.IsNullOrWhiteSpace(taskName) ? "Без названия" : taskName;

                        decimal taskHours = (decimal)taskTime.TotalHours;
                        decimal taskCost = taskHours * 1000m;

                        writer.WriteLine($"{taskNumber};" +
                                        $"\"{displayName}\";" +
                                        $"{taskTime.ToString(@"hh\:mm\:ss")};" +
                                        $"{taskCost:N0}");
                        taskNumber++;
                    }
                }

                TimeSpan totalTime = project.TimerValues.Aggregate(TimeSpan.Zero, (sum, val) => sum + val);
                decimal totalHours = (decimal)totalTime.TotalHours;
                decimal totalCost = totalHours * 1000m;

                writer.WriteLine($"Итого;;" +
                               $"{totalTime.ToString(@"hh\:mm\:ss")};" +
                               $"{totalCost:N0}");
            }

            MessageBox.Show($"Отчет сохранен как {fileName}");
        }
    }
}
