using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ProjectGenerateCVWPF
{
    public class Helper
    {
        public string imagePath; 

        public ImageSource CopyImage()
        {
            BitmapImage image = new BitmapImage();

            image.BeginInit();
            image.UriSource = new Uri(imagePath);
            image.CacheOption = BitmapCacheOption.OnLoad;  // Ensure it's cached fully when loaded
            image.EndInit();

            ImageBrush copyImage = new ImageBrush(image);
            return copyImage.ImageSource;
        }
    }
}
