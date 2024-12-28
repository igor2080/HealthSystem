using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static HealthSystem.Data.Utils;

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

            builder.Entity<Recommendation>().HasData(
                new Recommendation { Id = 1, Description = "Metabolic syndrome is a clustering of at least three of the following five medical conditions: abdominal obesity, high blood pressure, high blood sugar, high serum triglycerides, and low serum high-density lipoprotein (HDL). Metabolic syndrome is associated with the risk of developing cardiovascular disease and type 2 diabetes. In the U.S., about 25% of the adult population has metabolic syndrome, a proportion increasing with age, particularly among racial and ethnic minorities.", Study_Link = @"https://en.wikipedia.org/wiki/Metabolic_syndrome" },
                new Recommendation { Id = 2, Description = "Excess body weight and adiposity cause insulin resistance, inflammation, and numerous other alterations in metabolic and hormonal factors that promote atherosclerosis, tumorigenesis, neurodegeneration, and aging. Studies in both animals and humans have demonstrated a beneficial role of dietary restriction and leanness in promoting health and longevity.", Study_Link = @"https://pmc.ncbi.nlm.nih.gov/articles/PMC4032609/" },
                new Recommendation { Id = 3, Description = "There are two categories of normal blood pressure: Normal blood pressure is usually considered to be between 90/60 mmHg and 120/80 mmHg. For over-80s, because it's normal for arteries to get stiffer as we get older, the ideal blood pressure is under 150/90 mmHg (or 145/85 mmHg at home).", Study_Link = @"https://academic.oup.com/eurheartj/article/45/38/3912/7741010?login=false" },
                new Recommendation { Id = 4, Description = "Overweight and obesity may increase your risk for many health problems—especially if you carry extra fat around your waist. Reaching and staying at a healthy weight can help prevent these problems, stop them from getting worse, or even make them go away.", Study_Link = @"https://www.niddk.nih.gov/health-information/weight-management/adult-overweight-obesity/health-risks?dkrd=/health-information/weight-management/health-risks-overweight" },
                new Recommendation { Id = 5, Description = "Resting heart rate (RHR), a known cardiovascular risk factor, changes with age.", Study_Link = @"https://openheart.bmj.com/content/6/1/e000856" },
                new Recommendation { Id = 6, Description = "Regularly having high blood sugar levels for long periods of time (over months or years) can result in permanent damage to parts of the body such as the eyes, nerves, kidneys and blood vessels.", Study_Link = @"https://www.nhsinform.scot/illnesses-and-conditions/blood-and-lymph/hyperglycaemia-high-blood-sugar/" },
                new Recommendation { Id = 7, Description = "Hyperinsulinemia happens when you have a higher amount of insulin in your blood than what's considered normal due to insulin resistance. Your pancreas has to work harder to manage your blood sugar levels by releasing extra insulin.", Study_Link = @"https://my.clevelandclinic.org/health/diseases/24178-hyperinsulinemia" },
                new Recommendation { Id = 8, Description = "HDL is called \"good\" cholesterol because it helps prevent low-density lipoprotein (LDL) \"bad\" cholesterol and triglycerides from building up in the arteries. HDL picks up LDL in the blood and carries it to the liver. The liver breaks down LDL cholesterol, and it is passed from the body as waste.", Study_Link = @"https://www.mountsinai.org/health-library/tests/hdl-test" },
                new Recommendation { Id = 9, Description = "LDL is called \"bad\" cholesterol because it can build up and form fatty deposits (plaques) in the walls of your arteries.", Study_Link = @"https://www.mountsinai.org/health-library/tests/ldl-test" },
                new Recommendation { Id = 10, Description = "Having a high level of triglycerides in your blood can increase your risk of heart disease. But the same lifestyle choices that promote overall health can help lower your triglycerides, too.", Study_Link = @"https://www.mayoclinic.org/diseases-conditions/high-blood-cholesterol/in-depth/triglycerides/art-20048186" }
                );

            builder.Entity<TriggerParameter>().HasData(
                new TriggerParameter { Id = 1, RecommendationId = 1, InformationTypeId = 10, DynamicsScore = DynamicsScore.Stable },
                new TriggerParameter { Id = 2, RecommendationId = 1, InformationTypeId = 10, DynamicsScore = DynamicsScore.Degrading },
                new TriggerParameter { Id = 3, RecommendationId = 1, InformationTypeId = 10, DynamicsScore = DynamicsScore.Improving },
                new TriggerParameter { Id = 4, RecommendationId = 1, InformationTypeId = 10, DynamicsScore = DynamicsScore.Inconclusive },
                new TriggerParameter { Id = 5, RecommendationId = 2, InformationTypeId = 1, DynamicsScore = DynamicsScore.Stable },
                new TriggerParameter { Id = 6, RecommendationId = 2, InformationTypeId = 1, DynamicsScore = DynamicsScore.Degrading },
                new TriggerParameter { Id = 7, RecommendationId = 2, InformationTypeId = 1, DynamicsScore = DynamicsScore.Improving },
                new TriggerParameter { Id = 8, RecommendationId = 2, InformationTypeId = 1, DynamicsScore = DynamicsScore.Inconclusive },
                new TriggerParameter { Id = 9, RecommendationId = 3, InformationTypeId = 2, DynamicsScore = DynamicsScore.Stable },
                new TriggerParameter { Id = 10, RecommendationId = 3, InformationTypeId = 2, DynamicsScore = DynamicsScore.Degrading },
                new TriggerParameter { Id = 11, RecommendationId = 3, InformationTypeId = 2, DynamicsScore = DynamicsScore.Improving },
                new TriggerParameter { Id = 12, RecommendationId = 3, InformationTypeId = 2, DynamicsScore = DynamicsScore.Inconclusive },
                new TriggerParameter { Id = 13, RecommendationId = 4, InformationTypeId = 3, DynamicsScore = DynamicsScore.Stable },
                new TriggerParameter { Id = 14, RecommendationId = 4, InformationTypeId = 3, DynamicsScore = DynamicsScore.Degrading },
                new TriggerParameter { Id = 15, RecommendationId = 4, InformationTypeId = 3, DynamicsScore = DynamicsScore.Improving },
                new TriggerParameter { Id = 16, RecommendationId = 4, InformationTypeId = 3, DynamicsScore = DynamicsScore.Inconclusive },
                new TriggerParameter { Id = 17, RecommendationId = 5, InformationTypeId = 4, DynamicsScore = DynamicsScore.Stable },
                new TriggerParameter { Id = 18, RecommendationId = 5, InformationTypeId = 4, DynamicsScore = DynamicsScore.Degrading },
                new TriggerParameter { Id = 19, RecommendationId = 5, InformationTypeId = 4, DynamicsScore = DynamicsScore.Improving },
                new TriggerParameter { Id = 20, RecommendationId = 5, InformationTypeId = 4, DynamicsScore = DynamicsScore.Inconclusive },
                new TriggerParameter { Id = 21, RecommendationId = 6, InformationTypeId = 5, DynamicsScore = DynamicsScore.Stable },
                new TriggerParameter { Id = 22, RecommendationId = 6, InformationTypeId = 5, DynamicsScore = DynamicsScore.Degrading },
                new TriggerParameter { Id = 23, RecommendationId = 6, InformationTypeId = 5, DynamicsScore = DynamicsScore.Improving },
                new TriggerParameter { Id = 24, RecommendationId = 6, InformationTypeId = 5, DynamicsScore = DynamicsScore.Inconclusive },
                new TriggerParameter { Id = 25, RecommendationId = 7, InformationTypeId = 6, DynamicsScore = DynamicsScore.Stable },
                new TriggerParameter { Id = 26, RecommendationId = 7, InformationTypeId = 6, DynamicsScore = DynamicsScore.Degrading },
                new TriggerParameter { Id = 27, RecommendationId = 7, InformationTypeId = 6, DynamicsScore = DynamicsScore.Improving },
                new TriggerParameter { Id = 28, RecommendationId = 7, InformationTypeId = 6, DynamicsScore = DynamicsScore.Inconclusive },
                new TriggerParameter { Id = 29, RecommendationId = 8, InformationTypeId = 8, DynamicsScore = DynamicsScore.Stable },
                new TriggerParameter { Id = 30, RecommendationId = 8, InformationTypeId = 8, DynamicsScore = DynamicsScore.Degrading },
                new TriggerParameter { Id = 31, RecommendationId = 8, InformationTypeId = 8, DynamicsScore = DynamicsScore.Improving },
                new TriggerParameter { Id = 32, RecommendationId = 8, InformationTypeId = 8, DynamicsScore = DynamicsScore.Inconclusive },
                new TriggerParameter { Id = 33, RecommendationId = 9, InformationTypeId = 9, DynamicsScore = DynamicsScore.Stable },
                new TriggerParameter { Id = 34, RecommendationId = 9, InformationTypeId = 9, DynamicsScore = DynamicsScore.Degrading },
                new TriggerParameter { Id = 35, RecommendationId = 9, InformationTypeId = 9, DynamicsScore = DynamicsScore.Improving },
                new TriggerParameter { Id = 36, RecommendationId = 9, InformationTypeId = 9, DynamicsScore = DynamicsScore.Inconclusive },
                new TriggerParameter { Id = 37, RecommendationId = 10, InformationTypeId = 7, DynamicsScore = DynamicsScore.Stable },
                new TriggerParameter { Id = 38, RecommendationId = 10, InformationTypeId = 7, DynamicsScore = DynamicsScore.Degrading },
                new TriggerParameter { Id = 39, RecommendationId = 10, InformationTypeId = 7, DynamicsScore = DynamicsScore.Improving },
                new TriggerParameter { Id = 40, RecommendationId = 10, InformationTypeId = 7, DynamicsScore = DynamicsScore.Inconclusive }
                );

            builder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole { Id = "2", Name = "User", NormalizedName = "USER" }
                );


        }
    }
}
