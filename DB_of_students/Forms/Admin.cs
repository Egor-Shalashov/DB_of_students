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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            PopulateGridTeacher();
            PopulateGridTheme();
            PopulateGridUser();
            PopulateGridStudent();
            PopulateGrid();
            DataGridViewButtonColumn theme = new DataGridViewButtonColumn
            {
                Name = "Theme",
                Text = "Предметы",
                HeaderText = "Предметы",
                UseColumnTextForButtonValue = true
            };
            DGV_Teacher.Columns.Add(theme);
            DataGridViewButtonColumn update_teacher = new DataGridViewButtonColumn
            {
                Name = "update_teacher",
                Text = "Обновить",
                HeaderText = "Обновить",
                UseColumnTextForButtonValue = true
            };
            DataGridViewButtonColumn update_theme = new DataGridViewButtonColumn
            {
                Name = "update_theme",
                Text = "Обновить",
                HeaderText = "Обновить",
                UseColumnTextForButtonValue = true
            };
            DataGridViewButtonColumn update_user = new DataGridViewButtonColumn
            {
                Name = "update_user",
                Text = "Обновить",
                HeaderText = "Обновить",
                UseColumnTextForButtonValue = true
            };
            DataGridViewButtonColumn update_student = new DataGridViewButtonColumn
            {
                Name = "update_student",
                Text = "Обновить",
                HeaderText = "Обновить",
                UseColumnTextForButtonValue = true
            };
            DataGridViewButtonColumn update = new DataGridViewButtonColumn
            {
                Name = "update",
                Text = "Обновить",
                HeaderText = "Обновить",
                UseColumnTextForButtonValue = true
            };
            DGV_Teacher.Columns.Add(update_teacher);
            DGV_Theme.Columns.Add(update_theme);
            DGV_User.Columns.Add(update_user);
            DGV_Student.Columns.Add(update_student);
            DGV.Columns.Add(update);
            DataGridViewButtonColumn delete_teacher = new DataGridViewButtonColumn
            {
                Name = "delete_teacher",
                Text = "Удалить",
                HeaderText = "Удалить",
                UseColumnTextForButtonValue = true
            };
            DataGridViewButtonColumn delete_theme = new DataGridViewButtonColumn
            {
                Name = "delete_theme",
                Text = "Удалить",
                HeaderText = "Удалить",
                UseColumnTextForButtonValue = true
            };
            DataGridViewButtonColumn delete_user = new DataGridViewButtonColumn
            {
                Name = "delete_user",
                Text = "Удалить",
                HeaderText = "Удалить",
                UseColumnTextForButtonValue = true
            };
            DataGridViewButtonColumn delete_student = new DataGridViewButtonColumn
            {
                Name = "delete_student",
                Text = "Удалить",
                HeaderText = "Удалить",
                UseColumnTextForButtonValue = true
            };
            DataGridViewButtonColumn delete = new DataGridViewButtonColumn
            {
                Name = "delete",
                Text = "Удалить",
                HeaderText = "Удалить",
                UseColumnTextForButtonValue = true
            };
            DGV_Teacher.Columns.Add(delete_teacher);
            DGV_Theme.Columns.Add(delete_theme);
            DGV_User.Columns.Add(delete_user);
            DGV_Student.Columns.Add(delete_student);
            DGV.Columns.Add(delete);
        }

        private void PopulateGridTeacher()
        {
            using (SqlConnection conn = new SqlConnection(Modules.DB_Conn.str_conn))
            {
                conn.Open();
                string sql = "SELECT * FROM [Колледж].[Преподаватель]";
                SqlDataAdapter ada = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                ada.Fill(ds);
                DGV_Teacher.DataSource = ds.Tables[0];
            }
        }

        private void PopulateGridTheme()
        {
            using (SqlConnection conn = new SqlConnection(Modules.DB_Conn.str_conn))
            {
                conn.Open();
                string sql = "SELECT * FROM [Колледж].[Предмет]";
                SqlDataAdapter ada = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                ada.Fill(ds);
                DGV_Theme.DataSource = ds.Tables[0];
            }
        }

        private void PopulateGridUser()
        {
            using (SqlConnection conn = new SqlConnection(Modules.DB_Conn.str_conn))
            {
                conn.Open();
                string sql = "SELECT [Номер_пользователя], [Логин], [Роль] FROM [Колледж].[Пользователь]";
                SqlDataAdapter ada = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                ada.Fill(ds);
                DGV_User.DataSource = ds.Tables[0];
            }
        }

        private void PopulateGridStudent()
        {
            using (SqlConnection conn = new SqlConnection(Modules.DB_Conn.str_conn))
            {
                conn.Open();
                string sql = "SELECT * FROM [Колледж].[Студент]";
                SqlDataAdapter ada = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                ada.Fill(ds);
                DGV_Student.DataSource = ds.Tables[0];
            }
        }

        private void PopulateGrid()
        {
            using (SqlConnection conn = new SqlConnection(Modules.DB_Conn.str_conn))
            {
                conn.Open();
                string sql = "SELECT [Колледж].[Студент].[ФИО] as 'ФИО студента', [Колледж].[Предмет].[Название_предмета] as 'Название предмета', [Дата], [Колледж].[Преподаватель].[ФИО] as 'ФИО преподавателя', [Оценка]  FROM [Колледж].[Успеваемость]"
                    + "inner join [Колледж].[Преподаватель] on [Колледж].[Успеваемость].[Номер_преподавателя] = [Колледж].[Преподаватель].[Номер_преподавателя]"
                    + "inner join [Колледж].[Предмет] on [Колледж].[Успеваемость].[Номер_предмета] = [Колледж].[Предмет].[Номер_предмета]"
                    + "inner join[Колледж].[Студент] on[Колледж].[Успеваемость].[Зачетная_книжка] = [Колледж].[Студент].[Зачетная_книжка]";
                SqlDataAdapter ada = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                ada.Fill(ds);
                DGV.DataSource = ds.Tables[0];
            }
        }

        private void btn_add_teacher_Click(object sender, EventArgs e)
        {
            Teacher_add_update teacherAdd = new Teacher_add_update(0, false);
            teacherAdd.ShowDialog();
            PopulateGridTeacher();
        }

        private void DGV_Teacher_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGV_Teacher.Columns["update_teacher"].Index)
            {
                Teacher_add_update teacherUpdate = new Teacher_add_update(Convert.ToInt32(DGV_Teacher.CurrentRow.Cells[3].Value.ToString()), true);
                teacherUpdate.ShowDialog();
                PopulateGridTeacher();

            }
            if (e.ColumnIndex == DGV_Teacher.Columns["delete_teacher"].Index)
            {
                int Id = Convert.ToInt32(DGV_Teacher.CurrentRow.Cells[3].Value.ToString());
                if (MessageBox.Show("Вы уверены?", "Вопрос", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(Modules.DB_Conn.str_conn))
                    {
                        conn.Open();
                        string sql = "DELETE FROM [Колледж].[Преподаватель] WHERE [Номер_преподавателя]=@Id";
                        SqlCommand comm = new SqlCommand(sql, conn);
                        comm.Parameters.AddWithValue("Id", Id);
                        try
                        {
                            comm.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    MessageBox.Show("Удалено");
                    PopulateGridTeacher();
                }
            }
            if (e.ColumnIndex == DGV_Teacher.Columns["Theme"].Index)
            {
                Teacher_theme teacherUpdate = new Teacher_theme(Convert.ToInt32(DGV_Teacher.CurrentRow.Cells[3].Value.ToString()));
                teacherUpdate.ShowDialog();
                PopulateGridTeacher();

            }
        }

        private void btn_add_theme_Click(object sender, EventArgs e)
        {
            Theme_add_update themeAdd = new Theme_add_update(0, false);
            themeAdd.ShowDialog();
            PopulateGridTheme();
        }

        private void DGV_Theme_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGV_Theme.Columns["update_theme"].Index)
            {
                Theme_add_update teacherUpdate = new Theme_add_update(Convert.ToInt32(DGV_Theme.CurrentRow.Cells[2].Value.ToString()), true);
                teacherUpdate.ShowDialog();
                PopulateGridTheme();

            }
            if (e.ColumnIndex == DGV_Theme.Columns["delete_theme"].Index)
            {
                int Id = Convert.ToInt32(DGV_Theme.CurrentRow.Cells[2].Value.ToString());
                if (MessageBox.Show("Вы уверены?", "Вопрос", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(Modules.DB_Conn.str_conn))
                    {
                        conn.Open();
                        string sql = "DELETE FROM [Колледж].[Предмет] WHERE [Номер_предмета]=@Id";
                        SqlCommand comm = new SqlCommand(sql, conn);
                        comm.Parameters.AddWithValue("Id", Id);
                        try
                        {
                            comm.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    MessageBox.Show("Удалено");
                    PopulateGridTheme();
                }
            }
        }

        private void btn_add_user_Click(object sender, EventArgs e)
        {
            User_add_update themeAdd = new User_add_update(0, false);
            themeAdd.ShowDialog();
            PopulateGridUser();
        }

        private void DGV_User_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGV_User.Columns["update_user"].Index)
            {
                User_add_update teacherUpdate = new User_add_update(Convert.ToInt32(DGV_User.CurrentRow.Cells[2].Value.ToString()), true);
                teacherUpdate.ShowDialog();
                PopulateGridUser();

            }
            if (e.ColumnIndex == DGV_User.Columns["delete_user"].Index)
            {
                int Id = Convert.ToInt32(DGV_User.CurrentRow.Cells[2].Value.ToString());
                if (MessageBox.Show("Вы уверены?", "Вопрос", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(Modules.DB_Conn.str_conn))
                    {
                        conn.Open();
                        string sql = "DELETE FROM [Колледж].[Пользователь] WHERE [Номер_пользователя]=@Id";
                        SqlCommand comm = new SqlCommand(sql, conn);
                        comm.Parameters.AddWithValue("Id", Id);
                        try
                        {
                            comm.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    MessageBox.Show("Удалено");
                    PopulateGridUser();
                }
            }
        }

        private void DGV_Student_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGV_Student.Columns["update_student"].Index)
            {
                Student_add_update teacherUpdate = new Student_add_update(Convert.ToInt32(DGV_Student.CurrentRow.Cells[2].Value.ToString()), true);
                teacherUpdate.ShowDialog();
                PopulateGridStudent();

            }
            if (e.ColumnIndex == DGV_Student.Columns["delete_student"].Index)
            {
                int Id = Convert.ToInt32(DGV_Student.CurrentRow.Cells[2].Value.ToString());
                if (MessageBox.Show("Вы уверены?", "Вопрос", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(Modules.DB_Conn.str_conn))
                    {
                        conn.Open();
                        string sql = "DELETE FROM [Колледж].[Студент] WHERE [Зачетная_книжка]=@Id";
                        SqlCommand comm = new SqlCommand(sql, conn);
                        comm.Parameters.AddWithValue("Id", Id);
                        try
                        {
                            comm.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    MessageBox.Show("Удалено");
                    PopulateGridStudent();
                }
            }
        }

        private void btn_add_student_Click(object sender, EventArgs e)
        {
            Student_add_update themeAdd = new Student_add_update(0, false);
            themeAdd.ShowDialog();
            PopulateGridStudent();
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id_s = 0;
            int id_t = 0;
            int id_theme = 0;
            using (SqlConnection conn = new SqlConnection(Modules.DB_Conn.str_conn))
            {
                conn.Open();
                string sql = @"Select [Номер_преподавателя] from [Колледж].[Преподаватель] where [ФИО] = @FIO";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("FIO", DGV.CurrentRow.Cells[5].Value.ToString());
                SqlDataReader rd = comm.ExecuteReader();
                while (rd.Read())
                {
                    id_t = Convert.ToInt32(rd["Номер_преподавателя"].ToString());
                }
                rd.Close();

                sql = @"Select [Зачетная_книжка] from [Колледж].[Студент] where [ФИО] = @FIO";
                comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("FIO", DGV.CurrentRow.Cells[2].Value.ToString());
                rd = comm.ExecuteReader();
                while (rd.Read())
                {
                    id_s = Convert.ToInt32(rd["Зачетная_книжка"].ToString());
                }
                rd.Close();

                sql = @"Select [Номер_предмета] from [Колледж].[Предмет] where [Название_предмета] = @name";
                comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("name", DGV.CurrentRow.Cells[3].Value.ToString());
                rd = comm.ExecuteReader();
                while (rd.Read())
                {
                    id_theme = Convert.ToInt32(rd["Номер_предмета"].ToString());
                }
                rd.Close();
            }
            if (e.ColumnIndex == DGV.Columns["update"].Index)
            {
                Progress_update progress_update = new Progress_update(id_s, id_t, id_theme, DGV.CurrentRow.Cells[4].Value.ToString(), DGV.CurrentRow.Cells[6].Value.ToString());
                progress_update.ShowDialog();
                PopulateGrid();

            }
            if (e.ColumnIndex == DGV.Columns["delete"].Index)
            {
                if (MessageBox.Show("Вы уверены?", "Вопрос", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(Modules.DB_Conn.str_conn))
                    {
                        conn.Open();
                        string sql = "DELETE FROM [Колледж].[Успеваемость] WHERE [Зачетная_книжка] = @Id_s and [Номер_преподавателя] = @Id_theacher and [Номер_предмета] = @Id_theme and [Дата] = @Date and [Оценка] = @Grade";
                        SqlCommand comm = new SqlCommand(sql, conn);
                        comm.Parameters.AddWithValue("Id_s", id_s);
                        comm.Parameters.AddWithValue("Id_theacher", id_t);
                        comm.Parameters.AddWithValue("Id_theme", id_theme);
                        comm.Parameters.AddWithValue("Date", DGV.CurrentRow.Cells[4].Value.ToString());
                        comm.Parameters.AddWithValue("Grade", DGV.CurrentRow.Cells[6].Value.ToString());
                        try
                        {
                            comm.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    MessageBox.Show("Удалено");
                    PopulateGrid();
                }
            }
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }
    }
}
