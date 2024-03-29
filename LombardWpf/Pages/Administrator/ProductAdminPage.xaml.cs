﻿using System;
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
using LombardWpf.Models;
using LombardWpf.Pages;

namespace LombardWpf.Pages.Administrator
{
    /// <summary>
    /// Логика взаимодействия для ProductAdminPage.xaml
    /// </summary>
    public partial class ProductAdminPage : Page
    {
        public ProductAdminPage()
        {
            InitializeComponent();
            ProductLw.ItemsSource = App.db.Product.ToList();    
        }



        private void EstimateBtn_Click(object sender, RoutedEventArgs e)
        {
            var product = (sender as Button).DataContext as Product;
            NavigationService.Navigate(new СonclusionPage(product));
        }
    }
}
