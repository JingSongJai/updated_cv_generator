using Org.BouncyCastle.Bcpg;
using ProjectGenerateCVWPF.Data;
using ProjectGenerateCVWPF.Pages;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;

namespace ProjectGenerateCVWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static MainWindow? main;
        public static TemplateMenuUserControl templateMenu = new TemplateMenuUserControl();
        public static int maxSkill = 0;
        internal static Data.ViewModel sampleViewModel;

        protected override async void OnStartup(StartupEventArgs e)
        {
            main = new MainWindow();
            sampleViewModel = new ViewModel()
            {
                Profile = new ProfileInformation()
                {
                    Name = "Phen Makara",
                    Phone = "012 345 678",
                    Email = "sothea.chanrith@gmail.com",
                    CurrentPlace = "Khan Chbar Ampov, Phnom Penh",
                    Nationality = "Khmer",
                    Gender = "Male",
                    //CustomGender = new ObservableCollection<string>()
                    //{
                    //    "Male",
                    //    "Female"
                    //},
                    PlaceofBirth = "Prey Veng Commune, Prey Veng District, Prey Veng Province",
                    MaritalState = "Married",
                    ImagePath = "pack://application:,,,/Images/makara.jpg",
                    IsProfileVisible = true,
                    AboutMe = "Aspiring mobile developer with skills in C#, C++, and Java, focused on Flutter. Passionate about user-friendly, efficient apps. Currently studying IT, eager to apply skills in impactful real-world projects."
                },
            };

            sampleViewModel.Educations.Add(new Data.Educations()
            {
                SchoolName = "Institute of Technology of Cambodia",
                StartYear = "2018",
                EndYear = "2022",
                MajorName = "Computer Science"
            });
            sampleViewModel.Educations.Add(new Data.Educations()
            {
                SchoolName = "Phnom Penh International University",
                StartYear = "2019",
                EndYear = "2023",
                MajorName = "Business Administration"
            });
            sampleViewModel.Educations.Add(new Data.Educations()
            {
                SchoolName = "Royal University of Phnom Penh",
                StartYear = "2022",
                EndYear = "Present",
                MajorName = "Information Technology (IT)"
            });

            sampleViewModel.Languages.Add(new Data.Languages()
            {
                Name = "English",
                Level = "Good"
            });
            sampleViewModel.Languages.Add(new Data.Languages()
            {
                Name = "Khmer",
                Level = "Fluent"
            });

            sampleViewModel.Hobbies.Add(new Data.Hobbies()
            {
                Name = "Cycling"
            });
            sampleViewModel.Hobbies.Add(new Data.Hobbies()
            {
                Name = "Photography"
            });
            sampleViewModel.Hobbies.Add(new Data.Hobbies()
            {
                Name = "Traveling"
            });

            sampleViewModel.Skills.Add(new Data.Skills() { Name = "Microsoft Words" });
            sampleViewModel.Skills.Add(new Data.Skills() { Name = "Microsoft Excel" });
            sampleViewModel.Skills.Add(new Data.Skills() { Name = "Microsoft PowerPoint" });

            sampleViewModel.WorkExperiences.Add(new Data.WorkExperiences()
            {
                JobName = "Software Developer",
                StartYear = "2021",
                EndYear = "Present",
                Responsibility = "Blue Lotus Technology",
                JobDescription = "Design and implement software solutions using JavaScript, Python, and Django. Collaborate with cross-functional teams to deliver scalable applications."
            });

            sampleViewModel.WorkExperiences.Add(new Data.WorkExperiences()
            {
                JobName = "IT Support Specialist",
                StartYear = "2019",
                EndYear = "2021",
                Responsibility = "MegaCorp Solutions",
                JobDescription = "Provided technical support for company-wide hardware and software issues. Assisted in network troubleshooting and maintenance."
            });

            sampleViewModel.WorkExperiences.Add(new Data.WorkExperiences()
            {
                JobName = "Junior/Business Consultant",
                StartYear = "2015",
                EndYear = "2020",
                Responsibility = "Timmerman Industries",
                JobDescription = "Developed, tested, and maintained web and mobile applications using C#, .NET, and JavaScript frameworks. Developed, tested, and maintained web"
            });

            sampleViewModel.References.Add(new Data.References()
            {
                Name = "Malis Phanith",
                Company = "TechBright Solutions/CTO",
                Phone = "Phone: 016-789-1234",
                Email = "Email: malis.phanith@techbright.com"
            });

            sampleViewModel.References.Add(new Data.References()
            {
                Name = "Visal Sok",
                Company = "InnovateX/Project Manager",
                Phone = "Phone: 023-456-7890",
                Email = "Email: visal.sok@innovatex.com"
            });

            //Pages.SplashScreen sc = new Pages.SplashScreen();
            //sc.Show();
            //await Task.Delay(5000);
            //sc.Close();
            main.Show();
        }

        public App()
        {
            Directory.CreateDirectory("Profiles");
            Directory.CreateDirectory("Images"); 
        }
    }

}
