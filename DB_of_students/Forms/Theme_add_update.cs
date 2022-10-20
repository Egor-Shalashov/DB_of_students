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
    public partial class Theme_add_update : Form
    {
        private int g_id;
        private bool flag;
        public Theme_add_update(int id, bool flag_update)
        {
            InitializeComponent();

            g_id = id;
            flag = flag_update;

            if (flag)
            {
                label5.Text = "Обновить данные";
                btn_add.Text = "Обновить";

                string sql = "Select [Название_предмета], [Количество_часов] from [Колледж].[Предмет] where [Номер_предмета] = @id";
                using (SqlConnection conn = new SqlConnection(Modules.DB_Conn.str_conn))
                {
                    conn.Open();
                    SqlCommand comm = new SqlCommand(sql, conn);
                    comm.Parameters.AddWithValue("id", g_id);
                    SqlDataReader rd = comm.ExecuteReader();

                    while (rd.Read())
                    {
                        tb_name.Text = rd["Название_предмета"].ToString();
                        tb_hours.Text = rd["Количество_часов"].ToString();
                    }
                }
            }
        }

        private void Theme_add_update_Load(object sender, EventArgs e)
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
                    string sql = "UPDATE [Колледж].[Предмет] " +
                                 "SET [Название_предмета] = @Name, [Количество_часов] = @Hours" +
                                 " WHERE [Номер_предмета] = @id";

                    SqlCommand comm = new SqlCommand(sql, conn);
                    comm.Parameters.AddWithValue("Id", g_id);
                    comm.Parameters.AddWithValue("Name", tb_name.Text);
                    comm.Parameters.AddWithValue("Hours", tb_hours.Text);
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Обновлено");
                }
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(Modules.DB_Conn.str_conn))
                {
                    conn.Open();
                    string sql = "INSERT INTO [Колледж].[Предмет] ([Название_предмета], [Количество_часов])" +
                                 " VALUES (@Name, @Hours)";

                    SqlCommand comm = new SqlCommand(sql, conn);
                    comm.Parameters.AddWithValue("Name", tb_name.Text);
                    comm.Parameters.AddWithValue("Hours", tb_hours.Text);
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
