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
    public partial class Overview2 : MetroWindow
    {
        Login l;
        private FilterLib.OverviewModel model;
        public Overview2()=> InitializeComponent();
        public Overview2(OverviewModel model)
        {
            InitializeComponent();
            this.model = model;
            lbl_Clerk.Content = this.model.Clerk.Name;
            var filternames = model.Filters.Select(x => x.Name).ToList();
            if (filternames.Count >= 1) { Filter1.Title = filternames[0]; }
        }

        private void showCreateNewPacketWindow(object sender, MouseButtonEventArgs e)
        {
            CreateNewWpf createNewPacketWindow = new CreateNewWpf(new NewPacketModel(model.database, model.Clerk));
            createNewPacketWindow.Show();
        }

        private void showCreateNewPersonWindow(object sender, MouseButtonEventArgs e)
        {
            CreateNewPersonWPF createNewPersonWindow = new CreateNewPersonWPF(new PersonModel(model.database));
            createNewPersonWindow.Show();
        }

        private void showSearchWindow(object sender, MouseButtonEventArgs e)
        {
            Search searchWindow = new Search(new SearchModel(model.database, model.Clerk));
            searchWindow.Show();
        }

        private void showFilterWindow(object sender, MouseButtonEventArgs e)
        {
            FilternNach filternNachWindow = new FilternNach(new FilterAttributesModel(model.database, model.Clerk));
            filternNachWindow.Show();
        }

        private void showSavedFilterWindow(object sender, MouseButtonEventArgs e)
        {
            var filter = model.Filters.First();//TODO if filter1 null
            FilternNach filternNachWindow = new FilternNach(new FilterAttributesModel(model.database, model.Clerk));
            filternNachWindow.filterModel.Filtername = filter.Name;
            filternNachWindow.filterModel.StartDate = filter.MinDate;
            filternNachWindow.filterModel.EndDate = filter.MaxDate;
            filternNachWindow.filterModel.Sender = filter.Sender;
            filternNachWindow.filterModel.Receiver = filter.Receiver;
            filternNachWindow.filterModel.SenderPostcode = filter.SenderZIP;
            filternNachWindow.filterModel.ReceiverPostcode = filter.ReceiverZIP;
            filternNachWindow.filterModel.BriefChecked = filter.Brief;
            filternNachWindow.filterModel.EmailChecked = filter.Email;
            filternNachWindow.filterModel.RsaChecked = filter.RsA;
            filternNachWindow.filterModel.RsbChecked = filter.RsB;
            filternNachWindow.Show();

        }
        private void showSaved2FilterWindow(object sender, MouseButtonEventArgs e)
        {
            var filter = model.Filters.Skip(1).First();//TODO if filter1 null
            FilternNach filternNachWindow = new FilternNach(new FilterAttributesModel(model.database, model.Clerk));
            filternNachWindow.filterModel.Filtername = filter.Name;
            filternNachWindow.filterModel.StartDate = filter.MinDate;
            filternNachWindow.filterModel.EndDate = filter.MinDate;
            filternNachWindow.filterModel.Sender = filter.Sender;
            filternNachWindow.filterModel.Receiver = filter.Receiver;
            filternNachWindow.filterModel.SenderPostcode = filter.SenderZIP;
            filternNachWindow.filterModel.ReceiverPostcode = filter.ReceiverZIP;
            filternNachWindow.filterModel.BriefChecked = filter.Brief;
            filternNachWindow.filterModel.EmailChecked = filter.Email;
            filternNachWindow.filterModel.RsaChecked = filter.RsA;
            filternNachWindow.filterModel.RsbChecked = filter.RsB;
            filternNachWindow.Show();
        }
        private void showStatisticWindow(object sender, MouseButtonEventArgs e)
        {
            Statistics stats = new Statistics(new FilterAttributesModel(model.database, model.Clerk));
            stats.Show();
        }

        private void doLogout(object sender, MouseButtonEventArgs e)
        {
            Login l = new Login();
            this.Close();
            l.Show();
        }
        
        private void MetroWindow_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Filter1_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
