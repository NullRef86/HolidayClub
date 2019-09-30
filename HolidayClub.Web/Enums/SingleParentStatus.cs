namespace HolidayClub.Web.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum SingleParentStatus
    {
        [Display(Name= "Not specified")]
        NotSpecified = 0,
        Yes = 1,
        No = 2
    }
}