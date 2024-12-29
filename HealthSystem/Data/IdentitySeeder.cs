using Microsoft.AspNetCore.Identity;

namespace HealthSystem.Data
{
    public static class IdentitySeeder
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            if (!await roleManager.RoleExistsAsync("User"))
            {
                await roleManager.CreateAsync(new IdentityRole("User"));
            }

            var adminEmail = "admin@site.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true,
                    Gender = "Male",
                    Date_of_birth = DateTime.UtcNow,
                    Name = "Admin",
                    Surname = "Admin",
                    Height=100,
                };
                await userManager.CreateAsync(adminUser, "123123"); 
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }

        }
    }

}
