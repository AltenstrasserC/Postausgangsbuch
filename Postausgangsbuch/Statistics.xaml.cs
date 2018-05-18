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
using LiveCharts.Wpf;
using LiveCharts;

namespace Postausgangsbuch
{
    /// <summary>
    /// Interaction logic for Statistics.xaml
    /// </summary>
    public partial class Statistics : Window
    {
        private FilterLib.FilterModel filterModel;
        public Statistics()
        {
            InitializeComponent();

            
        }
        public Statistics(FilterModel filterModel)
        {
            InitializeComponent();
            myPieChart.Series.Add(new PieSeries { DataLabels = true, LabelPoint = point => $"Email({point.Y})", Title = "Email", Fill = Brushes.CornflowerBlue, StrokeThickness = 0, Values = new ChartValues<double> {filterModel.emailCount} });
            myPieChart.Series.Add(new PieSeries { DataLabels = true, LabelPoint = point => $"Brief({point.Y})", Title = "Brief", Fill = Brushes.DarkSeaGreen, StrokeThickness = 0, Values = new ChartValues<double> { filterModel.briefCount } });
            myPieChart.Series.Add(new PieSeries { DataLabels = true, LabelPoint = point => $"RsA({point.Y})", Title = "RsA", Fill = Brushes.DarkOrange, StrokeThickness = 0, Values = new ChartValues<double> { filterModel.rsaCount } });
            myPieChart.Series.Add(new PieSeries { DataLabels = true, LabelPoint = point => $"RsB({point.Y})", Title = "RsB", Fill = Brushes.IndianRed, StrokeThickness = 0, Values = new ChartValues<double> { filterModel.rsbCount } });

            
            this.filterModel = filterModel;
            this.DataContext = filterModel;
        }

        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

            //clear selected slice.
            foreach (PieSeries series in chart.Series)
            {
                series.PushOut = 0;
                series.DataLabels = true;
            }

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.DataLabels = true;
        }

        private void btn_statsFilter_Click(object sender, RoutedEventArgs e)
        {
            ChooseFilter cf = new ChooseFilter(filterModel);
            cf.Show();
            this.Close();
        }
    }
}
