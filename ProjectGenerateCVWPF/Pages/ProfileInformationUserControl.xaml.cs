using Microsoft.Win32;
using ProjectGenerateCVWPF.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ProfileInformationUserControl.xaml
    /// </summary>
    public partial class ProfileInformationUserControl : UserControl
    {
        private ViewModel vm;

        public ProfileInformationUserControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Title = "Choose An Image",
                Multiselect = false,
                Filter = "JPG File|*.jpg|PNG File|*.png"
            };

            if (ofd.ShowDialog() == true)
            {
                btnAddImage.Tag = ofd.FileName;
                App.isAddNewImage = true; 
            }
        }

        private void btnRemoveImage_Click(object sender, RoutedEventArgs e)
        {
            btnAddImage.Tag = "pack://application:,,,/Images/person.jpg";
            App.isAddNewImage = true; 
        }

        private void comboboxGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
