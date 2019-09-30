namespace HolidayClub.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    using Enums;

    public class ContactDetailsViewModel
    {
        public string Title { get; set; }

        public string Forename { get; set; }

        [Required]
        public string Surname { get; set; }

        [Display(Name = "Relation to child")]
        public string RelationToChild { get; set; }

        public string Address { get; set; }

        public string Postcode { get; set; }

        [Display(Name = "Telephone number(s)")]
        public string TelephoneNumber1 { get; set; }
        public string TelephoneNumber2 { get; set; }
        public string TelephoneNumber3 { get; set; }

        [Display(Name = "Email address")]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Correspondence preference")]
        [Required]
        public CorrespondencePreference CorrespondencePreference { get; set; }

        [Display(Name = "Single parent?")]
        public SingleParentStatus SingleParentStatus { get; set; }

        [Display(Name = "Keep me informed?")]
        [Required]
        public bool IsToBeKeptInformed { get; set; }
    }
}
