using ProjectGenerateCVWPF.Pages;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectGenerateCVWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            panelDisplay.Children.Add(App.templateMenu); 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); 
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(WindowState == WindowState.Normal) WindowState = WindowState.Maximized; 
            else WindowState = WindowState.Normal;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, IntPtr wMsg, IntPtr wParam, IntPtr lParam);

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0); 
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            this.Close(); 
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            string name = ((RadioButton)sender).Name;

            switch (name)
            {
                case "templateMenu":
                    panelDisplay.Children.Clear();
                    panelDisplay.Children.Add(App.templateMenu);
                    break; 
                case "profileMenu":
                    panelDisplay.Children.Clear();
                    panelDisplay.Children.Add(new ProfileUserControl());
                    break; 
                case "aboutusMenu":
                    break; 

            }
        }
    }
}