using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGenerateCVWPF.Data
{
    public class ViewModel
    {
        public ObservableCollection<Skills> Skills { get; set; }
        public ObservableCollection<Languages> Languages { get; set; }
        public ObservableCollection<Hobbies> Hobbies { get; set; }
        public ProfileInformation Profile { get; set; }
        public ObservableCollection<Educations> Educations { get; set; }
        public ObservableCollection<WorkExperiences> WorkExperiences { get; set; }
        public ObservableCollection<References> References { get; set; }

        public ViewModel()
        {
            Skills = new ObservableCollection<Skills>();
            Languages = new ObservableCollection<Languages>();
            Hobbies = new ObservableCollection<Hobbies>();
            References = new ObservableCollection<References>();

            Profile = new ProfileInformation()
            {
                Name = "Phen Makara",
                Phone = "015 528 384",
                Email = "chingsong57@gmail.com",
                CurrentPlace = "Songkat Phnom Penh Tmey, Khan Sen Sok, Phnom Penh",
                Nationality = "Khmer",
                CustomGender = new ObservableCollection<string>()
                {
                    "Male",
                    "Female"
                },
                PlaceofBirth = "Preah Prasob Commune, Preah Prasob Villige, Khsach Kandal District, Kandal Province",
                MaritalState = "Single",
                ImagePath = "pack://application:,,,/Images/person.jpg"
            }; 
            Educations = new ObservableCollection<Educations>();
            WorkExperiences = new ObservableCollection<WorkExperiences>();

            Skills.Add(new Data.Skills() { Name = "Microsoft Words" });
            Skills.Add(new Data.Skills() { Name = "Microsoft Excel" });
            Skills.Add(new Data.Skills() { Name = "Microsoft PowerPoint" });

            Educations.Add(new Data.Educations()
            {
                SchoolName = "Royal University of Phnom Penh",
                StartYear = "2022",
                EndYear = "Present",
                MajorName = "Information Technology (IT)"
            });
            Educations.Add(new Data.Educations()
            {
                SchoolName = "Royal University of Phnom Penh",
                StartYear = "2022",
                EndYear = "Present",
                MajorName = "Information Technology (IT)"
            });
            Educations.Add(new Data.Educations()
            {
                SchoolName = "Royal University of Phnom Penh",
                StartYear = "2022",
                EndYear = "Present",
                MajorName = "Information Technology (IT)"
            });
            Educations.Add(new Data.Educations()
            {
                SchoolName = "Royal University of Phnom Penh",
                StartYear = "2022",
                EndYear = "Present",
                MajorName = "Information Technology (IT)"
            });

            Languages.Add(new Data.Languages()
            {
                Name = "English",
                Level = "Medium"
            });
            Languages.Add(new Data.Languages()
            {
                Name = "Khmer",
                Level = "Good"
            });

            Hobbies.Add(new Data.Hobbies()
            {
                Name = "Reading"
            });

            Hobbies.Add(new Data.Hobbies()
            {
                Name = "Researching"
            });

            Hobbies.Add(new Data.Hobbies()
            {
                Name = "Music"
            });

            WorkExperiences.Add(new Data.WorkExperiences()
            {
                JobName = "Junior/Business Consultant",
                StartYear = "2015",
                EndYear = "2020",
                Responsibility = "Timmerman Industries",
                JobDescription = "Developed, tested, and maintained web and mobile applications using C#, .NET, and JavaScript frameworks. Developed, tested, and maintained web"
            });

            WorkExperiences.Add(new Data.WorkExperiences()
            {
                JobName = "Junior/Business Consultant",
                StartYear = "2015",
                EndYear = "2020",
                Responsibility = "Timmerman Industries",
                JobDescription = "Developed, tested, and maintained web and mobile applications using C#, .NET, and JavaScript frameworks. Developed, tested, and maintained web"
            });

            WorkExperiences.Add(new Data.WorkExperiences()
            {
                JobName = "Junior/Business Consultant",
                StartYear = "2015",
                EndYear = "2020",
                Responsibility = "Timmerman Industries",
                JobDescription = "Developed, tested, and maintained web and mobile applications using C#, .NET, and JavaScript frameworks. Developed, tested, and maintained web"
            });

            WorkExperiences.Add(new Data.WorkExperiences()
            {
                JobName = "Junior/Business Consultant",
                StartYear = "2015",
                EndYear = "2020",
                Responsibility = "Timmerman Industries",
                JobDescription = "Developed, tested, and maintained web and mobile applications using C#, .NET, and JavaScript frameworks. Developed, tested, and maintained web"
            });

            References.Add(new Data.References()
            {
                Name = "Harumi Kobayashi",
                Company = "Wardiere Inc./CEO",
                Email = "Email: example@gmail.com"
            });

            References.Add(new Data.References()
            {
                Name = "Harumi Kobayashi",
                Company = "Wardiere Inc./CEO",
                Phone = "Phone: 122-456-7890",
                Email = "Email: example@gmail.com"
            });
        }
    }
}
