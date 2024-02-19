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

namespace LombardWpf.Wimdowes
{
    /// <summary>
    /// Логика взаимодействия для AutoAdminWindow.xaml
    /// </summary>
    public partial class AutoAdminWindow : Window
    {
        public AutoAdminWindow()
        {
            InitializeComponent();
        }

        private void AutoBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTb.Text.Trim();
            if(login.Length > 0 ) 
            {
            string password = PasswordTb.Password.Trim();
                if (password.Length > 0)
                {

                    if (login == "123" && password == "123")
                    {
                        MessageBox.Show("Добро пожаловать администратор");
                        DialogResult = true;
                    }
                    else 
                    {
                        MessageBox.Show("У вас нет прав администратора");
                        DialogResult = false;
                    }
                }
                else MessageBox.Show("Введите пароль");
            }
            else
            {
                MessageBox.Show("Введите логин");
            }
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;   
        }
    }
}
