using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using VRA.BuisnessLayer;

namespace Reklama_monitoring
{
    /// <summary>
    /// Логика взаимодействия для AccountConnect.xaml
    /// </summary>
    public partial class AccountConnect : Window
    {
        public AccountConnect()
        {
            InitializeComponent();
        }

       public bool connect { get; set; }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (Connect())
            {
                connect = true;
                this.Close();
            }
            else
            {
                connect = false;
                MessageBox.Show("Неверный логин или пароль.");
            }

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool Connect()
        {
            string serverName = ProcessFactory.GetSettingsProcess().GetSettings(); // Адрес сервера (для локальной базы пишите "localhost")
            int index = serverName.IndexOf(';');
            serverName = serverName.Remove(index);
            serverName = serverName.Replace("Data Source=", "");
            string userName = "account"; // Имя пользователя
            string dbName = "accounts"; //Имя базы данных
            string password = "123"; // Пароль для подключения
            string connStr = "server=" + serverName +
                ";user=" + userName +
                ";database=" + dbName +
                ";password=" + password + ";";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT login,password FROM Account WHERE login = @ID1 and password=@ID2";
                cmd.Parameters.AddWithValue("@ID1", tbLogin.Text);
                cmd.Parameters.AddWithValue("@ID2", tbPassword.Password);
                using (var dataReader = cmd.ExecuteReader())
                {
                    if (!dataReader.Read())
                        return false;
                    else return true;
                            
                }
            }
        }



    }
}
