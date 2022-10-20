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
    public partial class Student_add_update : Form
    {
        private int g_id;
        private bool flag;

        public Student_add_update(int id, bool flag_update)
        {
            InitializeComponent();

            g_id = id;
            flag = flag_update;

            if (flag)
            {
                label5.Text = "Обновить данные";
                btn_add.Text = "Обновить";

                string sql = "Select [ФИО], [Адрес], [Телефон], [Номер_пользователя], [Группа] from [Колледж].[Студент] where [Зачетная_книжка] = @id";
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
                        tb_num.Text = rd["Номер_пользователя"].ToString();
                        tb_gr.Text = rd["Группа"].ToString();
                    }
                }
            }
        }

        private void Student_add_update_Load(object sender, EventArgs e)
        {

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
                    string sql = "UPDATE [Колледж].[Студент] " +
                                 "SET [ФИО] = @FIO, [Адрес] = @Adr, [Телефон] = @Tel, [Номер_пользователя]=@Num, [Группа] = @Gr" +
                                 " WHERE [Зачетная_книжка] = @id";

                    SqlCommand comm = new SqlCommand(sql, conn);
                    comm.Parameters.AddWithValue("Id", g_id);
                    comm.Parameters.AddWithValue("FIO", tb_FIO.Text);
                    comm.Parameters.AddWithValue("Adr", tb_adr.Text);
                    comm.Parameters.AddWithValue("Tel", tb_tel.Text);
                    comm.Parameters.AddWithValue("Num", tb_num.Text);
                    comm.Parameters.AddWithValue("Gr", tb_gr.Text);
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Обновлено");
                }
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(Modules.DB_Conn.str_conn))
                {
                    conn.Open();
                    string sql = "INSERT INTO [Колледж].[Студент] ([ФИО], [Адрес], [Телефон], [Номер_пользователя], [Группа])" +
                                 " VALUES (@FIO, @Adr, @Tel, @Num, @Gr)";

                    SqlCommand comm = new SqlCommand(sql, conn);
                    comm.Parameters.AddWithValue("FIO", tb_FIO.Text);
                    comm.Parameters.AddWithValue("Adr", tb_adr.Text);
                    comm.Parameters.AddWithValue("Tel", tb_tel.Text);
                    comm.Parameters.AddWithValue("Num", tb_num.Text);
                    comm.Parameters.AddWithValue("Gr", tb_gr.Text);
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
    }
}
