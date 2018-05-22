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
using FilterLib;
using MahApps.Metro.Controls;
using PabDbLib;

namespace Postausgangsbuch
{
    /// <summary>
    /// Interaction logic for Search_Details.xaml
    /// </summary>
    public partial class Search_Details : MetroWindow
    {
        private SearchModel model;

        public Search_Details() => InitializeComponent();

        public Search_Details(SearchModel model)
        {
            InitializeComponent();
            this.model = model;
            this.DataContext = model;
        }
    }
}
