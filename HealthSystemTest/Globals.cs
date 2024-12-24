using HealthSystem.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSystemTest
{
    public static class Globals
    {
        public const string AdminId = "64730bef-13d9-406d-8a78-080dbfabd411";
        public const string ConnectionString = @"Data Source=Data/HealthSysem.db";

        public static void InitializeUserData(TestContext self, TestServiceProvider Services)
        {
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
                .Setup(um => um.FindByIdAsync(Globals.AdminId))
                .ReturnsAsync(new ApplicationUser { Id = Globals.AdminId, UserName = "Admin" });
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
