namespace HolidayClub.Web.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<ContactDetails> ContailDetails { get; set; }
    }

    public class ContactDetails
    {
        public int Id { get; set; }
        public string AspNetUserId { get; set; }

        public string Title { get; set; }

        public string Forename { get; set; }

        public string Surname { get; set; }

        public string RelationToChild { get; set; }

        public string Address { get; set; }

        public string Postcode { get; set; }

        public string TelephoneNumber1 { get; set; }
        public string TelephoneNumber2 { get; set; }
        public string TelephoneNumber3 { get; set; }

        public string Email { get; set; }

        public string CorrespondencePreference { get; set; }

        public bool? IsSingleParent { get; set; }

        public bool IsToBeKeptInformed { get; set; }
    }
}
