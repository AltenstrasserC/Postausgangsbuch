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
using MahApps.Metro.Controls;

namespace Postausgangsbuch
{
    /// <summary>
    /// Interaction logic for Statistics.xaml
    /// </summary>
    public partial class Statistics : MetroWindow
    {
        private FilterLib.FilterAttributesModel filterModel;
        public Statistics()
        {
            InitializeComponent();


        }
        public Statistics(FilterAttributesModel filterModel)
        {
            InitializeComponent();


            this.filterModel = filterModel;
            this.DataContext = filterModel;

            ReloadChart();
        }
        private void ReloadChart()
        {
            myPieChart.Series = new SeriesCollection();
            if (filterModel.emailCount != 0)
                myPieChart.Series.Add(new PieSeries { DataLabels = true, LabelPoint = point => $"Email({point.Y})", Title = "Email", Fill = Brushes.CornflowerBlue, StrokeThickness = 0, Values = new ChartValues<double> { filterModel.emailCount } });
            if (filterModel.briefCount != 0)
                myPieChart.Series.Add(new PieSeries { DataLabels = true, LabelPoint = point => $"Brief({point.Y})", Title = "Brief", Fill = Brushes.DarkSeaGreen, StrokeThickness = 0, Values = new ChartValues<double> { filterModel.briefCount } });
            if (filterModel.rsaCount != 0)
                myPieChart.Series.Add(new PieSeries { DataLabels = true, LabelPoint = point => $"RsA({point.Y})", Title = "RsA", Fill = Brushes.DarkOrange, StrokeThickness = 0, Values = new ChartValues<double> { filterModel.rsaCount } });
            if (filterModel.rsbCount != 0)
                myPieChart.Series.Add(new PieSeries { DataLabels = true, LabelPoint = point => $"RsB({point.Y})", Title = "RsB", Fill = Brushes.IndianRed, StrokeThickness = 0, Values = new ChartValues<double> { filterModel.rsbCount } });

        }
        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;
            filterModel.HoverTyp = null;
            filterModel.Packets = filterModel.FilterOnStatistik();
            //clear selected slice.
            foreach (PieSeries series in chart.Series)
            {
                series.PushOut = 0;
                series.DataLabels = true;
            }

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.DataLabels = true;
            var typ = selectedSeries.Title;
            filterModel.HoverTyp = typ;
            filterModel.Packets = filterModel.FilterOnStatistik();
        }
        


        private void M_Click(object sender, RoutedEventArgs e)
        {

            var tile = sender as Tile;
            var month = tile.Name.Trim('M');
            if (tile.Background != Brushes.Orange)
            {
                tile.Background = Brushes.Orange;
                filterModel.SelectedMonths[int.Parse(month) - 1] = true;
            }
            else
            {
                tile.Background = new SolidColorBrush(Color.FromArgb(60, 17, 158, 218));
                filterModel.SelectedMonths[int.Parse(month) - 1] = false;
            }
            filterModel.Packets = filterModel.FilterOnStatistik();
            ReloadChart();
        }

        private void txtYear_KeyUp(object sender, KeyEventArgs e)
        {
            filterModel.SelectedYear = lblYear.Text;
            filterModel.Packets = filterModel.FilterOnStatistik();
            ReloadChart();
        }

        private void myPieChart_MouseLeave(object sender, MouseEventArgs e)
        {
            filterModel.HoverTyp = null;
            filterModel.Packets = filterModel.FilterOnStatistik();
        }

        private void MetroWindow_Closed(object sender, EventArgs e)
        {
            filterModel.LoadFilterAttributesModel();
        }
    }
}
