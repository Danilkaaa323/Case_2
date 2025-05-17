namespace case_2._2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            label2 = new Label();
            Login_textBox = new TextBox();
            Password_textBox = new TextBox();
            label3 = new Label();
            label4 = new Label();
            Enter_button = new Button();
            Registr_button = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Georgia", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(72, 21);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(153, 27);
            label1.TabIndex = 0;
            label1.Text = "Авторизация";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Georgia", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(39, 75);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(52, 16);
            label2.TabIndex = 1;
            label2.Text = "Логин:";
            // 
            // Login_textBox
            // 
            Login_textBox.BorderStyle = BorderStyle.FixedSingle;
            Login_textBox.Font = new Font("Georgia", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Login_textBox.Location = new Point(43, 99);
            Login_textBox.Margin = new Padding(5);
            Login_textBox.Name = "Login_textBox";
            Login_textBox.Size = new Size(217, 25);
            Login_textBox.TabIndex = 2;
            // 
            // Password_textBox
            // 
            Password_textBox.BorderStyle = BorderStyle.FixedSingle;
            Password_textBox.Font = new Font("Georgia", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Password_textBox.Location = new Point(43, 185);
            Password_textBox.Margin = new Padding(5);
            Password_textBox.Name = "Password_textBox";
            Password_textBox.Size = new Size(217, 25);
            Password_textBox.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Georgia", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(39, 160);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(60, 16);
            label3.TabIndex = 4;
            label3.Text = "Пароль:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(107, 275);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(0, 20);
            label4.TabIndex = 5;
            // 
            // Enter_button
            // 
            Enter_button.BackColor = Color.White;
            Enter_button.FlatStyle = FlatStyle.Flat;
            Enter_button.Font = new Font("Georgia", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Enter_button.Location = new Point(97, 239);
            Enter_button.Margin = new Padding(5);
            Enter_button.Name = "Enter_button";
            Enter_button.Size = new Size(97, 37);
            Enter_button.TabIndex = 6;
            Enter_button.Text = "Войти";
            Enter_button.UseVisualStyleBackColor = false;
            Enter_button.Click += Enter_button_Click;
            // 
            // Registr_button
            // 
            Registr_button.BackColor = Color.White;
            Registr_button.FlatStyle = FlatStyle.Flat;
            Registr_button.Font = new Font("Georgia", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Registr_button.Location = new Point(55, 300);
            Registr_button.Margin = new Padding(5);
            Registr_button.Name = "Registr_button";
            Registr_button.Size = new Size(181, 45);
            Registr_button.TabIndex = 8;
            Registr_button.Text = "Зарегистрироваться";
            Registr_button.UseVisualStyleBackColor = false;
            Registr_button.Click += Registr_button_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(305, 375);
            Controls.Add(Registr_button);
            Controls.Add(Enter_button);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(Password_textBox);
            Controls.Add(Login_textBox);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Margin = new Padding(5);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Login_textBox;
        private System.Windows.Forms.TextBox Password_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Enter_button;
        private System.Windows.Forms.Button Registr_button;
    }
}
