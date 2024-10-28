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

            templates.Add(new string[] { "Template1", "pack://application:,,,/Images/Templates/template1.png" });
            templates.Add(new string[] { "Template2", "pack://application:,,,/Images/Templates/template1.png" });
            templates.Add(new string[] { "Template3", "pack://application:,,,/Images/Templates/template1.png" });
            templates.Add(new string[] { "Template4", "pack://application:,,,/Images/Templates/template1.png" });
            templates.Add(new string[] { "Template5", "pack://application:,,,/Images/Templates/template1.png" });
            templates.Add(new string[] { "Template6", "pack://application:,,,/Images/Templates/template1.png" });
            templates.Add(new string[] { "Template7", "pack://application:,,,/Images/Templates/template1.png" });
            templates.Add(new string[] { "Template8", "pack://application:,,,/Images/Templates/template1.png" });
            templates.Add(new string[] { "Template9", "pack://application:,,,/Images/Templates/template1.png" });
            templates.Add(new string[] { "Template10", "pack://application:,,,/Images/Templates/template1.png" });
            templates.Add(new string[] { "Template11", "pack://application:,,,/Images/Templates/template1.png" });
            templates.Add(new string[] { "Template12", "pack://application:,,,/Images/Templates/template1.png" });
            templates.Add(new string[] { "Template13", "pack://application:,,,/Images/Templates/template1.png" });
            templates.Add(new string[] { "Template14", "pack://application:,,,/Images/Templates/template1.png" });
            templates.Add(new string[] { "Template15", "pack://application:,,,/Images/Templates/template1.png" });
            templates.Add(new string[] { "Template16", "pack://application:,,,/Images/Templates/template1.png" });

            foreach(string[] template in templates)
            {
                panelDisplay.Children.Add(new Pages.TemplateInterfaceUserControl() { Image = new ImageBrush(new BitmapImage(new Uri(template[1]))) { Stretch = Stretch.UniformToFill }, Title = template[0] });
            }

            foreach(Pages.TemplateInterfaceUserControl template in panelDisplay.Children)
            {
                template.userClicked += userClicked_EventHandler; 
            }
        }

        private void userClicked_EventHandler(object sender, MouseButtonEventArgs e)
        {
            txtSelectedTemplate.Text = ((TemplateInterfaceUserControl)sender).Title; 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtSelectedTemplate.Text == "None") return; 

            SampleWindow sw = new SampleWindow(); 
            sw.TemplateName = txtSelectedTemplate.Text;
            sw.panelDisplay.Children.Add(getTemplate(txtSelectedTemplate.Text));
            sw.ShowDialog(); 
        }

        private Control getTemplate(string templateName)
        {
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
                    tmp.DataContext = App.sampleViewModel; 
                    break;
                case "Template5":
                    tmp = new CVTemplate5();
                    tmp.DataContext = App.sampleViewModel; 
                    break;

            }
            return tmp;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (txtSelectedTemplate.Text == "None") return;

            App.main.panelDisplay.Children.Clear();
            App.main.panelDisplay.Children.Add(new GenerateCVUserControl() { SelectedTemplate = txtSelectedTemplate.Text }); 
        }
    }
}
