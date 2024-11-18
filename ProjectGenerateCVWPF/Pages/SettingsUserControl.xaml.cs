using MaterialDesignThemes.Wpf;
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
    /// Interaction logic for SettingsUserControl.xaml
    /// </summary>
    public partial class SettingsUserControl : UserControl
    {
        
        public SettingsUserControl()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbFont.SelectedIndex == 0) App.Current.Resources["CV Font"] = new FontFamily(new Uri("pack://application:,,,/"), "Fonts/#Segoe UI"); 
            else if (cbFont.SelectedIndex == 1) App.Current.Resources["CV Font"] = new FontFamily(new Uri("pack://application:,,,/"), "Fonts/#Arial"); 
            else if (cbFont.SelectedIndex == 2) App.Current.Resources["CV Font"] = new FontFamily(new Uri("pack://application:,,,/"), "Fonts/#Calibri"); 
            else if (cbFont.SelectedIndex == 3) App.Current.Resources["CV Font"] = new FontFamily(new Uri("pack://application:,,,/"), "Fonts/#Garamond"); 
            else if (cbFont.SelectedIndex == 4) App.Current.Resources["CV Font"] = new FontFamily(new Uri("pack://application:,,,/"), "Fonts/#Georgia"); 
            else if (cbFont.SelectedIndex == 5) App.Current.Resources["CV Font"] = new FontFamily(new Uri("pack://application:,,,/"), "Fonts/#Roboto"); 
            else if (cbFont.SelectedIndex == 6) App.Current.Resources["CV Font"] = new FontFamily(new Uri("pack://application:,,,/"), "Fonts/#Times New Roman"); 
            else if (cbFont.SelectedIndex == 7) App.Current.Resources["CV Font"] = new FontFamily(new Uri("pack://application:,,,/"), "Fonts/#Verdana"); 
        }
    }
}
