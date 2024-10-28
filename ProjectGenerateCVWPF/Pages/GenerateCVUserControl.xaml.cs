using Microsoft.Win32;
using PdfSharp.Drawing;
using ProjectGenerateCVWPF.Data;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ProjectGenerateCVWPF.Pages
{
    /// <summary>
    /// Interaction logic for GenerateCVUserControl.xaml
    /// </summary>
    public partial class GenerateCVUserControl : UserControl
    {
        private ProfileInformationUserControl profilePage = new ProfileInformationUserControl();
        private SkillsUserControl skillsPage = new SkillsUserControl();
        private LanguageUserControl languagesPage = new LanguageUserControl();
        private EducationUserControl educationPage = new EducationUserControl();
        private WorkExperienceUserControl workexperiencePage = new WorkExperienceUserControl();
        private ReferenceUserControl referencePage = new ReferenceUserControl();
        private SettingsUserControl settingsPage = new SettingsUserControl();
        private ViewModel vm = new ViewModel();
        private string ext = ".png"; 

        public string SelectedTemplate { get; set; }

        public GenerateCVUserControl()
        {
            InitializeComponent();
            
            profilePage.DataContext = vm; 
            skillsPage.DataContext = vm;
            languagesPage.DataContext = vm;
            educationPage.DataContext = vm;
            workexperiencePage.DataContext = vm;
            referencePage.DataContext = vm;
            panelDisplay.Children.Add(profilePage);
            
        }

        public async Task SaveAsPdf(BitmapSource bitmap, string outputPath)
        {
            if (bitmap.CanFreeze)
            {
                bitmap.Freeze();
            }

            await Task.Run(() =>
            {
                // Create a new PDF document
                PdfSharp.Pdf.PdfDocument document = new PdfSharp.Pdf.PdfDocument();
                PdfSharp.Pdf.PdfPage page = document.AddPage();

                // Set the page size to A4
                page.Size = PdfSharp.PageSize.A4;

                XGraphics gfx = XGraphics.FromPdfPage(page);

                using (MemoryStream ms = new MemoryStream())
                {
                    PngBitmapEncoder encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(bitmap));
                    encoder.Save(ms);

                    XImage image = XImage.FromStream(ms);

                    // A4 size in points (300 DPI A4: 2480x3508 pixels)
                    double pageWidthInPoints = XUnit.FromMillimeter(210).Point;
                    double pageHeightInPoints = XUnit.FromMillimeter(297).Point;

                    // Draw the image onto the PDF page, scaling it to fit the A4 size
                    gfx.DrawImage(image, 0, 0, pageWidthInPoints, pageHeightInPoints);
                }

                // Save the PDF
                document.Save(outputPath);
                document.Close();
            });
        }

        public static BitmapSource RenderControlToBitmap(FrameworkElement control, double dpiX = 1200, double dpiY = 1200)
        {
            if (control == null) return null;

            Size size = new Size(control.ActualWidth, control.ActualHeight);
            control.Measure(size);
            control.Arrange(new Rect(size));

            RenderTargetBitmap renderBitmap = new RenderTargetBitmap(
                (int)(control.ActualWidth * dpiX / 96),
                (int)(control.ActualHeight * dpiY / 96),
                dpiX,
                dpiY,
                PixelFormats.Pbgra32);

            renderBitmap.Render(control);
            return renderBitmap;
        }

        private void profile_Click(object sender, RoutedEventArgs e)
        {
            string name = ((RadioButton)sender).Name;

            switch (name)
            {
                case "profile":
                    panelDisplay.Children.Clear();
                    panelDisplay.Children.Add(profilePage);
                    break;
                case "skills": 
                    panelDisplay.Children.Clear();
                    panelDisplay.Children.Add(skillsPage);
                    break;
                case "languages": 
                    panelDisplay.Children.Clear();
                    panelDisplay.Children.Add(languagesPage);
                    break;
                case "educations": 
                    panelDisplay.Children.Clear();
                    panelDisplay.Children.Add(educationPage);
                    break;
                case "experiences": 
                    panelDisplay.Children.Clear();
                    panelDisplay.Children.Add(workexperiencePage);
                    break;
                case "references": 
                    panelDisplay.Children.Clear();
                    panelDisplay.Children.Add(referencePage);
                    break;
                case "settings": 
                    panelDisplay.Children.Clear();
                    panelDisplay.Children.Add(settingsPage);
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.main.panelDisplay.Children.Clear();
            App.main.panelDisplay.Children.Add(App.templateMenu); 
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            switch (SelectedTemplate)
            {
                case "Template1": 
                    CVTemplate1 template1 = new CVTemplate1();
                    panelCVDisplay.Children.Clear();
                    panelCVDisplay.Children.Add(template1);
                    template1.DataContext = vm;
                    //App.maxSkill = template1.maxSkill; 
                    break; 
                case "Template2": 
                    CVTemplate2 template2 = new CVTemplate2();
                    panelCVDisplay.Children.Clear();
                    panelCVDisplay.Children.Add(template2);
                    template2.DataContext = vm;
                    //App.maxSkill = template1.maxSkill; 
                    break; 
                case "Template3": 
                    CVTemplate3 template3 = new CVTemplate3();
                    panelCVDisplay.Children.Clear();
                    panelCVDisplay.Children.Add(template3);
                    template3.DataContext = vm;
                    //App.maxSkill = template1.maxSkill; 
                    break; 
                case "Template4": 
                    CVTemplate4 template4 = new CVTemplate4();
                    panelCVDisplay.Children.Clear();
                    panelCVDisplay.Children.Add(template4);
                    template4.DataContext = vm;
                    //App.maxSkill = template1.maxSkill; 
                    break; 
                case "Template5": 
                    CVTemplate5 template5 = new CVTemplate5();
                    panelCVDisplay.Children.Clear();
                    panelCVDisplay.Children.Add(template5);
                    template5.DataContext = vm;
                    //App.maxSkill = template1.maxSkill; 
                    break; 
            }
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Title = "Save File",
                FileName = "cv_generator1",
                DefaultExt = "pdf",
                AddExtension = true
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                string path = saveFileDialog.FileName;
                loading.Visibility = Visibility.Visible;
                await Task.Run(() => SaveAsPdf(RenderControlToBitmap((Control)panelCVDisplay.Children[0]), path));
            }
            loading.Visibility = Visibility.Collapsed;
        }

        private void cbTemplate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string choice = "Template" + (cbTemplate.SelectedIndex + 1).ToString();

            switch (choice)
            {
                case "Template1":
                    panelCVDisplay.Children.Clear();
                    panelCVDisplay.Children.Add(new CVTemplate1() { DataContext = vm });
                    break; 
                case "Template2":
                    panelCVDisplay.Children.Clear();
                    panelCVDisplay.Children.Add(new CVTemplate2() { DataContext = vm });
                    break; 
                case "Template3":
                    panelCVDisplay.Children.Clear();
                    panelCVDisplay.Children.Add(new CVTemplate3() { DataContext = vm });
                    break; 
                case "Template4":
                    panelCVDisplay.Children.Clear();
                    panelCVDisplay.Children.Add(new CVTemplate4() { DataContext = vm });
                    break; 
                case "Template5":
                    panelCVDisplay.Children.Clear();
                    panelCVDisplay.Children.Add(new CVTemplate5() { DataContext = vm });
                    break; 

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

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

        private void btnSaveProfile_Click(object sender, RoutedEventArgs e)
        {
            string curId = AutoID("Profiles").ToString(); 

            string jsonString = JsonSerializer.Serialize(vm, new JsonSerializerOptions() { WriteIndented = true });
            File.WriteAllText($"Profiles/{AutoID("Profiles")}.json", jsonString);

            if (vm.Profile.ImagePath == "pack://application:,,,/Images/person.jpg" && Application.GetResourceStream(new Uri(vm.Profile.ImagePath)) != null)
            {
                using (FileStream fileStream = new FileStream("Images/" + curId + ".jpg", FileMode.Create, FileAccess.Write))
                {
                    Application.GetResourceStream(new Uri(vm.Profile.ImagePath)).Stream.CopyTo(fileStream);
                }
            }
            else File.Copy(vm.Profile.ImagePath, "Images/" + curId + Path.GetExtension(vm.Profile.ImagePath));
        }

        private int AutoID(string path)
        {
            List<int> tmp = new List<int>();
            string[] files = Directory.GetFiles(path);

            if (files.Length == 0) return 1;

            foreach (string file in files)
            {
                tmp.Add(int.Parse(System.IO.Path.GetFileNameWithoutExtension(file)));
            }

            return tmp.Max() + 1; 
        }

        private string getExtension(string fileName)
        {
            string ext = "";
            string[] files = Directory.GetFiles("Images");
            foreach (string file in files)
            {
                if (Path.GetFileNameWithoutExtension(file) == fileName)
                {
                    ext = Path.GetExtension(file);
                    break;
                }
            }
            return ext;
        }
    }
}
