using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace ProjectGenerateCVWPF.Utilities
{
    public class NumberToCornerRadius : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value; 
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int v)
            {
                if (v >= 0)
                {
                    return new CornerRadius(v);
                }
            }
            return new CornerRadius(10); 
        }
    }
}
