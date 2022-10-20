using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_of_students.Forms
{
    public partial class User_add_update : Form
    {
        private int g_id;
        private bool flag;

        public User_add_update(int id, bool flag_update)
        {
            InitializeComponent();

            g_id = id;
            flag = flag_update;

            if (flag)
            {
                label5.Text = "Обновить данные";
                btn_add.Text = "Обновить";

                string sql = "Select [Логин], [Роль] from [Колледж].[Пользователь] where [Номер_пользователя] = @id";
                using (SqlConnection conn = new SqlConnection(Modules.DB_Conn.str_conn))
                {
                    conn.Open();
                    SqlCommand comm = new SqlCommand(sql, conn);
                    comm.Parameters.AddWithValue("id", g_id);
                    SqlDataReader rd = comm.ExecuteReader();

                    while (rd.Read())
                    {
                        tb_Login.Text = rd["Логин"].ToString();
                        tb_pole.Text = rd["Роль"].ToString();
                    }
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        public static string GetHash(string password)
        {
            string salt1 = "9io&"; string salt2 = "^tyG";
            password = salt1 + password + salt2;

            using (var hash = SHA256.Create())
            {
                return string.Concat(hash.ComputeHash(Encoding.UTF8.
                        GetBytes(password)).
                    Select(x => x.ToString("X2")));
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                using (SqlConnection conn = new SqlConnection(Modules.DB_Conn.str_conn))
                {
                    conn.Open();
                    string sql = "UPDATE [Колледж].[Пользователь] " +
                                 "SET [Логин]=@Login, [Пароль] = @pwd, [Роль] = @role" +
                                 " WHERE [Номер_пользователя] = @id";

                    SqlCommand comm = new SqlCommand(sql, conn);
                    comm.Parameters.AddWithValue("Id", g_id);
                    comm.Parameters.AddWithValue("Login", tb_Login.Text);
                    comm.Parameters.AddWithValue("pwd", GetHash(tb_pwd.Text));
                    comm.Parameters.AddWithValue("role", tb_pole.Text);
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Обновлено");
                }
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(Modules.DB_Conn.str_conn))
                {
                    conn.Open();
                    string sql = "INSERT INTO [Колледж].[Пользователь] ([Логин], [Пароль], [Роль])" +
                                 " VALUES (@Login, @pwd, @role)";

                    SqlCommand comm = new SqlCommand(sql, conn);
                    comm.Parameters.AddWithValue("Login", tb_Login.Text);
                    comm.Parameters.AddWithValue("pwd", GetHash(tb_pwd.Text));
                    comm.Parameters.AddWithValue("role", tb_pole.Text);
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

        private void User_add_update_Load(object sender, EventArgs e)
        {

        }
    }
}
