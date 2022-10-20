using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DB_of_students.Forms
{
    public partial class Teacher : Form
    {
        int Global_id;

        public Teacher(int id)
        {
            InitializeComponent();
            string name = "";
            string sql_local = @"Select Номер_преподавателя, ФИО  from [Колледж].[Преподаватель] where Номер_пользователя = @num";
            using (SqlConnection conn = new SqlConnection(Modules.DB_Conn.str_conn))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(sql_local, conn);
                comm.Parameters.AddWithValue("num", id);
                SqlDataReader rd = comm.ExecuteReader();
                while (rd.Read())
                {
                    Global_id = Convert.ToInt32(rd["Номер_преподавателя"].ToString());
                    name = rd["ФИО"].ToString();
                }
            }
            sql_local = @"Select distinct ФИО from [Колледж].[Студент]";
            using (SqlConnection conn = new SqlConnection(Modules.DB_Conn.str_conn))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(sql_local, conn);
                comm.Parameters.AddWithValue("num", id);
                SqlDataReader rd = comm.ExecuteReader();
                while (rd.Read())
                {
                    cb_student.Items.Add(rd["ФИО"].ToString());
                    cb_student_sort.Items.Add(rd["ФИО"].ToString());
                }
            }
            sql_local = @"Select distinct Название_предмета from [Колледж].[Предмет] "
                        + "inner join [Колледж].[Ведение_преподавателями_предметов] on [Колледж].[предмет].[Номер_предмета] = [Колледж].[Ведение_преподавателями_предметов].[Номер_предмета] "
                        + "Where [Колледж].[Ведение_преподавателями_предметов].[Номер_преподавателя] = " + Global_id;
            using (SqlConnection conn = new SqlConnection(Modules.DB_Conn.str_conn))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(sql_local, conn);
                comm.Parameters.AddWithValue("num", id);
                SqlDataReader rd = comm.ExecuteReader();
                while (rd.Read())
                {
                    cb_theme.Items.Add(rd["Название_предмета"].ToString());
                    cb_theme_sort.Items.Add(rd["Название_предмета"].ToString());
                }
            }
            sql_local = @"Select distinct Группа from [Колледж].[Студент]";
            using (SqlConnection conn = new SqlConnection(Modules.DB_Conn.str_conn))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(sql_local, conn);
                comm.Parameters.AddWithValue("num", id);
                SqlDataReader rd = comm.ExecuteReader();
                while (rd.Read())
                {
                    cb_gr.Items.Add(rd["Группа"].ToString());
                }
            }
            label1.Text = "Добро пожаловать, " + name;
            string sql = "SELECT [Колледж].[Студент].[ФИО] as 'ФИО студента', [Колледж].[Студент].[Группа] as 'Группа студента', [Колледж].[Предмет].[Название_предмета] as 'Название предмета', [Дата], [Оценка]  FROM [Колледж].[Успеваемость]"
                         + "inner join [Колледж].[Преподаватель] on [Колледж].[Успеваемость].[Номер_преподавателя] = [Колледж].[Преподаватель].[Номер_преподавателя]"
                         + "inner join [Колледж].[Предмет] on [Колледж].[Успеваемость].[Номер_предмета] = [Колледж].[Предмет].[Номер_предмета]"
                         + "inner join[Колледж].[Студент] on[Колледж].[Успеваемость].[Зачетная_книжка] = [Колледж].[Студент].[Зачетная_книжка]"
                         + "Where [Колледж].[Успеваемость].[Номер_преподавателя] = " + Global_id;
            PopulateGrid(sql);

        }

        private void PopulateGrid(string sql)
        {
            using (SqlConnection conn = new SqlConnection(Modules.DB_Conn.str_conn))
            {
                conn.Open();
                SqlDataAdapter ada = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                ada.Fill(ds);
                DGV.DataSource = ds.Tables[0];
            }
        }

        private void Teacher_Load(object sender, EventArgs e)
        {

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            string id_s = "";
            int id_p = 0;
            string sql_local = @"Select Зачетная_книжка from [Колледж].[Студент] where ФИО = '" + cb_student.Text + "'";
            using (SqlConnection conn = new SqlConnection(Modules.DB_Conn.str_conn))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(sql_local, conn);
                SqlDataReader rd = comm.ExecuteReader();
                while (rd.Read())
                {
                    id_s = rd["Зачетная_книжка"].ToString();
                }
            }

            sql_local = @"Select Номер_предмета from [Колледж].[Предмет] where Название_предмета = '" + cb_theme.Text + "'";
            using (SqlConnection conn = new SqlConnection(Modules.DB_Conn.str_conn))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(sql_local, conn);
                SqlDataReader rd = comm.ExecuteReader();
                while (rd.Read())
                {
                    id_p = Convert.ToInt32(rd["Номер_предмета"].ToString());
                }
            }

            if ((tb_grade.Text == "н" || (tb_grade.Text[0] >= '1' && tb_grade.Text[0] <= '5')) && tb_grade.Text.Length <= 1)
            {
                using (SqlConnection conn = new SqlConnection(Modules.DB_Conn.str_conn))
                {
                    conn.Open();
                    string sql = "INSERT INTO [Колледж].[Успеваемость] ([Зачетная_книжка], [Номер_предмета], [Дата], [Номер_преподавателя], [Оценка])" +
                                 " VALUES (@num_s, @num_p, @data, @num_t, @grade)";

                    SqlCommand comm = new SqlCommand(sql, conn);
                    comm.Parameters.AddWithValue("num_s", id_s);
                    comm.Parameters.AddWithValue("num_p", id_p);
                    comm.Parameters.AddWithValue("data", DateTime.Now);
                    comm.Parameters.AddWithValue("num_t", Global_id);
                    comm.Parameters.AddWithValue("grade", tb_grade.Text);
                    try
                    {
                        comm.ExecuteNonQuery();
                        MessageBox.Show("Добавлено");
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show(er.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Оценка введена не верно");
            }

            string sql_pop = "SELECT [Колледж].[Студент].[ФИО] as 'ФИО студента', [Колледж].[Студент].[Группа] as 'Группа студента', [Колледж].[Предмет].[Название_предмета] as 'Название предмета', [Дата], [Оценка]  FROM [Колледж].[Успеваемость]"
                         + "inner join [Колледж].[Преподаватель] on [Колледж].[Успеваемость].[Номер_преподавателя] = [Колледж].[Преподаватель].[Номер_преподавателя]"
                         + "inner join [Колледж].[Предмет] on [Колледж].[Успеваемость].[Номер_предмета] = [Колледж].[Предмет].[Номер_предмета]"
                         + "inner join[Колледж].[Студент] on[Колледж].[Успеваемость].[Зачетная_книжка] = [Колледж].[Студент].[Зачетная_книжка]"
                         + "Where [Колледж].[Успеваемость].[Номер_преподавателя] = " + Global_id;
            PopulateGrid(sql_pop);
        }

        private void btn_sort_Click(object sender, EventArgs e)
        {
            string sql = "SELECT [Колледж].[Студент].[ФИО] as 'ФИО студента', [Колледж].[Студент].[Группа] as 'Группа студента', [Колледж].[Предмет].[Название_предмета] as 'Название предмета', [Дата], [Оценка]  FROM [Колледж].[Успеваемость]"
                         + "inner join [Колледж].[Преподаватель] on [Колледж].[Успеваемость].[Номер_преподавателя] = [Колледж].[Преподаватель].[Номер_преподавателя]"
                         + "inner join [Колледж].[Предмет] on [Колледж].[Успеваемость].[Номер_предмета] = [Колледж].[Предмет].[Номер_предмета]"
                         + "inner join[Колледж].[Студент] on[Колледж].[Успеваемость].[Зачетная_книжка] = [Колледж].[Студент].[Зачетная_книжка]"
                         + "Where [Колледж].[Успеваемость].[Номер_преподавателя] = " + Global_id;

            if (cb_theme_sort.Text != "")
            {
                if (cb_theme_sort.Text != "all")
                {
                    sql += " and [Колледж].[Предмет].[Название_предмета] = '" + cb_theme_sort.Text + "'";
                }

            }

            if (cb_student_sort.Text != "")
            {

                sql += " and [Колледж].[Студент].[ФИО] = '" + cb_student_sort.Text + "'";


            }

            if (cb_gr.Text != "")
            {
                if (cb_theme_sort.Text != "all")
                {
                    sql += " and [Колледж].[Студент].[Группа] = '" + cb_gr.Text + "'";
                }

            }

            if (DTP_1.Text != "" && DTP_2.Text != "")
            {
                sql += " and [Колледж].[Успеваемость].[Дата] >= '" + DTP_1.Value.Date + "' and '" + DTP_2.Value.Date + "' >= [Колледж].[Успеваемость].[Дата]";
            }

            PopulateGrid(sql);
        }
    }
}
