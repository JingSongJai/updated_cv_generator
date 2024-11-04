using ProjectGenerateCVWPF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
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
    /// Interaction logic for SkillsUserControl.xaml
    /// </summary>
    public partial class SkillsUserControl : UserControl
    {
        private ViewModel vm;
        public SkillsUserControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (skillsList.SelectedIndex == -1) return; 
            vm.Skills.RemoveAt(skillsList.SelectedIndex);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            vm = this.DataContext as ViewModel; 
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (borderDisplay.Visibility == Visibility.Collapsed) borderDisplay.Visibility = Visibility.Visible;
            else borderDisplay.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            vm.Skills.Add(new Skills() { Name = tbSkillName.Text });
            tbSkillName.Clear();
            borderDisplay.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            borderDisplay.Visibility = Visibility.Collapsed;
            tbSkillName.Clear();
        }
    }
}
