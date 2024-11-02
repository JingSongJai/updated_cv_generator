using ProjectGenerateCVWPF.Data;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace ProjectGenerateCVWPF.Pages
{
    /// <summary>
    /// Interaction logic for ProfileItem.xaml
    /// </summary>
    public partial class ProfileItem : UserControl
    {
        public string Title
        {
            get => txtTitle.Text; 
            set => txtTitle.Text = value; 
        }

        public ProfileItem()
        {
            InitializeComponent();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            File.Delete("Profiles/" + Title + ".json");
            File.Delete("Images/" + Title + getExtension(Title));

            App.main.panelDisplay.Children.Clear();
            App.main.panelDisplay.Children.Add(new ProfileUserControl()); 
        }

        private string getExtension(string fileName)
        {
            string ext = "";
            string[] files = Directory.GetFiles("Images");
            foreach (string file in files)
            {
                if (System.IO.Path.GetFileNameWithoutExtension(file) == fileName)
                {
                    ext = System.IO.Path.GetExtension(file);
                    break;
                }
            }
            return ext;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            string jsonString = File.ReadAllText("Profiles/" + Title + ".json");

            App.main.panelDisplay.Children.Clear();
            App.main.panelDisplay.Children.Add(new GenerateCVUserControl() { SelectedTemplate = "Template1", vm = JsonSerializer.Deserialize<ViewModel>(jsonString) });

            App.main.templateMenu.IsChecked = true; 
        }
    }
}
