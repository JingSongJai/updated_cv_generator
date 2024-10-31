using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectGenerateCVWPF.Pages
{
    /// <summary>
    /// Interaction logic for ProfileUserControl.xaml
    /// </summary>
    public partial class ProfileUserControl : UserControl
    {
        public ProfileUserControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            string[] files = Directory.GetFiles("Profiles");

            if (files.Length == 0) return;

            foreach (string file in files)
            {
                panelDisplay.Children.Add(new ProfileItem() { Title = System.IO.Path.GetFileNameWithoutExtension(file) });
            }
        }
    }
}
