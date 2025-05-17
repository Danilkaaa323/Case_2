namespace case_2._2
{
    partial class ProjectsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectsForm));
            Add_button = new Button();
            Delete_button = new Button();
            Edit_button = new Button();
            Project_textBox = new TextBox();
            label = new Label();
            Projects_listBox = new ListBox();
            SuspendLayout();
            // 
            // Add_button
            // 
            Add_button.BackColor = Color.White;
            Add_button.FlatStyle = FlatStyle.Flat;
            Add_button.Font = new Font("Georgia", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Add_button.Location = new Point(13, 251);
            Add_button.Margin = new Padding(5);
            Add_button.Name = "Add_button";
            Add_button.Size = new Size(136, 33);
            Add_button.TabIndex = 1;
            Add_button.Text = "Добавить";
            Add_button.UseVisualStyleBackColor = false;
            Add_button.Click += Add_button_Click;
            // 
            // Delete_button
            // 
            Delete_button.BackColor = Color.White;
            Delete_button.FlatStyle = FlatStyle.Flat;
            Delete_button.Font = new Font("Georgia", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Delete_button.Location = new Point(301, 251);
            Delete_button.Margin = new Padding(5);
            Delete_button.Name = "Delete_button";
            Delete_button.Size = new Size(136, 33);
            Delete_button.TabIndex = 2;
            Delete_button.Text = "Удалить";
            Delete_button.UseVisualStyleBackColor = false;
            Delete_button.Click += Delete_button_Click;
            // 
            // Edit_button
            // 
            Edit_button.BackColor = Color.White;
            Edit_button.FlatStyle = FlatStyle.Flat;
            Edit_button.Font = new Font("Georgia", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Edit_button.Location = new Point(157, 251);
            Edit_button.Margin = new Padding(5);
            Edit_button.Name = "Edit_button";
            Edit_button.Size = new Size(136, 33);
            Edit_button.TabIndex = 3;
            Edit_button.Text = "Редактировать";
            Edit_button.UseVisualStyleBackColor = false;
            Edit_button.Click += Edit_button_Click;
            // 
            // Project_textBox
            // 
            Project_textBox.BorderStyle = BorderStyle.FixedSingle;
            Project_textBox.Font = new Font("Georgia", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Project_textBox.Location = new Point(184, 208);
            Project_textBox.Margin = new Padding(5);
            Project_textBox.Name = "Project_textBox";
            Project_textBox.Size = new Size(253, 25);
            Project_textBox.TabIndex = 5;
            // 
            // label
            // 
            label.AutoSize = true;
            label.BackColor = Color.Transparent;
            label.Font = new Font("Georgia", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label.Location = new Point(13, 209);
            label.Margin = new Padding(5, 0, 5, 0);
            label.Name = "label";
            label.Size = new Size(169, 21);
            label.TabIndex = 6;
            label.Text = "Название проекта:";
            // 
            // Projects_listBox
            // 
            Projects_listBox.Font = new Font("Georgia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Projects_listBox.FormattingEnabled = true;
            Projects_listBox.Location = new Point(13, 12);
            Projects_listBox.Name = "Projects_listBox";
            Projects_listBox.Size = new Size(424, 184);
            Projects_listBox.TabIndex = 7;
            // 
            // ProjectsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(456, 301);
            Controls.Add(Projects_listBox);
            Controls.Add(label);
            Controls.Add(Project_textBox);
            Controls.Add(Edit_button);
            Controls.Add(Delete_button);
            Controls.Add(Add_button);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Margin = new Padding(5);
            Name = "ProjectsForm";
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button Add_button;
        private System.Windows.Forms.Button Delete_button;
        private System.Windows.Forms.TextBox Project_textBox;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button Edit_button;
        private ListBox Projects_listBox;
    }
}