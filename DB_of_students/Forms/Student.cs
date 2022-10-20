using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DB_of_students.Forms
{
    public partial class Student : Form
    {
        int Global_id;

        public Student(int id)
        {
            InitializeComponent();
            string name = "";
            string sql_local = @"Select Зачетная_книжка, ФИО  from [Колледж].[Студент] where Номер_пользователя = @num";
            using (SqlConnection conn = new SqlConnection(Modules.DB_Conn.str_conn))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(sql_local, conn);
                comm.Parameters.AddWithValue("num", id);
                SqlDataReader rd = comm.ExecuteReader();
                while (rd.Read())
                {
                    Global_id = Convert.ToInt32(rd["Зачетная_книжка"].ToString());
                    name = rd["ФИО"].ToString();
                }
            }
            label1.Text = "Добро пожаловать, " + name;

            string sql = "SELECT [Колледж].[Предмет].[Название_предмета] as 'Название предмета', [Дата], [Оценка]  FROM [Колледж].[Успеваемость] "
                                         + "inner join [Колледж].[Преподаватель] on [Колледж].[Успеваемость].[Номер_преподавателя] = [Колледж].[Преподаватель].[Номер_преподавателя] "
                                         + "inner join [Колледж].[Предмет] on [Колледж].[Успеваемость].[Номер_предмета] = [Колледж].[Предмет].[Номер_предмета] "
                                         + "inner join [Колледж].[Студент] on[Колледж].[Успеваемость].[Зачетная_книжка] = [Колледж].[Студент].[Зачетная_книжка] "
                                         + "Where [Колледж].[Успеваемость].[Зачетная_книжка] = " + Global_id;
            PopulateGrid(sql);

            cb_theme.Items.Add("all");
            sql = @"Select distinct Название_предмета from [Колледж].[Предмет]";
            using (SqlConnection conn = new SqlConnection(Modules.DB_Conn.str_conn))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("num", id);
                SqlDataReader rd = comm.ExecuteReader();
                while (rd.Read())
                {
                    cb_theme.Items.Add(rd["Название_предмета"].ToString());
                }
            }
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

        private void Student_Load(object sender, EventArgs e)
        {

        }

        private void btn_sort_Click(object sender, EventArgs e)
        {
            string sql = "SELECT [Колледж].[Предмет].[Название_предмета] as 'Название предмета', [Дата], [Оценка]  FROM [Колледж].[Успеваемость] "
                         + "inner join [Колледж].[Преподаватель] on [Колледж].[Успеваемость].[Номер_преподавателя] = [Колледж].[Преподаватель].[Номер_преподавателя] "
                         + "inner join [Колледж].[Предмет] on [Колледж].[Успеваемость].[Номер_предмета] = [Колледж].[Предмет].[Номер_предмета] "
                         + "inner join [Колледж].[Студент] on[Колледж].[Успеваемость].[Зачетная_книжка] = [Колледж].[Студент].[Зачетная_книжка] "
                         + "Where [Колледж].[Успеваемость].[Зачетная_книжка] = " + Global_id;

            if (cb_theme.Text != "")
            {
                if (cb_theme.Text != "all")
                {
                    sql += " and [Колледж].[Предмет].[Название_предмета] = '" + cb_theme.Text + "'";
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
