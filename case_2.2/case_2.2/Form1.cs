using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace case_2._2
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Enter_button_Click(object sender, EventArgs e)
        {
            using (var db = new AppDbContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Login == Login_textBox.Text && u.Password == Password_textBox.Text);

                if (user != null)
                {
                    ProjectsForm projectsForm = new ProjectsForm(user.Id);
                    projectsForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Такого пользователя не существует");
                }
            }
        }

        private void Registr_button_Click(object sender, EventArgs e)
        {
            RegistrForm form2 = new RegistrForm();
            form2.Show();
            this.Hide();
        }
    }
}
