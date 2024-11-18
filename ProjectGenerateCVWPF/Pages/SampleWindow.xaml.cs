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
using System.Windows.Shapes;

namespace ProjectGenerateCVWPF.Pages
{
    /// <summary>
    /// Interaction logic for SampleWindow.xaml
    /// </summary>
    public partial class SampleWindow : Window
    {
        private int index; 
        public string TemplateName
        {
            get { return txtTemplateName.Text; }
            set { txtTemplateName.Text = value; }
        }

        public SampleWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove(); 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); 
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            App.main.panelDisplay.Children.Clear();
            App.main.panelDisplay.Children.Add(new GenerateCVUserControl() { SelectedTemplate = "Template" + index });
            this.Close(); 
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (index != 16)
            {
                index++;
                changeTemplate();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (index != 1)
            {
                index--;
                changeTemplate();
            }
        }

        private void changeTemplate()
        {
            panelDisplay.Children.Clear();
            panelDisplay.Children.Add(getTemplate("Template" + index));
            txtTemplateName.Text = "Template" + index; 
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            index = int.Parse(TemplateName.Replace("Template", ""));
        }
    }
}
