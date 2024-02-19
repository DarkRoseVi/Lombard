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
    /// Логика взаимодействия для TypeAssesmentWindow.xaml
    /// </summary>
    public partial class TypeAssesmentWindow : Window
    {
        public TypeProduct contexttype;

        public TypeAssesmentWindow(TypeProduct producttype)
        {
            InitializeComponent();
            contexttype = producttype;
            DataContext = contexttype;
            //AssessmentCb.ItemsSource = App.db.Assessment.Where(x=>!contexttype.TypeAssesment.Select(z=>z.Assessment).Contains(x)).ToList();
            var t = contexttype.TypeAssesment.Select(x => x.Assessment).ToList();
            //var listass = App.db.TypeAssesment.Where(x=>x.TypeProduct ==  contexttype).Select(z=>z.Assessment).Select(q=>q.Id).ToList();
            //AssessmentCb.ItemsSource = App.db.Assessment.Where(x => listass.Contains(x.Id)==false).ToList();
            var tt = App.db.Assessment.Where(x => t.Contains(x));

            //AssessmentCb.ItemsSource = App.db.Assessment.Where(x => !contexttype.TypeAssesment.Contains(x)).ToList();   
            TypeTb.Text = contexttype.Title;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            App.db.TypeAssesment.Add(new TypeAssesment
            {
                TypeId = contexttype.Id,
                Assessment = AssessmentCb.SelectedItem as Assessment,
            });
            App.db.SaveChanges(); 
            DialogResult = true;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
