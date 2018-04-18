using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using FilterLib;
using PabDbLib;

namespace Postausgangsbuch
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Window
    {
        private FilterModel filterModel;
        private ObservableCollection<Packet> packetList;
        public Search()
        {
            InitializeComponent();
        }

        public Search(FilterModel filterModel)
        {
            InitializeComponent();
            this.filterModel = filterModel;
            this.DataContext = filterModel;
            packetList = filterModel.Packets.Select(x => x).ToList().AsObservableCollection();
        }

        private void SearchPackets()
        {
            var searchValue = txt_Search.Text.ToLower();
            
            if (rdbtn_name.IsChecked == true)
            {
                var list = packetList.Where(x => x.Receiver.Name.ToLower().StartsWith(searchValue) || x.Sender.Name.ToLower().StartsWith(searchValue))
                                     .Select(x => x);

                if (list != null) filterModel.Packets = list.ToList().AsObservableCollection();
            }
            else if (rdbtn_company.IsChecked == true)
            {
                var list = packetList.Where(x => x.Receiver.Business || x.Sender.Business)
                                     .Where(x => x.Receiver.Name.ToLower().StartsWith(searchValue) || x.Sender.Name.ToLower().StartsWith(searchValue))
                                     .Select(x => x).ToList().AsObservableCollection();
                if (list != null) filterModel.Packets = list;
            }
            else if (rdbtn_ZIP.IsChecked == true)
            {
                if (packetList.Where(x => x.Receiver.Adress.City.PostCode.StartsWith(searchValue)).Count() != 0)
                {
                    if (packetList.Where(x => x.Sender.Adress.City.PostCode.StartsWith(searchValue)).Count() != 0)
                    {
                        var list = packetList.Where(x => x.Receiver.Adress.City.PostCode.StartsWith(searchValue) || x.Sender.Adress.City.PostCode.StartsWith(searchValue))
                                     .Select(x => x).ToList().AsObservableCollection();
                        if (list != null) filterModel.Packets = list;
                    }
                }
            }
            else if (rdbtn_Clerk.IsChecked == true)
            {
                var list = packetList.Where(x => x.Clerk.Name.ToLower().StartsWith(searchValue))
                                     .Select(x => x).ToList().AsObservableCollection();
                if (list != null) filterModel.Packets = list;
            }

        }

        private void Txt_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchPackets();
        }


        private void Rdbtn_date_Checked(object sender, RoutedEventArgs e)
        {
            dpck_DateFirst.Visibility = Visibility.Visible;
            datePicked.Visibility = Visibility.Visible;
            txt_Search.Visibility = Visibility.Hidden;
        }

        private void Rdbtn_date_Unchecked(object sender, RoutedEventArgs e)
        {
            dpck_DateFirst.Visibility = Visibility.Hidden;
            datePicked.Visibility = Visibility.Hidden;
            txt_Search.Visibility = Visibility.Visible;
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            filterModel.SelectedPacket = (Packet)datagrid_Search.CurrentItem;
            Search_Details sd = new Search_Details(filterModel);
            sd.Show();
        }

        private void SearchDate()
        {
            var searchDate = dpck_DateFirst.SelectedDate;
            var list = packetList.Where(x => x.DeliveryDate.Equals(searchDate)).Select(x =>x).ToList().AsObservableCollection();
            filterModel.Packets = list;
        }

        private void DatePicked_Click(object sender, RoutedEventArgs e)
        {
            SearchDate();
            
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            filterModel.RefillPacketList();
        }
    }
}
