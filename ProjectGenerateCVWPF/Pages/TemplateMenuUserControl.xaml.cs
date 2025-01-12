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
    /// Interaction logic for TemplateMenuUserControl.xaml
    /// </summary>
    public partial class TemplateMenuUserControl : UserControl
    {
        public TemplateMenuUserControl()
        {
            InitializeComponent();
            List<string[]> templates = new List<string[]>();

            templates.Add(new string[] { "Template1", "pack://application:,,,/Images/1.png" });
            templates.Add(new string[] { "Template2", "pack://application:,,,/Images/2.png" });
            templates.Add(new string[] { "Template3", "pack://application:,,,/Images/3.png" });
            templates.Add(new string[] { "Template4", "pack://application:,,,/Images/4.png" });
            templates.Add(new string[] { "Template5", "pack://application:,,,/Images/5.png" });
            templates.Add(new string[] { "Template6", "pack://application:,,,/Images/6.png" });
            templates.Add(new string[] { "Template7", "pack://application:,,,/Images/7.png" });
            templates.Add(new string[] { "Template8", "pack://application:,,,/Images/8.png" });
            templates.Add(new string[] { "Template9", "pack://application:,,,/Images/9.png" });
            templates.Add(new string[] { "Template10", "pack://application:,,,/Images/10.png" });
            templates.Add(new string[] { "Template11", "pack://application:,,,/Images/11.png" });
            templates.Add(new string[] { "Template12", "pack://application:,,,/Images/12.png" });
            templates.Add(new string[] { "Template13", "pack://application:,,,/Images/13.png" });
            templates.Add(new string[] { "Template14", "pack://application:,,,/Images/14.png" });
            templates.Add(new string[] { "Template15", "pack://application:,,,/Images/15.png" });
            templates.Add(new string[] { "Template16", "pack://application:,,,/Images/16.png" });

            foreach(string[] template in templates)
            {
                panelDisplay.Children.Add(new Pages.TemplateInterfaceUserControl() { Image = new ImageBrush(new BitmapImage(new Uri(template[1]))) { Stretch = Stretch.Uniform }, Title = template[0] });
            }

            foreach(Pages.TemplateInterfaceUserControl template in panelDisplay.Children)
            {
                template.userClicked += userClicked_EventHandler; 
            }
        }

        private void userClicked_EventHandler(object sender, MouseButtonEventArgs e)
        {
            string selectedTemplateName = ((TemplateInterfaceUserControl)sender).Title;
            SampleWindow sw = new SampleWindow() { TemplateName = selectedTemplateName };

            sw.panelDisplay.Children.Clear(); 
            sw.panelDisplay.Children.Add(getTemplate(selectedTemplateName));
            sw.ShowDialog(); 
        }

        private Control getTemplate(string templateName)
        {
            App.sampleViewModel.Profile.IsProfileVisible = true;
            Control tmp = new Control();

            switch (templateName)
            {
                case "Template1":
                    tmp = new CVTemplate1();
                    tmp.DataContext = App.sampleViewModel; 
                    break;
                case "Template2":
                    tmp = new CVTemplate2();
                    tmp.DataContext = App.sampleViewModel; 
                    break;
                case "Template3":
                    tmp = new CVTemplate3();
                    tmp.DataContext = App.sampleViewModel; 
                    break;
                case "Template4":
                    tmp = new CVTemplate4();
                    App.sampleViewModel.Profile.IsProfileVisible = false;
                    tmp.DataContext = App.sampleViewModel; 
                    break;
                case "Template5":
                    tmp = new CVTemplate5();
                    tmp.DataContext = App.sampleViewModel; 
                    break;
                case "Template6":
                    tmp = new CVTemplate6();
                    tmp.DataContext = App.sampleViewModel; 
                    break;
                case "Template7":
                    tmp = new CVTemplate7();
                    tmp.DataContext = App.sampleViewModel; 
                    break;
                case "Template8":
                    tmp = new CVTemplate8();
                    App.sampleViewModel.Profile.IsProfileVisible = false;
                    tmp.DataContext = App.sampleViewModel; 
                    break;
                case "Template9":
                    tmp = new CVTemplate9();
                    tmp.DataContext = App.sampleViewModel; 
                    break;
                case "Template10":
                    tmp = new CVTemplate10();
                    tmp.DataContext = App.sampleViewModel; 
                    break;
                case "Template11":
                    tmp = new CVTemplate11();
                    tmp.DataContext = App.sampleViewModel; 
                    break;
                case "Template12":
                    tmp = new CVTemplate12();
                    tmp.DataContext = App.sampleViewModel; 
                    break;
                case "Template13":
                    tmp = new CVTemplate13();
                    tmp.DataContext = App.sampleViewModel; 
                    break;
                case "Template14":
                    tmp = new CVTemplate14();
                    tmp.DataContext = App.sampleViewModel; 
                    break;
                case "Template15":
                    tmp = new CVTemplate15();
                    tmp.DataContext = App.sampleViewModel; 
                    break;
                case "Template16":
                    tmp = new CVTemplate16();
                    tmp.DataContext = App.sampleViewModel;
                    break;

            }
            return tmp;
        }
    }
}
