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
        internal ViewModel vm = new ViewModel();
        private string ext = ".png"; 

        public string SelectedTemplate { get; set; }

        public GenerateCVUserControl()
        {
            InitializeComponent();

            panelDisplay.Children.Add(profilePage);
            setDataContexttoPages(); 

            getProfiles(); 
        }

        private void setDataContexttoPages()
        {
            profilePage.DataContext = vm;
            skillsPage.DataContext = vm;
            languagesPage.DataContext = vm;
            educationPage.DataContext = vm;
            workexperiencePage.DataContext = vm;
            referencePage.DataContext = vm;
        }

        private void getProfiles()
        {
            cbProfile.Items.Clear(); 
            string[] files = Directory.GetFiles("Profiles");

            if (files.Length == 0) return; 

            foreach(string file in files)
            {
                cbProfile.Items.Add(System.IO.Path.GetFileNameWithoutExtension(file));
            }
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

        public static async Task<BitmapSource> RenderControlToBitmapAsync(FrameworkElement control, double dpiX = 1300, double dpiY = 1300)
        {
            if (control == null) return null;

            // Render the control on the UI thread
            BitmapSource renderBitmap = await Application.Current.Dispatcher.InvokeAsync(() =>
            {
                Size size = new Size(control.ActualWidth, control.ActualHeight);
                control.Measure(size);
                control.Arrange(new Rect(size));

                RenderTargetBitmap bitmap = new RenderTargetBitmap(
                    (int)(control.ActualWidth * dpiX / 96),
                    (int)(control.ActualHeight * dpiY / 96),
                    dpiX,
                    dpiY,
                    PixelFormats.Pbgra32);

                bitmap.Render(control);
                return bitmap;
            });

            // Now, the bitmap is rendered and can be processed in a background thread
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
            App.Current.Resources["CV Font"] = new FontFamily(new Uri("pack://application:,,,/"), "Fonts/#Segoe UI");
            App.isAddNewImage = false; 
            App.main.panelDisplay.Children.Clear();
            App.main.panelDisplay.Children.Add(App.templateMenu); 
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            setDataContexttoPages(); 
            switch (SelectedTemplate)
            {
                case "Template1": 
                    CVTemplate1 template1 = new CVTemplate1();
                    panelCVDisplay.Children.Clear();
                    panelCVDisplay.Children.Add(template1);
                    template1.DataContext = vm;
                    //settingsPage.DefaultColor = template1.CVColor; 
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
                case "Template6": 
                    CVTemplate6 template6 = new CVTemplate6();
                    panelCVDisplay.Children.Clear();
                    panelCVDisplay.Children.Add(template6);
                    template6.DataContext = vm;
                    //App.maxSkill = template1.maxSkill; 
                    break; 
                case "Template7": 
                    CVTemplate7 template7 = new CVTemplate7();
                    panelCVDisplay.Children.Clear();
                    panelCVDisplay.Children.Add(template7);
                    template7.DataContext = vm;
                    //App.maxSkill = template1.maxSkill; 
                    break; 
                case "Template8": 
                    CVTemplate8 template8 = new CVTemplate8();
                    panelCVDisplay.Children.Clear();
                    panelCVDisplay.Children.Add(template8);
                    template8.DataContext = vm;
                    //App.maxSkill = template1.maxSkill; 
                    break;
                case "Template9": 
                    CVTemplate9 template9 = new CVTemplate9();
                    panelCVDisplay.Children.Clear();
                    panelCVDisplay.Children.Add(template9);
                    template9.DataContext = vm;
                    //App.maxSkill = template1.maxSkill; 
                    break;
                case "Template10": 
                    CVTemplate10 template10 = new CVTemplate10();
                    panelCVDisplay.Children.Clear();
                    panelCVDisplay.Children.Add(template10);
                    template10.DataContext = vm;
                    //App.maxSkill = template1.maxSkill; 
                    break;
                case "Template11": 
                    CVTemplate11 template11 = new CVTemplate11();
                    panelCVDisplay.Children.Clear();
                    panelCVDisplay.Children.Add(template11);
                    template11.DataContext = vm;
                    //App.maxSkill = template1.maxSkill; 
                    break;
                case "Template12": 
                    CVTemplate12 template12 = new CVTemplate12();
                    panelCVDisplay.Children.Clear();
                    panelCVDisplay.Children.Add(template12);
                    template12.DataContext = vm;
                    //App.maxSkill = template1.maxSkill; 
                    break;
                case "Template13": 
                    CVTemplate13 template13 = new CVTemplate13();
                    panelCVDisplay.Children.Clear();
                    panelCVDisplay.Children.Add(template13);
                    template13.DataContext = vm;
                    //App.maxSkill = template1.maxSkill; 
                    break;
                case "Template14": 
                    CVTemplate14 template14 = new CVTemplate14();
                    panelCVDisplay.Children.Clear();
                    panelCVDisplay.Children.Add(template14);
                    template14.DataContext = vm;
                    //App.maxSkill = template1.maxSkill; 
                    break;
                case "Template15": 
                    CVTemplate15 template15 = new CVTemplate15();
                    panelCVDisplay.Children.Clear();
                    panelCVDisplay.Children.Add(template15);
                    template15.DataContext = vm;
                    //App.maxSkill = template1.maxSkill; 
                    break;
                case "Template16": 
                    CVTemplate16 template16 = new CVTemplate16();
                    panelCVDisplay.Children.Clear();
                    panelCVDisplay.Children.Add(template16);
                    template16.DataContext = vm;
                    //App.maxSkill = template1.maxSkill; 
                    break;
                
            }
            settingsPage.DataContext = panelCVDisplay.Children[0];
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Title = "Save File",
                FileName = "cv_generator1",
                DefaultExt = "pdf",
                Filter = "PDF File|*.pdf",
                AddExtension = true
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                string path = saveFileDialog.FileName;
                loading.Visibility = Visibility.Visible;
                await SaveAsPdf(await RenderControlToBitmapAsync((Control)panelCVDisplay.Children[0]), path);
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
                case "Template6":
                    panelCVDisplay.Children.Clear();
                    panelCVDisplay.Children.Add(new CVTemplate6() { DataContext = vm });
                    break; 
                case "Template7":
                    panelCVDisplay.Children.Clear();
                    panelCVDisplay.Children.Add(new CVTemplate7() { DataContext = vm });
                    break; 
                case "Template8":
                    panelCVDisplay.Children.Clear();
                    panelCVDisplay.Children.Add(new CVTemplate8() { DataContext = vm });
                    break; 
                case "Template9":
                    panelCVDisplay.Children.Clear();
                    panelCVDisplay.Children.Add(new CVTemplate9() { DataContext = vm });
                    break; 
                case "Template10":
                    panelCVDisplay.Children.Clear();
                    panelCVDisplay.Children.Add(new CVTemplate10() { DataContext = vm });
                    break; 
                case "Template11":
                    panelCVDisplay.Children.Clear();
                    panelCVDisplay.Children.Add(new CVTemplate11() { DataContext = vm });
                    break; 
                case "Template12":
                    panelCVDisplay.Children.Clear();
                    panelCVDisplay.Children.Add(new CVTemplate12() { DataContext = vm });
                    break; 
                case "Template13":
                    panelCVDisplay.Children.Clear();
                    panelCVDisplay.Children.Add(new CVTemplate13() { DataContext = vm });
                    break; 
                case "Template14":
                    panelCVDisplay.Children.Clear();
                    panelCVDisplay.Children.Add(new CVTemplate14() { DataContext = vm });
                    break; 
                case "Template15":
                    panelCVDisplay.Children.Clear();
                    panelCVDisplay.Children.Add(new CVTemplate15() { DataContext = vm });
                    break;
                case "Template16":
                    panelCVDisplay.Children.Clear();
                    panelCVDisplay.Children.Add(new CVTemplate16() { DataContext = vm });
                    break;
                    
            }
            settingsPage.DataContext = panelCVDisplay.Children[0];
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
            //string curId = AutoID("Profiles").ToString(); 

            //string jsonString = JsonSerializer.Serialize(vm, new JsonSerializerOptions() { WriteIndented = true });
            //File.WriteAllText($"Profiles/{AutoID("Profiles")}.json", jsonString);

            //if (vm.Profile.ImagePath == "pack://application:,,,/Images/person.jpg" && Application.GetResourceStream(new Uri(vm.Profile.ImagePath)) != null)
            //{
            //    using (FileStream fileStream = new FileStream("Images/" + curId + ".jpg", FileMode.Create, FileAccess.Write))
            //    {
            //        Application.GetResourceStream(new Uri(vm.Profile.ImagePath)).Stream.CopyTo(fileStream);
            //    }
            //}
            //else File.Copy(vm.Profile.ImagePath, "Images/" + curId + Path.GetExtension(vm.Profile.ImagePath));

            if (new SaveProfileWindow() { vm = vm, ImagePath = vm.Profile.ImagePath }.ShowDialog() == true)
            {
                getProfiles();
            }

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

        private void cbProfile_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbProfile.SelectedIndex == -1) return;

            App.isAddNewImage = false; 

            string selectedName = cbProfile.SelectedItem.ToString();

            string jsonString = File.ReadAllText("Profiles/" + selectedName + ".json");

            vm = JsonSerializer.Deserialize<ViewModel>(jsonString);
            (panelCVDisplay.Children[0] as Control).DataContext = vm;

            setDataContexttoPages();
            profile.IsChecked = true; 
            profile_Click(profile, null); 
        }
    }
}
