namespace HealthSystem.Data
{
    public static class Utils
    {
        public enum HealthScore
        {
            Bad = 0,
            Acceptable = 1,
            Healthy = 2
        }
        public static dynamic[] GetAveragePerMonth(IQueryable<MedicalInformation> data)
        {
            return data.GroupBy(x => new { x.Entry_Date.Year, x.Entry_Date.Month }).Select(x => new { date = $"{x.Key.Month}-{x.Key.Year}", value = x.Average(y => y.Value) }).ToArray();
        }

        public static int GetMetabolicScore(ApplicationUser user, float weight, float waistSize, float insulin, float CGM, float triglyceride, float bloodPressureUpper, float bloodPressureLower, float LDLCholesterol, float HDLCholesterol, float restingHeartRate)
        {
            return (int)GetBMIScore(user.Height, weight) +
                (int)GetWaistScore(user, waistSize) +
                (int)GetInsulinScore(insulin) +
                (int)GetCGMScore(CGM) +
                (int)GetTriglycerideScore(triglyceride) +
                (int)GetBloodPressureeScore(bloodPressureUpper, bloodPressureLower) +
                (int)GetHDLCholesterolScore(HDLCholesterol) +
                (int)GetLDLCholesterolScore(LDLCholesterol) +
                (int)GetRestingHeartRateScore(restingHeartRate);
        }

        public static float GetBMI(float height, float weight)
        {
            return weight / ((height / 100) * (height / 100));
        }

        public static HealthScore GetBMIScore(float height, float weight)
        {
            if (height == -1 || weight == -1)
                return HealthScore.Bad;

            var BMI = GetBMI(height, weight);
            if (BMI >= 18.5 && BMI < 25)
                return HealthScore.Healthy;
            else if (BMI >= 25 && BMI <= 30)
                return HealthScore.Acceptable;
            return HealthScore.Bad;
        }

        public static HealthScore GetWaistScore(ApplicationUser user, float waistSize)
        {
            if (waistSize == -1)
                return HealthScore.Bad;

            float score = waistSize / user.Height;

            if (user.Gender.Equals("male", StringComparison.CurrentCultureIgnoreCase))
            {
                if (score >= 0.43 && score <= 0.5)
                    return HealthScore.Healthy;
                else if (score > 0.5 && score <= 0.55)
                    return HealthScore.Acceptable;
                return HealthScore.Bad;
            }
            else//female
            {
                if (score >= 0.42 && score <= 0.48)
                    return HealthScore.Healthy;
                else if (score > 0.48 && score <= 0.55)
                    return HealthScore.Acceptable;
                return HealthScore.Bad;
            }
        }

        public static HealthScore GetInsulinScore(float insulin)
        {
            if (insulin == -1)
                return HealthScore.Bad;

            if (insulin >= 2.6 && insulin <= 5)
                return HealthScore.Healthy;
            else if (insulin > 5 && insulin <= 11)
                return HealthScore.Acceptable;
            return HealthScore.Bad;
        }

        public static HealthScore GetCGMScore(float CGM)
        {
            if (CGM == -1)
                return HealthScore.Bad;
            if (CGM >= 70 && CGM <= 100)
                return HealthScore.Healthy;
            else if (CGM > 100 && CGM <= 125)
                return HealthScore.Acceptable;
            return HealthScore.Bad;
        }

        public static HealthScore GetTriglycerideScore(float triglyceride)
        {
            if(triglyceride == -1)
                return HealthScore.Bad;

            if (triglyceride >= 50 && triglyceride <= 180)
                return HealthScore.Healthy;
            else if (triglyceride > 180 && triglyceride <= 200)
                return HealthScore.Acceptable;
            return HealthScore.Bad;
        }

        public static HealthScore GetBloodPressureeScore(float bloodPressureUpper, float bloodPressureLower)
        {
            if (bloodPressureLower == -1 || bloodPressureUpper == -1)
                return HealthScore.Bad;

            if (bloodPressureUpper <= 120 && bloodPressureLower <= 80)
                return HealthScore.Healthy;
            else if ((bloodPressureUpper > 120) && (bloodPressureUpper <= 130) && (bloodPressureLower > 80) && (bloodPressureLower <= 90))
            {
                return HealthScore.Acceptable;
            }

            return HealthScore.Bad;
        }

        public static HealthScore GetHDLCholesterolScore(float HDLCholesterol)
        {
            if(HDLCholesterol== -1) 
                return HealthScore.Bad;

            if (HDLCholesterol >= 60)
                return HealthScore.Healthy;
            else if (HDLCholesterol >= 40 && HDLCholesterol <= 59)
                return HealthScore.Acceptable;
            return HealthScore.Bad;
        }

        public static HealthScore GetLDLCholesterolScore(float LDLCholesterol)
        {
            if (LDLCholesterol == -1)
                return HealthScore.Bad;

            if (LDLCholesterol < 100)
                return HealthScore.Healthy;
            else if (LDLCholesterol >= 100 && LDLCholesterol <= 160)
                return HealthScore.Acceptable;
            return HealthScore.Bad;
        }

        public static HealthScore GetRestingHeartRateScore(float restingHeartRate)
        {
            if(restingHeartRate==-1)
                return HealthScore.Bad;

            if (restingHeartRate >= 40 && restingHeartRate <= 60)
                return HealthScore.Healthy;
            else if (restingHeartRate > 60 && restingHeartRate <= 80)
                return HealthScore.Acceptable;
            return HealthScore.Bad;
        }

    }
}
