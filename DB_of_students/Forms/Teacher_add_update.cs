using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DB_of_students.Forms
{
    public partial class Teacher_add_update : Form
    {
        private int g_id;
        private bool flag;

        public Teacher_add_update(int id, bool flag_update)
        {
            InitializeComponent();

            g_id = id;
            flag = flag_update;

            if (flag)
            {
                label5.Text = "Обновить данные";
                btn_add.Text = "Обновить";

                string sql = "Select [ФИО], [Адрес], [Телефон], [Должность] from [Колледж].[Преподаватель] where [Номер_преподавателя] = @id";
                using (SqlConnection conn = new SqlConnection(Modules.DB_Conn.str_conn))
                {
                    conn.Open();
                    SqlCommand comm = new SqlCommand(sql, conn);
                    comm.Parameters.AddWithValue("id", g_id);
                    SqlDataReader rd = comm.ExecuteReader();

                    while (rd.Read())
                    {
                        tb_FIO.Text = rd["ФИО"].ToString();
                        tb_adr.Text = rd["Адрес"].ToString();
                        tb_tel.Text = rd["Телефон"].ToString();
                        tb_post.Text = rd["Должность"].ToString();
                    }
                }
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                using (SqlConnection conn = new SqlConnection(Modules.DB_Conn.str_conn))
                {
                    conn.Open();
                    string sql = "UPDATE [Колледж].[Преподаватель] " +
                                 "SET [Номер_пользователя]=@Num [ФИО] = @FIO, [Адрес] = @Adr, [Телефон] = @Tel, [Должность] = @Post" +
                                 " WHERE [Номер_преподавателя] = @id";

                    SqlCommand comm = new SqlCommand(sql, conn);
                    comm.Parameters.AddWithValue("Id", g_id);
                    comm.Parameters.AddWithValue("Num", tb_num.Text);
                    comm.Parameters.AddWithValue("FIO", tb_FIO.Text);
                    comm.Parameters.AddWithValue("Adr", tb_adr.Text);
                    comm.Parameters.AddWithValue("Tel", tb_tel.Text);
                    comm.Parameters.AddWithValue("Post", tb_post.Text);
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Обновлено");
                }
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(Modules.DB_Conn.str_conn))
                {
                    conn.Open();
                    string sql = "INSERT INTO [Колледж].[Преподаватель] ([Номер_пользователя], [ФИО], [Адрес], [Телефон], [Должность])" +
                                 " VALUES (@Num, @FIO, @Adr, @Tel, @Post)";

                    SqlCommand comm = new SqlCommand(sql, conn);
                    comm.Parameters.AddWithValue("Num", tb_num.Text);
                    comm.Parameters.AddWithValue("FIO", tb_FIO.Text);
                    comm.Parameters.AddWithValue("Adr", tb_adr.Text);
                    comm.Parameters.AddWithValue("Tel", tb_tel.Text);
                    comm.Parameters.AddWithValue("Post", tb_post.Text);
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
            Close();
        }

        private void Teacher_add_update_Load(object sender, EventArgs e)
        {

        }
    }
}
