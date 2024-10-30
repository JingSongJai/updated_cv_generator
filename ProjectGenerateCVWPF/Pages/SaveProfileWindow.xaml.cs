using ProjectGenerateCVWPF.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static PdfSharp.Capabilities.Features;

namespace ProjectGenerateCVWPF.Pages
{
    /// <summary>
    /// Interaction logic for SaveProfileWindow.xaml
    /// </summary>
    public partial class SaveProfileWindow : Window
    {
        public ViewModel vm { get; set; }

        public string ImagePath { get; set; }
        public SaveProfileWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); 
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(tbProfileName.Text)) return;

            if (vm.Profile.ImagePath == "pack://application:,,,/Images/person.jpg" && Application.GetResourceStream(new Uri(vm.Profile.ImagePath)) != null)
            {
                using (FileStream fileStream = new FileStream("Images/" + tbProfileName.Text + ".jpg", FileMode.Create, FileAccess.Write))
                {
                    Application.GetResourceStream(new Uri(vm.Profile.ImagePath)).Stream.CopyTo(fileStream);
                }
            }
            else
            {
                if (File.Exists("Images/" + tbProfileName.Text + System.IO.Path.GetExtension(vm.Profile.ImagePath)))
                {
                    File.Delete("Images/" + tbProfileName.Text + System.IO.Path.GetExtension(vm.Profile.ImagePath));
                }
                File.Copy(vm.Profile.ImagePath, "Images/" + tbProfileName.Text + System.IO.Path.GetExtension(vm.Profile.ImagePath));
            }

            vm.Profile.ImagePath = AppDomain.CurrentDomain.BaseDirectory + "Images/" + tbProfileName.Text + System.IO.Path.GetExtension(vm.Profile.ImagePath);
            string jsonString = JsonSerializer.Serialize(vm, new JsonSerializerOptions() { WriteIndented = true });
            File.WriteAllText($"Profiles/{tbProfileName.Text}.json", jsonString);

            this.Close(); 
        }
    }
}
