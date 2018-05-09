using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Postausgangsbuch
{
    public partial class Overview : MetroFramework.Forms.MetroForm
    {
        Login l;
        private FilterLib.FilterModel filterModel;
        public Overview() => InitializeComponent();
        public Overview(FilterLib.FilterModel model)
        {
            InitializeComponent();
            filterModel = model;
            metroLabel1.Text = filterModel.Clerk.Name;
        }
        private void Overview_Load(object sender, EventArgs e)
        {
            this.Text = "Postausgangsbuch";
        }

        private void metroTile8_Click(object sender, EventArgs e)
        {
            FilternNach filternNachWindow = new FilternNach(filterModel);
            filternNachWindow.Show();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            CreateNewWpf createNewPacketWindow = new CreateNewWpf(filterModel);
            createNewPacketWindow.Show();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            CreateNewPersonWPF createNewPersonWindow = new CreateNewPersonWPF(filterModel);
            createNewPersonWindow.Show();
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            Search searchWindow = new Search(filterModel);
            searchWindow.Show();
        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            this.Close();
            l.Show();
        }

        private void metroTile7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not supported yet.");
        }

        private void metroTile6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not supported yet.");
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            Statistics stats = new Statistics(filterModel);
            stats.Show();
        }

        private void Overview_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

    }
}
