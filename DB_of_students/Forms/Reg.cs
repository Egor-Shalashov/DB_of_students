using DB_of_students.Forms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace DB_of_students
{
    public partial class Reg : Form
    {
        public Reg()
        {
            InitializeComponent();
        }

        private void Reg_Load(object sender, EventArgs e)
        {

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

        private void btn_login_Click(object sender, EventArgs e)
        {
            string password = GetHash(tb_pwd.Text);

            string sql = @"Select Пароль, Роль, Номер_пользователя  from [Колледж].[Пользователь] where Логин = @login";
            string pwd = "";
            string role = "";
            int id = 0;
            using (SqlConnection conn = new SqlConnection(Modules.DB_Conn.str_conn))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("login", tb_login.Text);
                SqlDataReader rd = comm.ExecuteReader();
                while (rd.Read())
                {
                    pwd = rd["Пароль"].ToString();
                    role = rd["Роль"].ToString();
                    id = Convert.ToInt32(rd["Номер_пользователя"].ToString());
                }
            }
            if (pwd == password)
            {


                switch (role)
                {
                    case "Администратор":
                        MessageBox.Show("Вы вошли как " + role);
                        Admin admin = new Admin();
                        admin.Show();
                        break;

                    case "Преподаватель":
                        MessageBox.Show("Вы вошли как " + role);
                        Teacher teacher = new Teacher(id);
                        teacher.Show();
                        break;

                    case "Секретарь":
                        MessageBox.Show("Вы вошли как " + role);
                        Secretary secretary = new Secretary();
                        secretary.Show();
                        break;

                    case "Студент":
                        MessageBox.Show("Вы вошли как " + role);
                        Student student = new Student(id);
                        student.Show();
                        break;

                    default:
                        MessageBox.Show("Произошла ошибка. Повторите вход.");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Логин или пароль введен неверно");
            }
        }
    }
}
