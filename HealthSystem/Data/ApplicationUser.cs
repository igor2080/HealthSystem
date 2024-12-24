using Microsoft.AspNetCore.Identity;

namespace HealthSystem.Data
{

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
        public string? Intervals_API { get; set; }
    }

}
