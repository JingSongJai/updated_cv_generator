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
    /// Interaction logic for SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : Window
    {
        public string Title
        {
            get { return txtTeamName.Text; }
            set { txtTeamName.Text = value; }
        }

        public SplashScreen()
        {
            InitializeComponent();
        }

        private async Task showTeamName()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                txtTeamName.Text += "G ";

                Thread.Sleep(200);

                txtTeamName.Text += "R ";

                Thread.Sleep(200);

                txtTeamName.Text += "O ";

                Thread.Sleep(200);

                txtTeamName.Text += "U ";

                Thread.Sleep(200);

                txtTeamName.Text += "P ";

                Thread.Sleep(200);

                txtTeamName.Text += "6 ";
            });
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //await Task.Run(() => showTeamName());
        }
    }
}
