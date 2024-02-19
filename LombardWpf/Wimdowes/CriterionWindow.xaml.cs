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
using System.Windows.Shapes;
using LombardWpf.Models;


namespace LombardWpf.Wimdowes
{
    /// <summary>
    /// Логика взаимодействия для CriterionWindow.xaml
    /// </summary>
    public partial class CriterionWindow : Window
    {
        public Assessment contextassessment;

        public CriterionWindow(Assessment assessment)
        {
            InitializeComponent();
            contextassessment = assessment;
            DataContext = contextassessment;

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if(contextassessment == null) 
            {
            App.db.Assessment.Add(contextassessment);
                MessageBox.Show("Критерий добавлен  в систему ");
            }
            else 
            {
                MessageBox.Show("Изменения внесены");
            }
            App.db.SaveChanges();
            DialogResult = true;

        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
