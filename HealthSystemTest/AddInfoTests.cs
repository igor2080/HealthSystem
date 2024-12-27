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
    public class AddInfoTests : TestContext
    {
        [Fact]
        public void IsDataAccurateFromDB()
        {
            Globals.InitializeUserData(this, Services);

            var db = Services.GetService<IDbContextFactory<ApplicationDbContext>>();
            var context = db.CreateDbContext();
            //get the current month, latest entries, for the admin user
            var dbData = context.MedicalInformation.
                Where(x => x.UserId == Globals.AdminId && x.Entry_Date.Month == DateTime.Now.Month && x.Entry_Date.Year == DateTime.Now.Year).
                OrderByDescending(x => x.Entry_Date).ToList().
                DistinctBy(x => x.InformationTypeId).
                SelectMany(x => new[] { x.Value, x.SecondaryValue ?? null }.Where(v => v != null))
                .Select(x => x.Value).ToList();
            
            var cut = RenderComponent<AddInfo>();
            
            //try get the same data from the page, 
            var pageResult = cut.FindAll(".addinfo-number").Select(x => Convert.ToSingle(x.GetAttribute("value"))).ToList();

            Assert.Equal(dbData, pageResult[..^1]);//result also contains metabolic score, which is not needed here
        }

        [Fact]
        public void DataSavedToDbCorrectly()
        {
            Globals.InitializeUserData(this, Services);
            var cut = RenderComponent<AddInfo>();
            var pageResult = cut.FindAll(".addinfo-number");
            string originalValue = pageResult[0].GetAttribute("value");
            pageResult[0].Change("85");
            cut.Find("button").Click();
            cut = RenderComponent<AddInfo>();
            pageResult = cut.FindAll(".addinfo-number");
            Assert.Equal("85", pageResult[0].GetAttribute("value"));
            pageResult[0].Change(originalValue);
            cut.Find("button").Click();
        }

    }
}
