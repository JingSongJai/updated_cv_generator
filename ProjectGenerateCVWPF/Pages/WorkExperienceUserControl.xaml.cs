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
    /// Interaction logic for WorkExperienceUserControl.xaml
    /// </summary>
    public partial class WorkExperienceUserControl : UserControl
    {
        private ViewModel vm; 

        public WorkExperienceUserControl()
        {
            InitializeComponent();
        }

        private void tbStartYear_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextNumeric(e.Text);
        }

        private bool IsTextNumeric(string text)
        {
            Regex regex = new Regex("[^0-9]+"); // Allow only digits
            return !regex.IsMatch(text);
        }

        private void cbPresent_Checked(object sender, RoutedEventArgs e)
        {
            tbEndYear.Text = "Present";
            tbEndYear.IsEnabled = false;
        }

        private void cbPresent_Unchecked(object sender, RoutedEventArgs e)
        {
            tbEndYear.Clear();
            tbEndYear.IsEnabled = true;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            vm.WorkExperiences.Add(new WorkExperiences()
            {
                JobName = tbJobName.Text, 
                Responsibility = tbResponsible.Text, 
                JobDescription = tbDescription.Text,
                StartYear = tbStartYear.Text,
                EndYear = tbEndYear.Text,
            });

            btnCancel_Click(null, null); 
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            vm = (ViewModel)this.DataContext; 
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (borderDisplay.Visibility == Visibility.Collapsed) borderDisplay.Visibility = Visibility.Visible;
            else borderDisplay.Visibility = Visibility.Collapsed;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            tbJobName.Text = tbDescription.Text = tbResponsible.Text = tbStartYear.Text = tbEndYear.Text = "";
            cbPresent.IsChecked = false; 

            borderDisplay.Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (experienceList.SelectedIndex == -1) vm.WorkExperiences.RemoveAt(experienceList.SelectedIndex); 
        }
    }
}
