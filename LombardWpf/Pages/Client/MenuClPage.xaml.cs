using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using LombardWpf.Models;


namespace LombardWpf.Pages.Client
{
    /// <summary>
    /// Логика взаимодействия для MenuClPage.xaml
    /// </summary>
    public partial class MenuClPage : Page
    {
        public MenuClPage()
        {
            InitializeComponent();
        }

        private void CloseBt_Click(object sender, RoutedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void GiveAwayBtn_Click(object sender, RoutedEventArgs e)
        {
            MainMainFrame.NavigationService.Navigate(new GiveAwayPage(new Product()));
        }

        private void AllProductsBt_Click(object sender, RoutedEventArgs e)
        {
            MainMainFrame.NavigationService.Navigate(new ProductClPage());
        }
    }
}
