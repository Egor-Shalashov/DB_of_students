using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_of_students.Forms
{
    public partial class Progress_update : Form
    {
        private int gl_id_student;
        private int gl_id_teacher;
        private int gl_id_theme;
        private string gl_date;
        private string gl_grade;

        public Progress_update(int id_student, int id_teacher, int id_theme, string date, string grade)
        {
            InitializeComponent();
            gl_id_student = id_student;
            gl_id_teacher = id_teacher;
            gl_id_theme = id_theme;
            gl_date = date;
            gl_grade = grade;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(Modules.DB_Conn.str_conn))
            {
                conn.Open();
                string sql = "UPDATE [Колледж].[Успеваемость] " +
                             "SET [Оценка]=@Grade" +
                             " WHERE [Зачетная_книжка] = @Id_s and [Номер_преподавателя] = @Id_theacher and [Номер_предмета] = @Id_theme and [Дата] = @Date and [Оценка] = @Grade";

                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("Id_s", gl_id_student);
                comm.Parameters.AddWithValue("Id_theacher", gl_id_teacher);
                comm.Parameters.AddWithValue("Id_theme", gl_id_theme);
                comm.Parameters.AddWithValue("Date", gl_date);
                comm.Parameters.AddWithValue("Grade", gl_grade);
                comm.ExecuteNonQuery();
                MessageBox.Show("Обновлено");
            }
            Close();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
