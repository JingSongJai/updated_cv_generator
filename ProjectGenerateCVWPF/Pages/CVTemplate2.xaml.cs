using ProjectGenerateCVWPF.Data;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ProjectGenerateCVWPF.Pages
{
    /// <summary>
    /// Interaction logic for CVTemplate2.xaml
    /// </summary>
    public partial class CVTemplate2 : UserControl
    {
        public ObservableCollection<ColorInfor> CVColor { get; set; }

        public CVTemplate2()
        {
            InitializeComponent();

            CVColor = new ObservableCollection<ColorInfor>()
            {
                new ColorInfor()
                {
                    Name = "Background1",
                    ColorBrush = new SolidColorBrush(Color.FromRgb(69, 80, 100))
                },
                new ColorInfor()
                {
                    Name = "Background2",
                    ColorBrush = new SolidColorBrush(Color.FromRgb(171, 171, 171))
                },
                new ColorInfor()
                {
                    Name = "Background3",
                    ColorBrush = new SolidColorBrush(Color.FromRgb(255, 255, 255))
                },
                new ColorInfor()
                {
                    Name = "Text1",
                    ColorBrush = new SolidColorBrush(Color.FromRgb(16, 25, 69))
                },
            };
        }
    }
}
