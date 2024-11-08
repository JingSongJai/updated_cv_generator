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

namespace ProjectGenerateCVWPF.Pages
{
    /// <summary>
    /// Interaction logic for ImageDisplayUserControl.xaml
    /// </summary>
    public partial class ImageDisplayUserControl : UserControl
    {
        public string Title
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }

        public string Position
        {
            get { return txtPosition.Text; }
            set { txtPosition.Text = value; }
        }

        public string ImagePath
        {
            set { imageDisplay.Background = new ImageBrush(new BitmapImage(new Uri(value))) { Stretch = Stretch.UniformToFill }; }
        }

        public ImageDisplayUserControl()
        {
            InitializeComponent();
        }
    }
}
