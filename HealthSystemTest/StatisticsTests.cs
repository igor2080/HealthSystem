using HealthSystem.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HealthSystem.Components.Pages;
using Moq;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Linq;
using System;
using System.Collections.Generic;

namespace HealthSystemTest
{
    public class StatisticsTests : TestContext
    {
        [Fact]
        public void IsFileDownloadCorrect()
        {
            Globals.InitializeUserData(this,Services);
            /////////////////
        }
    }
}
