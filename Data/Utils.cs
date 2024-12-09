namespace HealthSystem.Data
{
    public static class Utils
    {
        public enum HealthScore
        {
            bad = 0,
            normal = 1,
            good = 2
        }

        public static bool EqualMonths(this DateTime dt1, DateTime dt2)
        {
            return dt1.Year == dt2.Year && dt1.Month == dt2.Month;
        }

        public static float GetPercentage(float first, float second, float third, float fourth, float current)
        {
            float percent = 10;
            if (current <= first)
                return percent;
            if (current <= second)
                return percent * 3;
            if (current >= second && current <= third)
                return percent * 5;
            if (current <= fourth)
                return percent * 7;

            else return percent * 9;

        }


        public static List<List<Message>> GetMessagesByThread(List<Message> messages)
        {
            var messageLookup = messages.ToDictionary(msg => msg.Id);
            var threadStarters = messages
            .Where(msg => msg.PreviousMessageId == null || !messageLookup.ContainsKey(msg.PreviousMessageId.Value))
            .ToList();
            var threads = new List<List<Message>>();
            foreach (var starter in threadStarters)
            {
                var thread = new List<Message>();
                var currentMessage = starter;

                while (currentMessage != null)
                {
                    thread.Add(currentMessage);

                    // Move to the next message in the chain
                    currentMessage = currentMessage.PreviousMessageId.HasValue
                        ? messageLookup.GetValueOrDefault(currentMessage.PreviousMessageId.Value)
                        : null;
                }

                threads.Add(thread);
            }
            return threads;

        }
        public static dynamic[] GetAveragePerMonth(IQueryable<MedicalInformation> data)
        {
            return data.GroupBy(x => new { x.Entry_Date.Year, x.Entry_Date.Month }).Select(x => new { date = $"{x.Key.Month}-{x.Key.Year}", value = float.Parse(x.Average(y => y.Value).ToString("0.00")) }).ToArray();
        }

        public static int GetMetabolicScore(ApplicationUser user, float weight, float waistSize, float insulin, float CGM, float triglyceride, float bloodPressureUpper, float bloodPressureLower, float LDLCholesterol, float HDLCholesterol, float restingHeartRate)
        {
            return (int)GetBMIScore(user.Height, weight) +
                (int)GetWaistScore(user, waistSize) +
                (int)GetInsulinScore(insulin) +
                (int)GetCGMScore(CGM) +
                (int)GetTriglycerideScore(triglyceride) +
                (int)GetBloodPressureScore(bloodPressureUpper, bloodPressureLower) +
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
                return HealthScore.bad;

            var BMI = GetBMI(height, weight);
            if (BMI >= 18.5 && BMI <= 25)
                return HealthScore.good;
            else if ((BMI > 25 && BMI <= 28) || (BMI >= 15 && BMI < 18.5))
                return HealthScore.normal;
            return HealthScore.bad;
        }

        public static HealthScore GetWaistScore(ApplicationUser user, float waistSize)
        {
            if (waistSize == -1)
                return HealthScore.bad;

            float score = waistSize / user.Height;

            if (user.Gender.Equals("male", StringComparison.CurrentCultureIgnoreCase))
            {
                if (score >= 0.43 && score <= 0.5)
                    return HealthScore.good;
                else if ((score > 0.5 && score <= 0.55) || (score >= 0.38 && score < 0.43))
                    return HealthScore.normal;
                return HealthScore.bad;
            }
            else//female
            {
                if (score >= 0.42 && score <= 0.48)
                    return HealthScore.good;
                else if ((score > 0.48 && score <= 0.55) || (score >= 0.35 && score < 0.42))
                    return HealthScore.normal;
                return HealthScore.bad;
            }
        }

        public static HealthScore GetInsulinScore(float insulin)
        {
            if (insulin == -1)
                return HealthScore.bad;

            if (insulin >= 2.6 && insulin <= 5)
                return HealthScore.good;
            else if ((insulin > 5 && insulin <= 11) || (insulin >= 1.5 && insulin < 2.6))
                return HealthScore.normal;
            return HealthScore.bad;
        }

        public static HealthScore GetCGMScore(float CGM)
        {
            if (CGM == -1)
                return HealthScore.bad;
            if (CGM >= 75 && CGM <= 100)
                return HealthScore.good;
            else if ((CGM > 100 && CGM <= 105) || (CGM >= 70 && CGM < 75))
                return HealthScore.normal;
            return HealthScore.bad;
        }

        public static HealthScore GetTriglycerideScore(float triglyceride)
        {
            if (triglyceride == -1)
                return HealthScore.bad;

            if (triglyceride >= 50 && triglyceride <= 180)
                return HealthScore.good;
            else if ((triglyceride > 180 && triglyceride <= 200) || (triglyceride >= 45 && triglyceride < 50))
                return HealthScore.normal;
            return HealthScore.bad;
        }

        public static HealthScore GetBloodPressureScore(float bloodPressureUpper, float bloodPressureLower)
        {
            if (bloodPressureLower == -1 || bloodPressureUpper == -1)
                return HealthScore.bad;

            if ((bloodPressureUpper <= 120 && bloodPressureUpper >= 105) && (bloodPressureLower <= 80 && bloodPressureLower >= 70))
                return HealthScore.good;
            else if (((bloodPressureUpper > 120) && (bloodPressureUpper <= 130) && (bloodPressureLower > 80) && (bloodPressureLower <= 90)) ||
                ((bloodPressureUpper >= 100) && (bloodPressureUpper < 105) && (bloodPressureLower >= 60) && (bloodPressureLower < 70)))
            {
                return HealthScore.normal;
            }

            return HealthScore.bad;
        }

        public static HealthScore GetHDLCholesterolScore(float HDLCholesterol)
        {
            if (HDLCholesterol == -1)
                return HealthScore.bad;

            if (HDLCholesterol >= 50 && HDLCholesterol <= 60)
                return HealthScore.good;
            else if ((HDLCholesterol >= 40 && HDLCholesterol < 50) || (HDLCholesterol > 60 && HDLCholesterol <= 70))
                return HealthScore.normal;
            return HealthScore.bad;
        }

        public static HealthScore GetLDLCholesterolScore(float LDLCholesterol)
        {
            if (LDLCholesterol == -1)
                return HealthScore.bad;

            if (LDLCholesterol >= 100 && LDLCholesterol <= 130)
                return HealthScore.good;
            else if ((LDLCholesterol > 130 && LDLCholesterol <= 160) || (LDLCholesterol >= 70 && LDLCholesterol < 100))
                return HealthScore.normal;
            return HealthScore.bad;
        }

        public static HealthScore GetRestingHeartRateScore(float restingHeartRate)
        {
            if (restingHeartRate == -1)
                return HealthScore.bad;

            if (restingHeartRate >= 40 && restingHeartRate <= 60)
                return HealthScore.good;
            else if ((restingHeartRate > 60 && restingHeartRate <= 80) || (restingHeartRate >= 35 && restingHeartRate < 40))
                return HealthScore.normal;
            return HealthScore.bad;
        }

    }
}
