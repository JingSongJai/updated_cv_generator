using ProjectGenerateCVWPF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for ReferenceUserControl.xaml
    /// </summary>
    public partial class ReferenceUserControl : UserControl
    {
        private ViewModel vm; 

        public ReferenceUserControl()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (borderDisplay.Visibility == Visibility.Collapsed) borderDisplay.Visibility = Visibility.Visible;
            else borderDisplay.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (referenceList.SelectedIndex != -1) vm.References.RemoveAt(referenceList.SelectedIndex); 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            vm.References.Add(new References()
            {
                Name = tbName.Text, 
                Company = tbCompany.Text,
                Email = tbEmail.Text,
                Phone = tbPhone.Text,
            });
            btnCancel_Click(null, null); 
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            tbName.Text = tbCompany.Text = tbEmail.Text = tbPhone.Text = ""; 
            borderDisplay.Visibility = Visibility.Collapsed;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            vm = (ViewModel)this.DataContext; 
        }
    }
}
