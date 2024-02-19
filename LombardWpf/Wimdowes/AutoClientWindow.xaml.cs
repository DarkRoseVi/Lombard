using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LombardWpf.Models;
using LombardWpf.Pages;
using LombardWpf.Pages.Client;

namespace LombardWpf.Wimdowes
{
    /// <summary>
    /// Логика взаимодействия для AutoClientWindow.xaml
    /// </summary>
    public partial class AutoClientWindow : Window
    {
        public AutoClientWindow()
        {
            InitializeComponent();
        }

        private void AutoBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTb.Text.Trim();
            if (login.Length > 0)
            {
                string password = PasswordTb.Password.Trim();
                if (password.Length > 0)
                {
                    var user = App.db.User.FirstOrDefault(x=>x.Login == login && x.Password == password);
                    if (user != null)
                    {
                        MessageBox.Show("Добро пожаловать");
                        App.AutoUser = user;    
                        DialogResult = true;   
                        
                       // NavigationService.GetNavigationService(new MenuClPage());
                    }
                    else MessageBox.Show("Пользователя с такими данными не существует");
                }
                else MessageBox.Show("Заполните поле пароля");

            }
            else MessageBox.Show("Введите логин");
        }

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
                 new RegClWindow().ShowDialog();
        }
    }
}
