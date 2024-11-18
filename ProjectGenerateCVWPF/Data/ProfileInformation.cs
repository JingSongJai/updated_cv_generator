using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ProjectGenerateCVWPF.Data
{
    public class ProfileInformation : PropertyChangeClass
    {
        private string? name, position, aboutme, nationality, gender, placeofbirth, maritalstate, phone, email, currentplace;
        private bool? isprofilevisible = false, isreferencevisible = true; 
        private string? dateofbirth;
        private string? imagePath;
        private ImageSource? imageSource; 

        public string? Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        public string? Position
        {
            get => position;
            set
            {
                position = value;
                OnPropertyChanged();
            }
        }
        public string? AboutMe
        {
            get => aboutme;
            set
            {
                aboutme = value;
                OnPropertyChanged();
            }
        }
        public string? Nationality
        {
            get => nationality;
            set
            {
                nationality = value;
                OnPropertyChanged();
            }
        }
        public string? Gender
        {
            get => gender;
            set
            {
                gender = value;
                OnPropertyChanged();
            }
        }
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
                OnPropertyChanged();
            }
        }
        
        public string? PlaceofBirth
        {
            get => placeofbirth;
            set
            {
                placeofbirth = value;
                OnPropertyChanged();
            }
        }
        public string? MaritalState
        {
            get => maritalstate;
            set
            {
                maritalstate = value;
                OnPropertyChanged();
            }
        }
        public string? Phone
        {
            get => phone;
            set
            {
                phone = value;
                OnPropertyChanged();
            }
        }
        public string? Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }
        public string? CurrentPlace
        {
            get => currentplace;
            set
            {
                currentplace = value;
                OnPropertyChanged();
            }
        }

        [JsonIgnore]
        public ImageSource? ImageSource
        {
            get { return imageSource; }
            set
            {
                if (imageSource != value)
                {
                    imageSource = value;
                    OnPropertyChanged(); 
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
                    OnPropertyChanged();
                    UpdateImageSource();
                }
            }
        }
        public bool? IsProfileVisible
        {
            get => isprofilevisible;
            set
            {
                isprofilevisible = value;
                OnPropertyChanged();
            }
        }
        public bool? IsReferenceVisible
        {
            get => isreferencevisible;
            set
            {
                isreferencevisible = value;
                OnPropertyChanged();
            }
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            UpdateImageSource();
        }

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

        public ProfileInformation()
        {
            //UpdateImageSource(); 
        }
    }
}
