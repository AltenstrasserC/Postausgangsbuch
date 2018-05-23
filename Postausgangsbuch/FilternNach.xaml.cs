using FilterLib;
using MahApps.Metro.Controls;
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
    public partial class FilternNach : MetroWindow
    {
        public FilterLib.FilterAttributesModel filterModel;

        public FilternNach() => InitializeComponent();

        public FilternNach(FilterAttributesModel filterModel)
        {
            InitializeComponent();
            this.filterModel = filterModel;
            this.DataContext = filterModel;
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            filterModel.LoadFilterAttributesModel();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            filterModel.LoadFilterAttributesModel();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Statistics newStatisticWindow = new Statistics(filterModel);
            newStatisticWindow.Show(); //TODO: Make Window uneditable
        }
    }
}
