using HealthSystem.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;

namespace HealthSystemTest
{
    public static class Globals
    {
        public const string AdminId = "64730bef-13d9-406d-8a78-080dbfabd411";
        public const string ConnectionString = @"Data Source=Data/HealthSysem.db";

        public static void InitializeUserData(TestContext self, TestServiceProvider Services)
        {
            //In case of error 14: unable to open the database file, check if bin/debug and bin/release contain Data/HealthSystem.db inside, automatic copying may be disabled to prevent overwriting
            Services.AddDbContextFactory<ApplicationDbContext>(options =>
                options.UseSqlite(Globals.ConnectionString));
            Services.AddCascadingAuthenticationState();
            Services.AddAuthentication(options =>
            {
                options.DefaultScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            })
                .AddIdentityCookies();
            var mockUserManager = MockUserManager<ApplicationUser>.Create();
            mockUserManager
                .Setup(um => um.FindByIdAsync(AdminId))
                .ReturnsAsync(new ApplicationUser { Id = AdminId, UserName = "Admin", Email = "admin@site.com", Date_of_birth = DateTime.Now.AddYears(-18), Gender = "male", Height = 183, Name = "Admin", Intervals_API = "5g93d03w93b7shop9aealuoac", Surname = "Site" });
            var userManagerMock = mockUserManager.Object;
            Services.AddScoped(_ => mockUserManager.Object);
            var authContext = self.AddTestAuthorization();
            authContext.SetAuthorizing();
            authContext.RegisterAuthorizationServices(Services);
            authContext.SetAuthorized("Admin");
            authContext.SetRoles("Admin");
            authContext.SetClaims(
                new System.Security.Claims.Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", AdminId)
                );
        }
    }
}
