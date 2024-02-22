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

namespace LombardWpf.Pages.Administrator
{
    /// <summary>
    /// Логика взаимодействия для СonclusionPage.xaml
    /// </summary>
    public partial class СonclusionPage : Page
    {
        public static Product ContextPtroduct; 
        public СonclusionPage(Product products)
        {
            InitializeComponent();
            ContextPtroduct = products; 
            DataContext = ContextPtroduct;
            ProductNameTb.Text = products.Title.ToString();
            TypeProdyctCb.ItemsSource = App.db.TypeProduct.ToList();
        }

        private void TypeProdyctCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var type = TypeProdyctCb.SelectedItem as TypeProduct;
            if(type != null) 
            {
                AssementLw.ItemsSource = App.db.TypeAssesment.Where(x => x.TypeProduct.Id == type.Id).ToList();
            }
            App.db.SaveChanges();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            App.db.Сonclusion.Add(new Сonclusion
            {
                Date = DateTime.Now,
                ProductId = ContextPtroduct.Id,
                TypeProductId = (TypeProdyctCb.SelectedItem as TypeProduct).Id,

            });
            App.db.SaveChanges();
        }
    }
}
