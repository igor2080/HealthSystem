using HealthSystem.Data;
using System;
using System.Collections.Generic;
using static HealthSystem.Data.Utils;

namespace HealthSystemTest
{
    public class UtilsTests : TestContext
    {
        [Fact]
        public void GetPercentage_Boundary()
        {
            var result = GetPercentage(2, 4, 6, 8, -1);
            Assert.Equal(10, result);
            result = GetPercentage(2, 4, 6, 8, 100);
            Assert.Equal(90, result);
        }
        [Fact]
        public void GetPercentage_Valid_Value()
        {
            var result = GetPercentage(2, 4, 6, 8, 5);
            Assert.Equal(50, result);
            result = GetPercentage(2, 4, 6, 8, 7);
            Assert.Equal(70, result);
        }
        [Fact]
        public void GetZonePercentage_Boundary()
        {
            var result = GetZonePercentage(70, 80, 1);
            Assert.Equal(0, result);
            result = GetZonePercentage(70, 80, 100);
            Assert.Equal(100, result);
            result = GetZonePercentage(0, 0, 100);
            Assert.Equal(0, result);
        }
        [Fact]
        public void GetZonePercentage_Valid_Value()
        {
            var result = GetZonePercentage(70, 80, 75);
            Assert.Equal(50, result);
        }
        [Fact]
        public void MapScore_Boundary()
        {
            var result = MapScore(-1);
            Assert.Equal(0, result);
            result = MapScore(8);
            Assert.Equal(0, result);
        }
        [Fact]
        public void MapScore_Valid_Value()
        {
            var result = MapScore(3);
            Assert.Equal(2, result);
        }
        [Fact]
        public void GetParameterZoneMetabolicHealth_Okay()
        {
            var result = GetParameterZone(Parameter.MetabolicHealth, HealthScore.LeftOkay);
            Assert.Equal((10, 15), result);
        }
        [Fact]
        public void GetMessagesByThread_No_Messages()
        {
            var result = GetMessagesByThread(null);
            Assert.Empty(result);
            result = GetMessagesByThread([]);
            Assert.Empty(result);
        }
        [Fact]
        public void GetMessagesByThread_Collapse_Messages_To_Thread()
        {
            List<Message> messages =
            [
                new Message() {Id=1,Content="text",Title="title",Date=DateTime.Now.AddDays(-3),ReceiverId=Globals.AdminId,SenderId=Globals.AdminId },
                new Message() { Id = 2, Content = "text 2", Title = "title", Date = DateTime.Now.AddDays(-2), ReceiverId = Globals.AdminId, SenderId = Globals.AdminId,  PreviousMessageId=1},
                new Message() { Id = 3, Content = "text 3", Title = "title", Date = DateTime.Now.AddDays(-1), ReceiverId = Globals.AdminId, SenderId = Globals.AdminId,  PreviousMessageId=2},
            ];
            var result = GetMessagesByThread(messages);
            Assert.True(result.Count == 1 && result[0].Count == 3);
        }
        [Fact]
        public void GetMetabolicHealth_Boundary()
        {
            var user = new ApplicationUser() { Height = -1 };
            var result = GetMetabolicHealth(user, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1);
            Assert.Equal(0, result);
        }
        [Fact]
        public void GetMetabolicHealthScore_Boundary()
        {
            var result = GetMetabolicHealthScore(-1);
            Assert.Equal(HealthScore.LeftBad, result);
        }
        [Fact]
        public void GetMetabolicHealthScore_Valid_Value()
        {
            var result = GetMetabolicHealthScore(15);
            Assert.Equal(HealthScore.Healthy, result);
        }
        [Fact]
        public void GetMetabolicHealthScore_Healthy()
        {
            var user = new ApplicationUser() { Height = 180, Gender = "male" };
            var result = GetMetabolicHealthScore(GetMetabolicHealth(user, 88, 110, 75, 77, 54, 88, 5, 66, 55, 111));
            Assert.Equal(HealthScore.Healthy, result);
        }
        [Fact]
        public void GetMetabolicHealthScore_Okay()
        {
            var user = new ApplicationUser() { Height = 180, Gender = "male" };
            var result = GetMetabolicHealthScore(GetMetabolicHealth(user, 0, 0, 0, 0, 54, 88, 5, 66, 55, 111));
            Assert.Equal(HealthScore.LeftOkay, result);
        }
        [Fact]
        public void GetDynamic_Boundary()
        {
            var user = new ApplicationUser() { Height = 0, Gender = "male" };
            var result = GetDynamic(user, Parameter.MetabolicHealth, -1, -1, -1, -1, -1, -1);
            Assert.Equal(DynamicsScore.Inconclusive, result);
        }
        [Fact]
        public void GetDynamic_No_User()
        {
            var result = GetDynamic(null, Parameter.MetabolicHealth, -1, -1, -1, -1, -1, -1);
            Assert.Equal(DynamicsScore.Inconclusive, result);
        }
        [Fact]
        public void GetDynamic_Improving()
        {
            var user = new ApplicationUser() { Height = 180, Gender = "male" };
            var result = GetDynamic(user, Parameter.RestingHeartRate, 45, 40, 35);
            Assert.Equal(DynamicsScore.Improving, result);
        }
        [Fact]
        public void GetDynamic_Degrading()
        {
            var user = new ApplicationUser() { Height = 180, Gender = "male" };
            var result = GetDynamic(user, Parameter.RestingHeartRate, 35, 40, 45);
            Assert.Equal(DynamicsScore.Degrading, result);
        }
        [Fact]
        public void GetDynamic_Zone_Jump()
        {
            var user = new ApplicationUser() { Height = 180, Gender = "male" };
            var result = GetDynamic(user, Parameter.BMI, 100, 50, 100);
            Assert.Equal(DynamicsScore.Inconclusive, result);
        }
        [Fact]
        public void GetDynamic_M1_M2_Healthy_M3_Okay_Improving()
        {
            var user = new ApplicationUser() { Height = 180, Gender = "male" };
            var result = GetDynamic(user, Parameter.RestingHeartRate, 55,55,38);
            Assert.Equal(DynamicsScore.Improving, result);
        }
        [Fact]
        public void GetDynamic_All_Same_Healthy_Stable()
        {
            var user = new ApplicationUser() { Height = 180, Gender = "male" };
            var result = GetDynamic(user, Parameter.RestingHeartRate, 55, 55, 55);
            Assert.Equal(DynamicsScore.Stable, result);
        }
        [Fact]
        public void GetDynamic_All_Same_Not_Healthy_Within_Range_Stable()
        {
            var user = new ApplicationUser() { Height = 180, Gender = "male" };
            var result = GetDynamic(user, Parameter.RestingHeartRate, 75, 75.5f, 75);
            Assert.Equal(DynamicsScore.Stable, result);
        }
        [Fact]
        public void GetBMIScore_Boundary()
        {
            var result = GetBMIScore(-1, -1);
            Assert.Equal(HealthScore.LeftBad, result);
        }
        [Fact]
        public void GetBMIScore_Healthy()
        {
            var result = GetBMIScore(180, 70);
            Assert.Equal(HealthScore.Healthy, result);
        }
        [Fact]
        public void GetBMIScore_Okay()
        {
            var result = GetBMIScore(180, 50);
            Assert.Equal(HealthScore.LeftOkay, result);
        }
        [Fact]
        public void GetWaistScore_Boundary()
        {
            var user = new ApplicationUser() { Height = 180, Gender = "male" };
            var result = GetWaistScore(user, -1);
            Assert.Equal(HealthScore.LeftBad, result);
        }
        [Fact]
        public void GetWaistScore_Healthy()
        {
            var user = new ApplicationUser() { Height = 180, Gender = "male" };
            var result = GetWaistScore(user, 89);
            Assert.Equal(HealthScore.Healthy, result);
        }
        [Fact]
        public void GetWaistScore_Okay()
        {
            var user = new ApplicationUser() { Height = 180, Gender = "male" };
            var result = GetWaistScore(user, 82);
            Assert.Equal(HealthScore.Healthy, result);
        }
        [Fact]
        public void GetInsulinScore_Boundary()
        {
            var result = GetInsulinScore(-1);
            Assert.Equal(HealthScore.LeftBad, result);
        }
        [Fact]
        public void GetInsulinScore_Healthy()
        {
            var result = GetInsulinScore(3);
            Assert.Equal(HealthScore.Healthy, result);
        }
        [Fact]
        public void GetInsulinScore_Okay()
        {
            var result = GetInsulinScore(2);
            Assert.Equal(HealthScore.LeftOkay, result);
        }
        [Fact]
        public void GetCGMScore_Boundary()
        {
            var result = GetCGMScore(-1);
            Assert.Equal(HealthScore.LeftBad, result);
        }
        [Fact]
        public void GetCGMScore_Healthy()
        {
            var result = GetCGMScore(85);
            Assert.Equal(HealthScore.Healthy, result);
        }
        [Fact]
        public void GetCGMScore_Okay()
        {
            var result = GetCGMScore(72);
            Assert.Equal(HealthScore.LeftOkay, result);
        }
        [Fact]
        public void GetTriglycerideScore_Boundary()
        {
            var result = GetTriglycerideScore(-1);
            Assert.Equal(HealthScore.LeftBad, result);
        }
        [Fact]
        public void GetTriglycerideScore_Healthy()
        {
            var result = GetTriglycerideScore(100);
            Assert.Equal(HealthScore.Healthy, result);
        }
        [Fact]
        public void GetTriglycerideScore_Okay()
        {
            var result = GetTriglycerideScore(46);
            Assert.Equal(HealthScore.LeftOkay, result);
        }
        [Fact]
        public void GetBloodPressureScore_Boundary()
        {
            var result = GetBloodPressureScore(-1, -1);
            Assert.Equal(HealthScore.LeftBad, result);
        }
        [Fact]
        public void GetBloodPressureScore_Healthy()
        {
            var result = GetBloodPressureScore(110, 75);
            Assert.Equal(HealthScore.Healthy, result);
        }
        [Fact]
        public void GetBloodPressureScore_Okay()
        {
            var result = GetBloodPressureScore(104, 65);
            Assert.Equal(HealthScore.LeftOkay, result);
        }
        [Fact]
        public void GetBloodPressureScore_Mixed_Values_Bad()
        {
            var result = GetBloodPressureScore(104, 75);
            Assert.Equal(HealthScore.LeftBad, result);
        }
        [Fact]
        public void GetHDLCholesterolScore_Boundary()
        {
            var result = GetHDLCholesterolScore(-1);
            Assert.Equal(HealthScore.LeftBad,result);
        }
        [Fact]
        public void GetHDLCholesterolScore_Healthy()
        {
            var result = GetHDLCholesterolScore(55);
            Assert.Equal(HealthScore.Healthy, result);
        }
        [Fact]
        public void GetHDLCholesterolScore_Okay()
        {
            var result = GetHDLCholesterolScore(45);
            Assert.Equal(HealthScore.LeftOkay, result);
        }
        [Fact]
        public void GetLDLCholesterolScore_Boundary()
        {
            var result = GetLDLCholesterolScore(-1);
            Assert.Equal(HealthScore.LeftBad, result);
        }
        [Fact]
        public void GetLDLCholesterolScore_Healthy()
        {
            var result = GetLDLCholesterolScore(120);
            Assert.Equal(HealthScore.Healthy, result);
        }
        [Fact]
        public void GetLDLCholesterolScore_Okay()
        {
            var result = GetLDLCholesterolScore(80);
            Assert.Equal(HealthScore.LeftOkay, result);
        }
        [Fact]
        public void GetRestingHeartRateScore_Boundary()
        {
            var result = GetRestingHeartRateScore(-1);
            Assert.Equal(HealthScore.LeftBad, result);
        }
        [Fact]
        public void GetRestingHeartRateScore_Healthy()
        {
            var result = GetRestingHeartRateScore(50);
            Assert.Equal(HealthScore.Healthy, result);
        }
        [Fact]
        public void GetRestingHeartRateScore_Okay()
        {
            var result = GetRestingHeartRateScore(36);
            Assert.Equal(HealthScore.LeftOkay, result);
        }

    }
}
