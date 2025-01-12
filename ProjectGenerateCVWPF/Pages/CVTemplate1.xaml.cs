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
using System.Text.Json;
using System.IO;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace ProjectGenerateCVWPF.Pages
{
    /// <summary>
    /// Interaction logic for CVTemplate1.xaml
    /// </summary>
    public partial class CVTemplate1 : UserControl
    {
        public int maxSkill = 4;

        public ObservableCollection<ColorInfor> CVColor { get; set; }

        public CVTemplate1()
        {
            InitializeComponent();

            CVColor = new ObservableCollection<ColorInfor>()
            {
                new ColorInfor()
                {
                    Name = "Background1",
                    ColorBrush = new SolidColorBrush(Color.FromRgb(68, 84, 107))
                },
                new ColorInfor()
                {
                    Name = "Background2",
                    ColorBrush = new SolidColorBrush(Color.FromRgb(250, 250, 250))
                },
                new ColorInfor()
                {
                    Name = "Text1",
                    ColorBrush = new SolidColorBrush(Color.FromRgb(255, 255, 255))
                },
                new ColorInfor()
                {
                    Name = "Text2",
                    ColorBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0))
                },
            };
        }
    }
}
