using LombardWpf.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LombardWpf.Pages.Client
{
    /// <summary>
    /// Логика взаимодействия для ProductClPage.xaml
    /// </summary>
    public partial class ProductClPage : Page
    {
        public ProductClPage()
        {
            InitializeComponent();
              ProductLw.ItemsSource = App.db.Product.Where(x=>x.UserId == App.AutoUser.Id).ToList();      
          //  ProductLw.ItemsSource = App.db.Product.ToList();
        }

        private void ProductLw_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var product = ProductLw.SelectedItem as Product;
           // NavigationService.Navigate(new InfoTeamPage(team));
        }
    }
}
