using Microsoft.AspNetCore.Identity;
using Moq;
using System.Collections.Generic;

namespace HealthSystemTest
{
    public class MockUserManager<TUser> where TUser : class
    {
        public static Mock<UserManager<TUser>> Create()
        {
            var store = new Mock<IUserStore<TUser>>();
            var userManager = new Mock<UserManager<TUser>>(
                store.Object,
                null, // OptionsAccessor
                null, // PasswordHasher
                new List<IUserValidator<TUser>>().ToArray(),
                new List<IPasswordValidator<TUser>>().ToArray(),
                null, // KeyNormalizer
                null, // Errors
                null, // TokenProvider
                null  // HttpContextAccessor
            );

            return userManager;
        }
    }
}