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
            this.DialogResult = false; 
            this.Close(); 
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(tbProfileName.Text)) return;

            if (vm.Profile.ImagePath == "pack://application:,,,/Images/person.jpg" && Application.GetResourceStream(new Uri(vm.Profile.ImagePath)) != null)
            {
                //using (FileStream fileStream = new FileStream("Images/" + tbProfileName.Text + ".jpg", FileMode.Create, FileAccess.Write))
                //{
                //    Application.GetResourceStream(new Uri(vm.Profile.ImagePath)).Stream.CopyTo(fileStream);
                //}
                var resourceStreamInfo = Application.GetResourceStream(new Uri(vm.Profile.ImagePath));

                if (resourceStreamInfo != null)
                {
                    using (resourceStreamInfo.Stream) // Dispose of the resource stream after use
                    using (FileStream fileStream = new FileStream("Images/" + tbProfileName.Text + ".jpg", FileMode.Create, FileAccess.Write))
                    {
                        resourceStreamInfo.Stream.CopyTo(fileStream);
                    }
                }
            }
            else
            {
                if (File.Exists("Images/" + tbProfileName.Text + System.IO.Path.GetExtension(vm.Profile.ImagePath)) && App.isAddNewImage)
                {
                    File.Delete("Images/" + tbProfileName.Text + System.IO.Path.GetExtension(vm.Profile.ImagePath));
                    File.Copy(vm.Profile.ImagePath, "Images/" + tbProfileName.Text + System.IO.Path.GetExtension(vm.Profile.ImagePath));
                }
                else if (!File.Exists("Images/" + tbProfileName.Text + System.IO.Path.GetExtension(vm.Profile.ImagePath)) && (App.isAddNewImage || !App.isAddNewImage)) File.Copy(vm.Profile.ImagePath, "Images/" + tbProfileName.Text + System.IO.Path.GetExtension(vm.Profile.ImagePath));
            }

            //vm.Profile.ImageSource = ImageSourceToBase64(vm.Profile.ImageSource); 
            vm.Profile.ImagePath = AppDomain.CurrentDomain.BaseDirectory + "Images/" + tbProfileName.Text + System.IO.Path.GetExtension(vm.Profile.ImagePath);
            string jsonString = JsonSerializer.Serialize(vm, new JsonSerializerOptions() { WriteIndented = true });
            File.WriteAllText($"Profiles/{tbProfileName.Text}.json", jsonString);

            App.isAddNewImage = false;
            this.DialogResult = true;
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(tbProfileName); 
        }

        public string ImageSourceToBase64(ImageSource imageSource)
        {
            if (imageSource is BitmapImage bitmapImage)
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    BitmapEncoder encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
                    encoder.Save(memoryStream);
                    byte[] imageBytes = memoryStream.ToArray();
                    return Convert.ToBase64String(imageBytes);
                }
            }
            return null;
        }
    }
}
