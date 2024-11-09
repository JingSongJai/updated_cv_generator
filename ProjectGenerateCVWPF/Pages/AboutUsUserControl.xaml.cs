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
    /// Interaction logic for AboutUsUserControl.xaml
    /// </summary>
    public partial class AboutUsUserControl : UserControl
    {
        public AboutUsUserControl()
        {
            InitializeComponent();
            panelDisplay.Children.Add(new ImageDisplayUserControl() { Title = "Teang Chandalen", Position = "Teacher", ImagePath = "pack://application:,,,/Images/dalen.jpg" }); 
            panelDisplay.Children.Add(new ImageDisplayUserControl() { Title = "Eav Phanith", Position = "Teacher", ImagePath = "pack://application:,,,/Images/person.jpg" }); 
            panelDisplay.Children.Add(new ImageDisplayUserControl() { Title = "Nuch Chamnan", Position = "Teacher", ImagePath = "pack://application:,,,/Images/person.jpg" }); 
            
            panelDisplay1.Children.Add(new ImageDisplayUserControl() { Title = "Phen Makara", Position = "Member", ImagePath = "pack://application:,,,/Images/makara.jpg" }); 
            panelDisplay1.Children.Add(new ImageDisplayUserControl() { Title = "Sreang Rathana", Position = "Member", ImagePath = "pack://application:,,,/Images/default_photo.jpg" }); 
            panelDisplay1.Children.Add(new ImageDisplayUserControl() { Title = "Sinh Porsou", Position = "Member", ImagePath = "pack://application:,,,/Images/default_photo.jpg" }); 
            panelDisplay1.Children.Add(new ImageDisplayUserControl() { Title = "Taing ChingSong", Position = "Member", ImagePath = "pack://application:,,,/Images/song.jpg" }); 
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://mptc.gov.kh/en/",
                UseShellExecute = true
            });
        }

        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://mptc.gov.kh/en/",
                UseShellExecute = true
            });
        }

        private void Image_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://web.facebook.com/ant.com.kh",
                UseShellExecute = true
            });
        }
    }
}
