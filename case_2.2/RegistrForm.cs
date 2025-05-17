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

namespace case_2._2
{
    public partial class RegistrForm : Form
    {
        public RegistrForm()
        {
            InitializeComponent();
        }

        private async void Registr_button_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Login_textBox.Text) || string.IsNullOrWhiteSpace(Password_textBox.Text))
            {
                MessageBox.Show("Поле не может быть пустым");
                return;
            }

            using (var db = new AppDbContext())
            {
                if (await db.Users.AnyAsync(u => u.Login == Login_textBox.Text))
                {
                    MessageBox.Show("Такой логин уже существует");
                    return;
                }
                var newUser = new User
                {
                    Login = Login_textBox.Text,
                    Password = Password_textBox.Text
                };

                db.Users.Add(newUser);
                await db.SaveChangesAsync();
                MessageBox.Show("Регистрация успешна!");

                var form1 = Application.OpenForms.OfType<Form1>().FirstOrDefault();
                form1?.Show();
                this.Close();
            }
        }
    }
}
