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
using LombardWpf.Models;
using LombardWpf.Wimdowes;

namespace LombardWpf.Pages.Administrator
{
    /// <summary>
    /// Логика взаимодействия для EditTypePage.xaml
    /// </summary>
    public partial class EditTypePage : Page
    {
        public TypeProduct contexttypeproduct;

        public EditTypePage(TypeProduct typeproduct)
        {
            InitializeComponent();
            contexttypeproduct = typeproduct;
            DataContext = contexttypeproduct;
            AssessmentLw.ItemsSource = App.db.TypeAssesment.Where(x=>x.TypeId == contexttypeproduct.Id).ToList();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(contexttypeproduct.Title)) 
            {
                MessageBox.Show("Заполните поле названия");
                return;
            }
            else 
            {
            if(contexttypeproduct == null) 
                {
                App.db.TypeProduct.Add(contexttypeproduct);
                    MessageBox.Show("Тип товара добавлен");
                }
            else 
                {
                    MessageBox.Show("Данные изменены");
                }
                App.db.SaveChanges();
            }
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack(); 
        }

        private void DeletBtn_Click(object sender, RoutedEventArgs e)
        {
            var assestype = (sender as Button).DataContext as TypeAssesment;
            App.db.TypeAssesment.Remove(assestype);
            App.db.SaveChanges();
            MessageBox.Show("Запись удалена");
            AssessmentLw.ItemsSource = App.db.TypeAssesment.Where(x => x.TypeId == contexttypeproduct.Id).ToList();

        }

        private void AddAssessmentBtn_Click(object sender, RoutedEventArgs e)
        {
            var assestype = contexttypeproduct;
            var dialog = new TypeAssesmentWindow(assestype).ShowDialog();
            if(dialog.HasValue == true &&  dialog.Value == true) 
            {
                AssessmentLw.ItemsSource = App.db.TypeAssesment.Where(x => x.TypeId == contexttypeproduct.Id).ToList();
            }
           
        }
    }
}
