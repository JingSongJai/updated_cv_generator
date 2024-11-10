using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ProjectGenerateCVWPF.Data
{
    public class ProfileInformation : INotifyPropertyChanged
    {
        private string? dateofbirth;
        private string? imagePath;
        private ImageSource? imageSource; 

        public string? Name { get; set; }
        public string? Position { get; set; }
        public string? AboutMe { get; set; }
        public string? Nationality { get; set; }
        public string? Gender { get; set; }
        public ObservableCollection<string> CustomGender { get; set; }
        public ObservableCollection<string> CustomMaritalState { get; set; } = new ObservableCollection<string>() { "Single", "Married", "Divorced" };
        public DateTime? DateofBirth
        {
            get
            {
                return String.IsNullOrEmpty(dateofbirth) ? (DateTime?)null : DateTime.Parse(dateofbirth);
            }
            set
            {
                if(value != null) dateofbirth = value.Value.ToShortDateString();
            }
        }
        public string? PlaceofBirth { get; set; }
        public string? MaritalState { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? CurrentPlace { get; set; }

        [JsonIgnore]
        public ImageSource? ImageSource
        {
            get { return imageSource; }
            set
            {
                if (imageSource != value)
                {
                    imageSource = value;
                    OnPropertyChanged(nameof(ImageSource)); // Notify change for ImageSource
                }
            }
        }
        public string? ImagePath
        {
            get { return imagePath; }
            set
            {
                if (imagePath != value)
                {
                    imagePath = value;
                    OnPropertyChanged(nameof(ImagePath)); // Notify change for ImagePath
                    UpdateImageSource(); // Update ImageSource when ImagePath changes
                }
            }
        }
        public bool? IsProfileVisible { get; set; } = false;
        public bool? IsReferenceVisible { get; set; } = true;

        private void UpdateImageSource()
        {
            if (!string.IsNullOrEmpty(ImagePath))
            {
                ImageSource = new Helper() { imagePath = ImagePath }.CopyImage(); // Update ImageSource
            }
            else
            {
                ImageSource = new Helper() { imagePath = "pack://application:,,,/Images/person.jpg" }.CopyImage(); // Fallback if ImagePath is empty
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ProfileInformation()
        {
            UpdateImageSource(); 
        }
    }
}
