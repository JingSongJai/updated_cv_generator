using iText.Layout.Properties;
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
    /// Interaction logic for TemplateInterfaceUserControl.xaml
    /// </summary>
    public partial class TemplateInterfaceUserControl : UserControl
    {
        public event MouseButtonEventHandler userClicked; 

        public ImageBrush Image
        {
            get { return (ImageBrush)imageDisplay.Background; }
            set { imageDisplay.Background = value; }
        }

        public string Title
        {
            get { return txtTitle.Text; }
            set { txtTitle.Text = value; }
        }

        public TemplateInterfaceUserControl()
        {
            InitializeComponent();
        }

        private void UserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            userClicked?.Invoke(this, e);
        }
    }
}
