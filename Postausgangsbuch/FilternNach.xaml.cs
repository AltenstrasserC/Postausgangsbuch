using FilterLib;
using PabDbLib;
using Postausgangsbuch;
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

namespace Postausgangsbuch
{
    /// <summary>
    /// Interaction logic for FilternNach.xaml
    /// </summary>
    public partial class FilternNach : Window
    {
        private FilterLib.FilterModel filterModel;

        public FilternNach()
        {
            InitializeComponent();
        }

        public FilternNach(FilterModel filterModel)
        {
            InitializeComponent();
            this.filterModel = filterModel;
            this.DataContext = filterModel;
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //WinformFilter n = new WinformFilter();
            //n.Show();
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cmb1.SelectedIndex = 0;
            cmb2.SelectedIndex = 0;
            cmb3.SelectedIndex = 0;
            cmb4.SelectedIndex = 0;
            cmb5.SelectedIndex = 0;
            datePicker1.SelectedDate = DateTime.Parse("01.01.1990");
            datePicker2.SelectedDate = DateTime.Now;
            //Clerk c = filterModel.Clerk;
            
            //filterModel = new FilterModel { Clerk = c};
            filterModel.RefillPacketList();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            filterModel.RefillPacketList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Statistics newStatisticWindow = new Statistics(filterModel);
            newStatisticWindow.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
