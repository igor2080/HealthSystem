using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthSystem.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<MedicalInformation> MedicalInformation { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Recommendation> Recommendations { get; set; }
        public DbSet<TriggerParameter> TriggerParameters { get; set; }
    }
}
