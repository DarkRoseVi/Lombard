using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
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
using LombardWpf.Models;


namespace LombardWpf.Wimdowes
{
    /// <summary>
    /// Логика взаимодействия для RegClWindow.xaml
    /// </summary>
    public partial class RegClWindow : Window
    {
        public RegClWindow()
        {
            InitializeComponent();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;

        }

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            string fistname = FirstNameTb.Text.Trim();
            if (fistname.Length > 0)
            {
                string name = NameTb.Text.Trim();
                if (name.Length > 0)
                {
                    string lastname = LastNameTb.Text.Trim();
                    if (lastname.Length > 0)
                    {
                        string login = LoginTb.Text.Trim();
                        if (login.Length > 0)
                        {
                            string password = PasswordTb.Password.Trim();
                            if (password.Length > 0)
                            {
                                var user = App.db.User.FirstOrDefault(x => x.Login == login && x.Password == password );
                                if(user != null) 
                                {
                                    MessageBox.Show("пользователь с такми данными существует"); 

                                }
                                else 
                                {
                                    App.db.User.Add(new User
                                    {
                                        LName = lastname,
                                        Name = name,
                                        FName = fistname,
                                        Login = login,
                                        Password = password
                                    });
                                    App.db.SaveChanges();
                                    MessageBox.Show("Пользователь создан");
                                    DialogResult = true;
                                }
                            }
                            else MessageBox.Show("Введите пароль");
                        }
                        else MessageBox.Show("Введите логин");
                    }
                    else MessageBox.Show("Введите отчество");

                }
                else MessageBox.Show("Введите имя");
            }
            else MessageBox.Show("Введите фамилию");
        }

        private void FirstNameTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void NameTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void LastNameTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
