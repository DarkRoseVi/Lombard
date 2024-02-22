using LombardWpf.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using static System.Net.Mime.MediaTypeNames;

namespace LombardWpf.Pages.Client
{
    /// <summary>
    /// Логика взаимодействия для GiveAwayPage.xaml
    /// </summary>
    public partial class GiveAwayPage : Page
    {
        public static Product contextproduct;

        public GiveAwayPage(Product products)
        {
         
            InitializeComponent();
            TypeCb.ItemsSource = App.db.TypeProduct.ToList();
            contextproduct = products;
            DataContext = contextproduct;
            contextproduct.UserId = App.AutoUser.Id;
            PhotoSt.Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialor = new OpenFileDialog() { Multiselect = true };
            if (dialor.ShowDialog().GetValueOrDefault())
            {
                foreach (var item in dialor.FileNames)
                {
                    contextproduct.PhotoProduct.Add(new PhotoProduct()
                    {
                        PhotoProd = File.ReadAllBytes(item),
                        Product = contextproduct,
                    });

                }
                App.db.SaveChanges();
                Reshres();
            }
        }
        private void Reshres()
        {
            ImageLW.ItemsSource = contextproduct.PhotoProduct.ToList();
        }

        private void DeletBtn_Click(object sender, RoutedEventArgs e)
        {
            var phototoyes = (sender as Button).DataContext as PhotoProduct;
            if (MessageBox.Show("Вы точно хотите удалить эту запись", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                App.db.PhotoProduct.Remove(phototoyes);
            }
            App.db.SaveChanges();
            Reshres();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(contextproduct.Title)) 
            {
                MessageBox.Show("Заполните поле названия");
                return;
            }
            //else if( contextproduct.TypeProduct == null) 
            //{
            //    MessageBox.Show("Выберите тип");
            //    return;

            //}
            else 
            {
            App.db.Product.Add(contextproduct);
            App.db.SaveChanges();
            SaveBtn.Visibility = Visibility.Collapsed;
            PhotoSt.Visibility = Visibility.Visible;
            
            }
        }
    }
}
