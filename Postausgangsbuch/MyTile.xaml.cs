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
    /// Interaction logic for MyTile.xaml
    /// </summary>
    public partial class MyTile : UserControl
    {
        public MyTile()
        {
            InitializeComponent();
            
        }
        private ImageSource image;

        public ImageSource Image
        {
            get {
                return image;
            }
            set {
                image = value;
                Tile_Image.Source = Image;
            }
        }
        
        private Brush brush;

        public Brush Brush
        {
            get
            {
                return brush;
            }
            set
            {
                brush = value;
                Tile_Background.Background = Brush;
            }
        }
        private string title;

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                Tile_Title.Content = Title;
            }
        }

        private void Tile_Background_MouseEnter(object sender, MouseEventArgs e)
        {
            Tile_Background.Margin = new Thickness(5);
        }

        private void Tile_Background_MouseLeave(object sender, MouseEventArgs e)
        {
            Tile_Background.Margin = new Thickness(0);
        }
    }
}
