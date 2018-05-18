using FilterLib;
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

namespace Postausgangsbuch
{
    /// <summary>
    /// Interaction logic for ChooseFilter.xaml
    /// </summary>
    public partial class ChooseFilter : Window
    {
        private FilterLib.FilterModel filterModel;
        public ChooseFilter()
        {
            InitializeComponent();

        }
        public ChooseFilter(FilterModel filterModel)
        {
            InitializeComponent();
            this.filterModel = filterModel;
            this.DataContext = filterModel;

            var filterlist = filterModel.Filters.Select(x => x.Name);
            filterListBox.ItemsSource = filterlist;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string selectedFilterName = filterListBox.SelectedItem.ToString();
            filterModel.selectedFilter = filterModel.Filters.First(x => x.Name.ToString() == selectedFilterName);
            filterModel.NewFilter = filterModel.selectedFilter;//TODO mindate =
            filterModel.FilterOnCollection();
            this.Close();
            Statistics stats = new Statistics(filterModel);
            stats.Show();
        }
        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
            Statistics stats = new Statistics(filterModel);
            stats.Show();
            
        }
    }
}
