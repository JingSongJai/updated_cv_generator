using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGenerateCVWPF.Data
{
    public class ProfileInformation
    {
        private string? dateofbirth; 

        public string? Name {  get; set; }
        public string? Position {  get; set; }
        public string? AboutMe {  get; set; }
        public string? Nationality { get; set; }
        public string? Gender { get; set; }
        public ObservableCollection<string> CustomGender { get; set; }
        public DateTime? DateofBirth { get { return String.IsNullOrEmpty(dateofbirth) ? (DateTime?)null : DateTime.Parse(dateofbirth); } set { dateofbirth = value.Value.ToShortDateString(); } }
        public string? PlaceofBirth { get; set; }
        public string? MaritalState { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? CurrentPlace { get; set; }
        public string? ImagePath { get; set; }
        public bool? IsProfileVisible { get; set; } = true;
        public bool? IsReferenceVisible { get; set; } = true;
    }
}
