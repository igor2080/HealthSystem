using HealthSystem.Data;
using System.Linq;
using System;

namespace HealthSystemTest
{
    public class StatisticsTests : TestContext
    {
        [Fact]
        public void VerifyFileDownloadHappening()
        {
            Globals.InitializeUserData(this,Services);
            Services.AddScoped<EmailService>();
            var setup = JSInterop.SetupVoid("downloadCurrentPageGraph", "Admin Site stats.png");
            var cut = RenderComponent<HealthSystem.Components.Pages.Statistics.Index>();
            var downloadButton = cut.FindAll("button").First(x => x.TextContent.Equals("download", StringComparison.CurrentCultureIgnoreCase));
            downloadButton.Click();
            JSInterop.VerifyInvoke("downloadCurrentPageGraph");
            
        }
    }
}
