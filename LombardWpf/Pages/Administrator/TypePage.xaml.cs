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
using LombardWpf.Pages;
using LombardWpf.Models;


namespace LombardWpf.Pages.Administrator
{
    /// <summary>
    /// Логика взаимодействия для TypePage.xaml
    /// </summary>
    public partial class TypePage : Page
    {
        public TypePage()
        {
            InitializeComponent();
            TypeLw.ItemsSource = App.db.TypeProduct.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var  type = new TypeProduct();
            NavigationService.Navigate(new EditTypePage(type));
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var type = (sender as Button).DataContext as TypeProduct;
            NavigationService.Navigate(new EditTypePage(type));

        }

        private void DeletBtn_Click(object sender, RoutedEventArgs e)
        {
            var type = (sender as Button).DataContext as TypeProduct;
            App.db.TypeProduct.Remove(type);
            MessageBox.Show("Выбранный тип был удален");
            App.db.SaveChanges();
            TypeLw.ItemsSource = App.db.TypeProduct.ToList();
        }
    }
}
