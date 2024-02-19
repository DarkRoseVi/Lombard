using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
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
using LombardWpf.Wimdowes;
using LombardWpf.Pages.Client;
using LombardWpf.Pages.Administrator;

namespace LombardWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ClientBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AutoClientWindow().ShowDialog();
            if(dialog.HasValue == true && dialog.Value == true) 
            {
                NavigationService.Navigate(new MenuClPage());
            }
        }

        private void AdminBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AutoAdminWindow().ShowDialog();
            if (dialog.HasValue == true && dialog.Value == true)
            {
                NavigationService.Navigate(new MenuAdminPage());
            }

        }
    }
}
