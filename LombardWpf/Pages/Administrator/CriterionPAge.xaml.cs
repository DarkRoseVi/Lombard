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
using LombardWpf.Wimdowes;


namespace LombardWpf.Pages.Administrator
{
    /// <summary>
    /// Логика взаимодействия для CriterionPAge.xaml
    /// </summary>
    public partial class CriterionPAge : Page
    {
        public CriterionPAge()
        {
            InitializeComponent();
            AssessmentLw.ItemsSource = App.db.Assessment.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var criterion = new Assessment();
            var dialog = new CriterionWindow(criterion).ShowDialog();
            if (dialog.HasValue == true && dialog.Value == true)
            {
                e.Handled = true;
                AssessmentLw.ItemsSource = App.db.Assessment.ToList();
            }
        }

        private void DeletBtn_Click(object sender, RoutedEventArgs e)
        {
            var criterion = (sender as Button).DataContext as Assessment;
            App.db.Assessment.Remove(criterion);
            App.db.SaveChanges();
            MessageBox.Show("Критерий удален");
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var criterion = (sender as Button).DataContext as Assessment;
            var dialog = new CriterionWindow(criterion).ShowDialog();
            if(dialog.HasValue == true && dialog.Value== true) 
            {
            e.Handled = true;
                AssessmentLw.ItemsSource = App.db.Assessment.ToList();
            }
        }
    }
}
