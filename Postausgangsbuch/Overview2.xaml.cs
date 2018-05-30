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
        public Overview2() => InitializeComponent();
        public List<string> filternames;

        public Overview2(OverviewModel model)
        {
            InitializeComponent();
            this.model = model;
            lbl_Clerk.Content = this.model.Clerk.Name;
            filternames = model.Filters.Select(x => x.FilterName).ToList();
            if (filternames.Count == 0) { Filter1.Title = "Kein Filter gespeichert"; Filter2.Title = "Kein Filter gespeichert"; }
            if (filternames.Count == 1) { Filter1.Title = filternames[0]; Filter2.Title = "Kein Filter gespeichert"; }
            if (filternames.Count > 1) { Filter1.Title = filternames[0]; Filter2.Title = filternames[1]; }
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
            if (model.Filters.Count >= 1)
            {
                var filter = model.Filters.First();
                FilternNach filternNachWindow = new FilternNach(new FilterAttributesModel(model.database, model.Clerk));
                filternNachWindow.filterModel.Filtername = filter.FilterName;
                filternNachWindow.filterModel.StartDate = filter.MinDate;
                filternNachWindow.filterModel.EndDate = filter.MaxDate;
                filternNachWindow.filterModel.Sender = filter.Sender;
                filternNachWindow.filterModel.Receiver = filter.Receiver;
                filternNachWindow.filterModel.SenderPostcode = filter.SenderZIP;
                filternNachWindow.filterModel.ReceiverPostcode = filter.ReceiverZIP;
                filternNachWindow.filterModel.BriefChecked = filter.isLetter;
                filternNachWindow.filterModel.EmailChecked = filter.isEmail;
                filternNachWindow.filterModel.RsaChecked = filter.isRsA;
                filternNachWindow.filterModel.RsbChecked = filter.isRsB;
                filternNachWindow.Show();
            }
            else
            {
                MessageBox.Show($"Kein Filter vorhanden!");
            }

        }
        private void showSaved2FilterWindow(object sender, MouseButtonEventArgs e)
        {
            if (model.Filters.Count > 1)
            {
                var filter = model.Filters.Skip(1).First();
                FilternNach filternNachWindow = new FilternNach(new FilterAttributesModel(model.database, model.Clerk));
                filternNachWindow.filterModel.Filtername = filter.FilterName;
                filternNachWindow.filterModel.StartDate = filter.MinDate;
                filternNachWindow.filterModel.EndDate = filter.MinDate;
                filternNachWindow.filterModel.Sender = filter.Sender;
                filternNachWindow.filterModel.Receiver = filter.Receiver;
                filternNachWindow.filterModel.SenderPostcode = filter.SenderZIP;
                filternNachWindow.filterModel.ReceiverPostcode = filter.ReceiverZIP;
                filternNachWindow.filterModel.BriefChecked = filter.isLetter;
                filternNachWindow.filterModel.EmailChecked = filter.isEmail;
                filternNachWindow.filterModel.RsaChecked = filter.isRsA;
                filternNachWindow.filterModel.RsbChecked = filter.isRsB;
                filternNachWindow.Show();
            }
            else
            {
                MessageBox.Show($"Kein Filter vorhanden!");
            }
        }
        private void showStatisticWindow(object sender, MouseButtonEventArgs e)
        {
            Statistics stats = new Statistics(new FilterAttributesModel(model.database, model.Clerk));
            stats.Show();
        }

        private void doLogout(object sender, MouseButtonEventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void MetroWindow_Closed(object sender, EventArgs e) => Environment.Exit(0);
    }
}
