using FilterLib;
using MahApps.Metro.Controls;
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
    public partial class CreateNewPersonWPF : MetroWindow
    {
        private FilterLib.PersonModel personModel;
        public CreateNewPersonWPF() => InitializeComponent();

        public CreateNewPersonWPF(PersonModel personModel)
        {
            InitializeComponent();
            this.personModel = personModel;
            this.DataContext = personModel;
        }

        private void btn_finish_Click(object sender, RoutedEventArgs e) => this.Close();
    }
}
