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

namespace LombardWpf.Pages.Administrator
{
    /// <summary>
    /// Логика взаимодействия для MenuAdminPage.xaml
    /// </summary>
    public partial class MenuAdminPage : Page
    {
        public MenuAdminPage()
        {
            InitializeComponent();
        }

        private void CloseBt_Click(object sender, RoutedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void AllProductsBt_Click(object sender, RoutedEventArgs e)
        {
            MainMainFrame.NavigationService.Navigate(new ProductAdminPage());
        }

        private void CriterionBtn_Click(object sender, RoutedEventArgs e)
        {
            MainMainFrame.NavigationService.Navigate(new CriterionPAge());
        }

        private void TypeBtn_Click(object sender, RoutedEventArgs e)
        {
            MainMainFrame.NavigationService.Navigate(new TypePage());

        }
    }
}
