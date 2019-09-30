namespace HolidayClub.Web.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum CorrespondencePreference
    {
        [Display(Name= "No Correspondence")]
        NoCorrespondence = 0,
        Post = 1,
        Email = 2
    }
}