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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private readonly PabDbLib.PabDBContext db = new PabDbLib.PabDBContext();
        public FilterLib.FilterModel filterModel;
        private List<Clerk> LoginData;

        public Login()=>Init();
        private void Init()
        {
            InitializeComponent();
            LoginData = db.Clerks.Select(x => x).ToList();
            filterModel = new FilterLib.FilterModel(db);
            this.DataContext = filterModel;
        }

        private void btn_Login_Click(object sender, RoutedEventArgs e)
        {
            
            var username = txtBxUserName.Text;
            if ((LoginData.Where(x => x.Name == username).Count() == 1))
            {
                var login = LoginData.Where(x => x.Name == username)
                                     .First()
                                     .Password;
                if (login.Equals(pwBxPassword.Password))
                {
                    lblError.Content = "Sie wurden erfolgreich angemeldet!";
                    lblError.Foreground = Brushes.Green;
                    filterModel.Clerk = new Clerk {Name = username, Password = pwBxPassword.Password};
                    Overview overview = new Overview(filterModel);
                    overview.Show();
                    this.Hide();
                }
            }
            else
            {
                lblError.Content = "Benutzername/Passwort falsch";
                lblError.Foreground = Brushes.Red;
                lblError.Visibility = Visibility.Visible;
            }
        }
    }
}
