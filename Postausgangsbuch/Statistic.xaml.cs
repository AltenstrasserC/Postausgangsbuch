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
using LiveCharts;
using LiveCharts.Wpf;
using PabDbLib;

namespace Postausgangsbuch
{
    /// <summary>
    /// Interaction logic for Statistic.xaml
    /// </summary>
    
    public partial class Statistic : Window
    {
        private readonly PabDBContext db = new PabDBContext();
        private FilterLib.FilterModel filterModel;
        public Statistic()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db.Database.Log = Console.Write;
            InitFilter();
        }
        private void InitFilter()
        {
            filterModel = new FilterLib.FilterModel(db);
            this.DataContext = filterModel;
        }

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var source = sender as Label;
            var typ = source.Content.ToString();
            filterModel.Typ = typ;

        }

        private void LabelMonths_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var source = sender as Label;
            var monthLabelString = source.Content.ToString();
        }
    }
}
