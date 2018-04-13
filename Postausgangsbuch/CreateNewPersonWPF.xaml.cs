using FilterLib;
using PabDbLib;
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
    /// Interaction logic for CreateNewPersonWPF.xaml
    /// </summary>
    public partial class CreateNewPersonWPF : Window
    {
        private FilterLib.FilterModel filterModel;
        public CreateNewPersonWPF()
        {
            InitializeComponent();
        }

        public CreateNewPersonWPF(FilterModel filterModel)
        {
            InitializeComponent();
            this.filterModel = filterModel;
            this.DataContext = filterModel;
        }
        
    }
}
