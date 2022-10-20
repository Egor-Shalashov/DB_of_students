namespace DB_of_students.Forms
{
    partial class Admin
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_add_teacher = new System.Windows.Forms.Button();
            this.DGV_Teacher = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btn_add_theme = new System.Windows.Forms.Button();
            this.DGV_Theme = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_add_student = new System.Windows.Forms.Button();
            this.DGV_Student = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.btn_add_user = new System.Windows.Forms.Button();
            this.DGV_User = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Teacher)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Theme)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Student)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_User)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(12, 70);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 368);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_add_teacher);
            this.tabPage2.Controls.Add(this.DGV_Teacher);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(768, 342);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Преподаватели";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_add_teacher
            // 
            this.btn_add_teacher.Location = new System.Drawing.Point(687, 313);
            this.btn_add_teacher.Name = "btn_add_teacher";
            this.btn_add_teacher.Size = new System.Drawing.Size(75, 23);
            this.btn_add_teacher.TabIndex = 1;
            this.btn_add_teacher.Text = "Добавить";
            this.btn_add_teacher.UseVisualStyleBackColor = true;
            this.btn_add_teacher.Click += new System.EventHandler(this.btn_add_teacher_Click);
            // 
            // DGV_Teacher
            // 
            this.DGV_Teacher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Teacher.Location = new System.Drawing.Point(6, 6);
            this.DGV_Teacher.Name = "DGV_Teacher";
            this.DGV_Teacher.Size = new System.Drawing.Size(756, 301);
            this.DGV_Teacher.TabIndex = 0;
            this.DGV_Teacher.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Teacher_CellClick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btn_add_theme);
            this.tabPage3.Controls.Add(this.DGV_Theme);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(768, 342);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Предметы";
            // 
            // btn_add_theme
            // 
            this.btn_add_theme.Location = new System.Drawing.Point(687, 313);
            this.btn_add_theme.Name = "btn_add_theme";
            this.btn_add_theme.Size = new System.Drawing.Size(75, 23);
            this.btn_add_theme.TabIndex = 3;
            this.btn_add_theme.Text = "Добавить";
            this.btn_add_theme.UseVisualStyleBackColor = true;
            this.btn_add_theme.Click += new System.EventHandler(this.btn_add_theme_Click);
            // 
            // DGV_Theme
            // 
            this.DGV_Theme.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Theme.Location = new System.Drawing.Point(6, 6);
            this.DGV_Theme.Name = "DGV_Theme";
            this.DGV_Theme.Size = new System.Drawing.Size(756, 301);
            this.DGV_Theme.TabIndex = 2;
            this.DGV_Theme.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Theme_CellClick);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btn_add_student);
            this.tabPage1.Controls.Add(this.DGV_Student);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 342);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Студенты";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_add_student
            // 
            this.btn_add_student.Location = new System.Drawing.Point(687, 313);
            this.btn_add_student.Name = "btn_add_student";
            this.btn_add_student.Size = new System.Drawing.Size(75, 23);
            this.btn_add_student.TabIndex = 5;
            this.btn_add_student.Text = "Добавить";
            this.btn_add_student.UseVisualStyleBackColor = true;
            this.btn_add_student.Click += new System.EventHandler(this.btn_add_student_Click);
            // 
            // DGV_Student
            // 
            this.DGV_Student.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Student.Location = new System.Drawing.Point(6, 6);
            this.DGV_Student.Name = "DGV_Student";
            this.DGV_Student.Size = new System.Drawing.Size(756, 301);
            this.DGV_Student.TabIndex = 4;
            this.DGV_Student.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Student_CellClick);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.DGV);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(768, 342);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Успеваемость";
            // 
            // DGV
            // 
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(6, 6);
            this.DGV.Name = "DGV";
            this.DGV.Size = new System.Drawing.Size(756, 301);
            this.DGV.TabIndex = 4;
            this.DGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellClick);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.btn_add_user);
            this.tabPage5.Controls.Add(this.DGV_User);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(768, 342);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "Пользователи";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // btn_add_user
            // 
            this.btn_add_user.Location = new System.Drawing.Point(687, 313);
            this.btn_add_user.Name = "btn_add_user";
            this.btn_add_user.Size = new System.Drawing.Size(75, 23);
            this.btn_add_user.TabIndex = 5;
            this.btn_add_user.Text = "Добавить";
            this.btn_add_user.UseVisualStyleBackColor = true;
            this.btn_add_user.Click += new System.EventHandler(this.btn_add_user_Click);
            // 
            // DGV_User
            // 
            this.DGV_User.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_User.Location = new System.Drawing.Point(6, 6);
            this.DGV_User.Name = "DGV_User";
            this.DGV_User.Size = new System.Drawing.Size(756, 301);
            this.DGV_User.TabIndex = 4;
            this.DGV_User.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_User_CellClick);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "Admin";
            this.Text = "Администратор";
            this.Load += new System.EventHandler(this.Admin_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Teacher)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Theme)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Student)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_User)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView DGV_Teacher;
        private System.Windows.Forms.Button btn_add_teacher;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button btn_add_theme;
        private System.Windows.Forms.DataGridView DGV_Theme;
        private System.Windows.Forms.Button btn_add_student;
        private System.Windows.Forms.DataGridView DGV_Student;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Button btn_add_user;
        private System.Windows.Forms.DataGridView DGV_User;
    }
}