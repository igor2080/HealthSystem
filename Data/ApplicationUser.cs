using Microsoft.AspNetCore.Identity;

namespace HealthSystem.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string Name { get; set; }
        [PersonalData]
        public string Surname { get; set; }
        [PersonalData]
        public DateTime Date_of_birth { get; set; }
        [PersonalData]
        public string Gender { get; set; }
        [PersonalData]
        public float Height { get; set; }
    }

}
