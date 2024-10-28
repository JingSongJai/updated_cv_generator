using ProjectGenerateCVWPF.Data;
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
    /// Interaction logic for LanguageUserControl.xaml
    /// </summary>
    public partial class LanguageUserControl : UserControl
    {
        private ViewModel vm; 
        public LanguageUserControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = (sender as Button).Name;
            if (name == "btnAdd")
            {
                if (borderDisplay.Visibility == Visibility.Collapsed) borderDisplay.Visibility = Visibility.Visible;
                else borderDisplay.Visibility = Visibility.Collapsed;
            }
            else borderDisplay.Visibility = Visibility.Collapsed; 
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            vm.Languages.Add(new Languages()
            {
                Name = tbLanguageName.Text,
                Level = cbLevel.Text
            });
            borderDisplay.Visibility = Visibility.Collapsed;
            tbLanguageName.Text = "";
            cbLevel.SelectedIndex = 0; 
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            vm = (ViewModel)this.DataContext; 
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if(languagesList.SelectedIndex != -1) vm.Languages.RemoveAt(languagesList.SelectedIndex);
        }
    }
}
