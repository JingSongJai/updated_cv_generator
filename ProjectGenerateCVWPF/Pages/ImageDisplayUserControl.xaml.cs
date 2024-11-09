using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
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

        public string Url { set; get; }

        public string ImagePath
        {
            set { imageDisplay.Background = new ImageBrush(new BitmapImage(new Uri(value))) { Stretch = Stretch.UniformToFill, AlignmentY = AlignmentY.Top }; }
        }

        public ImageDisplayUserControl()
        {
            InitializeComponent();
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = Url,
                UseShellExecute = true
            });
        }
    }
}
