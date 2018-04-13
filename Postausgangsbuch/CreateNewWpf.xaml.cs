using FilterLib;
using Microsoft.Win32;
using PabDbLib;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for CreateNewWpf.xaml
    /// </summary>
    public partial class CreateNewWpf : Window
    {
        private readonly PabDBContext db = new PabDBContext();
        private FilterLib.FilterModel filterModel;
        public CreateNewWpf() => InitializeComponent();

        public CreateNewWpf(FilterModel filterModel)
        {
            InitializeComponent();
            this.filterModel = filterModel;
            this.DataContext = filterModel;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 0;
            dpkDelivery.SelectedDate = DateTime.Parse("01.01.1990");
        }
        
        private void btnAddNewReceiver_Click(object sender, RoutedEventArgs e)
        {
            CreateNewPersonWPF c = new CreateNewPersonWPF(filterModel);
            c.ShowDialog();
        }
        private void btnAddNewSender_Click(object sender, RoutedEventArgs e)
        {
            CreateNewPersonWPF c = new CreateNewPersonWPF(filterModel);
            c.ShowDialog();
        }
        private void TxtBx_Sender_TextChanged(object sender, EventArgs e)
        {
            SearchPersonSender();
        }
        private void TxtBx_Receiver_TextChanged(object sender, EventArgs e)
        {
            SearchPersonReceiver();
        }
        private void SearchPersonSender()
        {
            var searchValue = txtNameSender.Text;
            var list = db.Persons.Where(x => x.Name.StartsWith(searchValue)).Select(x => x);
            grdSender.Items.Clear();
            //if (list != null) AddToList(list, txtNameSender);
        }

        private void SearchPersonReceiver()
        {
            var searchValue = txtNameReceiver.Text;
            var list = db.Persons.Where(x => x.Name.StartsWith(searchValue)).Select(x => x);
            grdReceiver.Items.Clear();
            //if (list != null) AddToList(list, txtNameReceiver);
        }

        private void btnChooseSender_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnChooseReceiver_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnChoosePath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                txtFilepath.Text = openFileDialog.FileName;
            }
        }
        

        private void btnCreateNew_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
