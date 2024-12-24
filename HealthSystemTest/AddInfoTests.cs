using HealthSystem.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HealthSystem.Components.Pages;
using Moq;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace HealthSystemTest
{
    public class AddInfoTests : TestContext
    {
        [Fact]
        public void IsDataAccurateFromDB()
        {
            Globals.InitializeUserData(this, Services);

            var cut = RenderComponent<AddInfo>();

            var result = cut.FindAll(".info-row");

            result.MarkupMatches("");
        }

        //[Fact]
        //public void CounterStartsAtZero()
        //{
        //    // Arrange
        //    var cut = RenderComponent<Counter>();

        //    // Assert that content of the paragraph shows counter at zero
        //    cut.Find("p").MarkupMatches("<p>Current count: 0</p>");
        //}

    }
}
