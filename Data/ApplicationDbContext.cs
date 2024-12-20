using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthSystem.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<MedicalInformation> MedicalInformation { get; set; }
        public DbSet<InformationType> InformationType { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Recommendation> Recommendations { get; set; }
        public DbSet<TriggerParameter> TriggerParameters { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<InformationType>().HasData(
                new InformationType { Id = 1, Description = "Waist Size" },
                new InformationType { Id = 2, Description = "Blood Pressure" },
                new InformationType { Id = 3, Description = "Weight" },
                new InformationType { Id = 4, Description = "Resting Heart Rate" },
                new InformationType { Id = 5, Description = "CGM" },
                new InformationType { Id = 6, Description = "Insulin" },
                new InformationType { Id = 7, Description = "Triglyceride" },
                new InformationType { Id = 8, Description = "HDL Cholesterol" },
                new InformationType { Id = 9, Description = "LDL Cholesterol" },
                new InformationType { Id = 10, Description = "Metabolic Health" }
                );

            builder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole { Id = "2", Name = "User", NormalizedName = "USER" }
                );


        }
    }
}
