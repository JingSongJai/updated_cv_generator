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

namespace ProjectGenerateCVWPF.Pages
{
    /// <summary>
    /// Interaction logic for CVTemplate1.xaml
    /// </summary>
    public partial class CVTemplate1 : UserControl
    {
        public int maxSkill = 4;

        public CVTemplate1()
        {
            InitializeComponent();
        }
    }
}
