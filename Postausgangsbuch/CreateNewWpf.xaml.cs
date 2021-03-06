﻿using FilterLib;
using MahApps.Metro.Controls;
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
    public partial class CreateNewWpf : MetroWindow
    {
        private readonly PabDBContext db = new PabDBContext();
        private FilterLib.NewPacketModel filterModel;
        public CreateNewWpf() => InitializeComponent();

        public CreateNewWpf(NewPacketModel filterModel)
        {
            InitializeComponent();
            this.filterModel = filterModel;
            this.DataContext = filterModel;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 0;
            dpkDelivery.SelectedDate = (DateTime.Now).Date;
        }
        
        private void btnAddNewPerson_Click(object sender, RoutedEventArgs e)
        {
            CreateNewPersonWPF c = new CreateNewPersonWPF(new PersonModel(filterModel.db));
            c.ShowDialog();
            filterModel.LoadNewPacketModel();
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
            var list = db.Persons.Where(x => x.LastName.StartsWith(searchValue)).Select(x => x);
            grdSender.Items.Clear();
            txtNameSender.Text = "";
            searchValue = null;
        }

        private void SearchPersonReceiver()
        {
            var searchValue = txtNameReceiver.Text;
            var list = db.Persons.Where(x => x.LastName.StartsWith(searchValue)).Select(x => x);
            grdReceiver.Items.Clear();
            txtNameReceiver.Text = "";
            searchValue = null;
        }

        private void btnChoosePath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                txtFilepath.Text = openFileDialog.FileName;
            }
        }

        private void btnCreateNew_Click(object sender, RoutedEventArgs e) => this.Close();

        private void btnclose_Click(object sender, RoutedEventArgs e) => this.Close();
    }
}
