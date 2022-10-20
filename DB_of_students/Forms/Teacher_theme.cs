using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DB_of_students.Forms
{
    public partial class Teacher_theme : Form
    {
        private int Global_id;
        public Teacher_theme(int id)
        {
            InitializeComponent();
            Global_id = id;
            using (SqlConnection conn = new SqlConnection(Modules.DB_Conn.str_conn))
            {
                conn.Open();
                string sql = "SELECT DISTINCT [Колледж].[Предмет].[Название_предмета] From [Колледж].[Предмет]";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("Id", Global_id);
                SqlDataReader rd = comm.ExecuteReader();
                while (rd.Read())
                {
                    cb_theme.Items.Add(rd["Название_предмета"]);
                }
            }

            Populate();

            DataGridViewButtonColumn delete = new DataGridViewButtonColumn
            {
                Name = "Delete",
                Text = "Удалить",
                HeaderText = "Удалить предмет",
                UseColumnTextForButtonValue = true
            };
            DGV_theme.Columns.Add(delete);

        }

        private void Populate()
        {
            using (SqlConnection conn = new SqlConnection(Modules.DB_Conn.str_conn))
            {
                conn.Open();
                string sql = "SELECT [Колледж].[Предмет].[Название_предмета] From [Колледж].[Предмет]"
                             + "Inner join [Колледж].[Ведение_преподавателями_предметов] on [Колледж].[Предмет].[Номер_предмета] = [Колледж].[Ведение_преподавателями_предметов].[Номер_предмета]"
                             + "Inner join [Колледж].[Преподаватель] on [Колледж].[Ведение_преподавателями_предметов].[Номер_преподавателя] = [Колледж].[Преподаватель].[Номер_преподавателя]"
                             + "Where [Колледж].[Преподаватель].[Номер_преподавателя] = " + Global_id;
                SqlDataAdapter ada = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                ada.Fill(ds);
                DGV_theme.DataSource = ds.Tables[0];
            }
        }

        private string SetTheme(string name)
        {
            using (SqlConnection conn = new SqlConnection(Modules.DB_Conn.str_conn))
            {
                conn.Open();
                string sql = "SELECT [Колледж].[Предмет].[Номер_предмета] From [Колледж].[Предмет]"
                             + "Where [Колледж].[Предмет].[Название_предмета] = '" + name + "'";
                SqlCommand comm = new SqlCommand(sql, conn);
                SqlDataReader rd = comm.ExecuteReader();
                while (rd.Read())
                {
                    return rd["Номер_предмета"].ToString();
                }
            }

            return "";
        }

        private void Teacher_theme_Load(object sender, EventArgs e)
        {

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(Modules.DB_Conn.str_conn))
            {
                conn.Open();
                string sql = "INSERT INTO [Колледж].[Ведение_преподавателями_предметов] ([Номер_предмета], [Номер_преподавателя])" +
                             " VALUES (@id_theme, @id_teacher)";

                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("id_theme", SetTheme(cb_theme.Text));
                comm.Parameters.AddWithValue("id_teacher", Global_id);
                try
                {
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Добавлено");
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
                Populate();
            }
        }

        private void DGV_theme_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGV_theme.Columns["Delete"].Index)
            {
                if (MessageBox.Show("Вы уверены?", "Вопрос", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(Modules.DB_Conn.str_conn))
                    {
                        conn.Open();
                        string sql = "DELETE FROM [Колледж].[Ведение_преподавателями_предметов] WHERE [Номер_преподавателя] = @Id and [Номер_предмета] = @Id_theme";
                        SqlCommand comm = new SqlCommand(sql, conn);
                        comm.Parameters.AddWithValue("Id", Global_id);
                        comm.Parameters.AddWithValue("Id_theme", SetTheme(DGV_theme.CurrentRow.Cells[1].Value.ToString()));
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
                    Populate();
                }
            }
        }
    }
}
