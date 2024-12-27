using System.Linq;

namespace HealthSystem.Data
{
    public static class Utils
    {
        public enum HealthScore
        {
            LeftBad = 1,
            LeftOkay = 2,
            Healthy = 3,
            RightOkay = 4,
            RightBad = 5,

        }

        public enum DynamicsScore
        {
            Degrading = -1,
            Stable = 0,
            Improving = 1,
            Inconclusive = 2
        }

        public enum Parameter
        {
            BMI,
            WaistMale,
            WaistFemale,
            Insulin,
            CGM,
            Triglyceride,
            BloodPressureUpper,
            BloodPressureLower,
            HDLCholesterol,
            LDLCholesterol,
            RestingHeartRate,
            MetabolicHealth
        }
        //based on the above
        private static readonly float[][] ParameterZones = [
            [15f, 18.5f, 25f, 28f],
            [0.38f, 0.43f, 0.5f, 0.55f],
            [0.35f, 0.42f, 0.48f, 0.55f],
            [1.5f, 2.6f, 5f, 11f],
            [70f, 75f, 100f, 105f],
            [45f, 50f, 180f, 200f],
            [100f, 105f, 120f, 130f],
            [60f, 70f, 80f, 90f],
            [40f, 50f, 60f, 70f],
            [70f, 100f, 130f, 160f],
            [35f, 40f, 60f, 80f],
            [0f,10f,15f,18f],
        ];

        ///reference for above array
        //public static readonly float[] BMIZones = [15f, 18.5f, 25f, 28f];
        //public static readonly float[] WaistMaleZones = [0.38f, 0.43f, 0.5f, 0.55f];
        //public static readonly float[] WaistFemaleZones = [0.35f, 0.42f, 0.48f, 0.55f];
        //public static readonly float[] InsulinZones = [1.5f, 2.6f, 5f, 11f];
        //public static readonly float[] CGMZones = [70f, 75f, 100f, 105f];
        //public static readonly float[] TriglycerideZones = [45f, 50f, 180f, 200f];
        //public static readonly float[] BloodPressureUpperZones = [100f, 105f, 120f, 130f];
        //public static readonly float[] BloodPressureLowerZones = [60f, 70f, 80f, 90f];
        //public static readonly float[] HDLCholesterolZones = [40f, 50f, 60f, 70f];
        //public static readonly float[] LDLCholesterolZones = [70f, 100f, 130f, 160f];
        //public static readonly float[] RestingHeartRateZones = [35f, 40f, 60f, 80f];

        public static float GetPercentage(float first, float second, float third, float fourth, float current)
        {
            float percent = 10;
            if (current < first)
                return percent;
            if (current < second)
                return percent * 3;
            if (current >= second && current <= third)
                return percent * 5;
            if (current <= fourth)
                return percent * 7;

            else return percent * 9;

        }
        public static float GetZonePercentage(float zoneStart, float zoneEnd, float current)
        {
            if (zoneEnd == zoneStart)
                if (current == zoneStart)
                    return 100;
                else return 0;
            if (current >= zoneEnd) return 100;
            if (current <= zoneStart) return 0;
            

            return (current - zoneStart) / (zoneEnd - zoneStart) * 100;
        }
        public static int MapScore(int score)
        {
            if (score <= 0 || score > 5)
                return 0;

            return 2 - Math.Abs(score - 3); // Maps 1->0, 2->1, 3->2, 4->1, 5->0
        }
        public static (float, float) GetParameterZone(Parameter parameter, HealthScore score)
        {
            if (parameter == Parameter.MetabolicHealth)
                if (score == HealthScore.Healthy)
                    return (ParameterZones[(int)parameter][2], ParameterZones[(int)parameter][3]);
                else if (score == HealthScore.RightOkay || score == HealthScore.LeftOkay)
                    return (ParameterZones[(int)parameter][1], ParameterZones[(int)parameter][2]);
                else
                    return (ParameterZones[(int)parameter][0], ParameterZones[(int)parameter][1]);

            return score switch
            {
                HealthScore.LeftBad => (-1, ParameterZones[(int)parameter][0]),
                HealthScore.LeftOkay => (ParameterZones[(int)parameter][0], ParameterZones[(int)parameter][1]),
                HealthScore.Healthy => (ParameterZones[(int)parameter][1], ParameterZones[(int)parameter][2]),
                HealthScore.RightOkay => (ParameterZones[(int)parameter][2], ParameterZones[(int)parameter][3]),
                HealthScore.RightBad => (ParameterZones[(int)parameter][3], -1),
                _ => (-1, -1),
            };
        }
        public static List<List<Message>> GetMessagesByThread(List<Message> messages)
        {
            if (messages is null || messages.Count < 1)
                return [];

            var threadStarters = messages.Where(x => x.PreviousMessageId == null || x.PreviousMessageId == 0).ToList();
            var threads = new List<List<Message>>();
            foreach (var starter in threadStarters)
            {
                var thread = new List<Message>();
                var currentMessage = starter;

                while (currentMessage != null)
                {
                    thread.Add(currentMessage);

                    // Move to the next message in the chain
                    currentMessage = messages.FirstOrDefault(x => x.PreviousMessageId == currentMessage.Id);
                }

                threads.Add(thread);
            }

            return threads;

        }
        public static List<MedicalInformation> GenerateMonthlyData(ApplicationDbContext context, string userId, ref int startingId, int monthsAgo = 0)
        {
            if (context is null)
                return [];

            int tempId = startingId;
            //check if startingId already exists to not start from it
            if (context.MedicalInformation.Any(x => x.Id == tempId))
            {
                tempId++;
                //check again to see if the next one is also on the list
                if (context.MedicalInformation.Any(x => x.Id == tempId))
                    throw new ArgumentException("starting ID alreaedy exists in the system");
            }

            var data = Enumerable.Range(1, 9).Select(x => new MedicalInformation
            {
                Entry_Date = new DateTime(DateTime.Now.AddMonths(monthsAgo * -1).Year, DateTime.Now.AddMonths(monthsAgo * -1).Month, 1, 0, 0, 0),
                UserId = userId,
                Id = tempId++,
                InformationTypeId = x,
                Value = 0,
                SecondaryValue = 0,
            }).ToList();

            startingId = tempId;

            context.MedicalInformation.AddRange(data);
            context.SaveChanges();

            return data;
        }
        public static int GetMetabolicHealth(ApplicationUser user, float waistSize, float bloodPressureUpper, float bloodPressureLower, float weight, float restingHeartRate, float CGM, float insulin, float triglyceride, float HDLCholesterol, float LDLCholesterol)
        {
            int waistScore = MapScore((int)GetWaistScore(user, waistSize));
            int bloodPressureScore = MapScore((int)GetBloodPressureScore(bloodPressureUpper, bloodPressureLower));
            int bmiScore = MapScore((int)GetBMIScore(user.Height, weight));
            int restingHeartRateScore = MapScore((int)GetRestingHeartRateScore(restingHeartRate));
            int CGMScore = MapScore((int)GetCGMScore(CGM));
            int insulinScore = MapScore((int)GetInsulinScore(insulin));
            int triglycerideScore = MapScore((int)GetTriglycerideScore(triglyceride));
            int HDLCholesterolScore = MapScore((int)GetHDLCholesterolScore(HDLCholesterol));
            int LDLCholesterolScore = MapScore((int)GetLDLCholesterolScore(LDLCholesterol));

            return waistScore + bloodPressureScore + bmiScore + restingHeartRateScore + CGMScore + insulinScore + triglycerideScore + HDLCholesterolScore + LDLCholesterolScore;
        }
        public static HealthScore GetMetabolicHealthScore(int health)
        {
            if (health <= 0)
                return HealthScore.LeftBad;

            if (health >= 15)
                return HealthScore.Healthy;
            else if (health >= 10)
                return HealthScore.LeftOkay;

            return HealthScore.LeftBad;
        }
        public static HealthScore GetHealthScore(ApplicationUser user, Parameter parameter, float value, float secondValue = 0)
        {
            return parameter switch
            {
                Parameter.BMI => GetBMIScore(user.Height, value),
                Parameter.WaistMale or Parameter.WaistFemale => GetWaistScore(user, value),
                Parameter.Insulin => GetInsulinScore(value),
                Parameter.CGM => GetCGMScore(value),
                Parameter.Triglyceride => GetTriglycerideScore(value),
                Parameter.BloodPressureUpper or Parameter.BloodPressureLower => GetBloodPressureScore(value, secondValue),
                Parameter.HDLCholesterol => GetHDLCholesterolScore(value),
                Parameter.LDLCholesterol => GetLDLCholesterolScore(value),
                Parameter.RestingHeartRate => GetRestingHeartRateScore(value),
                Parameter.MetabolicHealth => GetMetabolicHealthScore((int)value),
                _ => HealthScore.LeftBad,
            };
        }
        /// <summary>
        /// Gets the health trend of a specific parameter
        /// </summary>
        /// <param name="user">Current logged in user</param>
        /// <param name="parameter">Parameter type</param>
        /// <param name="m1">First(current) month value</param>
        /// <param name="m2">Second(previous) month value</param>
        /// <param name="m3">Third month value</param>
        /// <param name="m1Second">Additional first month value</param>
        /// <param name="m2Second">Additional second month value</param>
        /// <param name="m3Second">Additional third month value</param>
        /// <returns></returns>
        public static DynamicsScore GetDynamic(ApplicationUser user, Parameter parameter, float m1, float m2, float m3, float m1Second = 0, float m2Second = 0, float m3Second = 0)
        {
            if (user is null || m1 <= 0 || m2 <= 0 || m3 <= 0)
                return DynamicsScore.Inconclusive;

            HealthScore m1Score = GetHealthScore(user, parameter, m1, m1Second);
            HealthScore m2Score = GetHealthScore(user, parameter, m2, m2Second);
            HealthScore m3Score = GetHealthScore(user, parameter, m3, m3Second);


            //two adjacent months 'jump' over the healthy zone straight to the other side(left to right or right to left)
            if (m2Score != HealthScore.Healthy &&
            Math.Abs(m1Score - m2Score) >= 2 || Math.Abs(m3Score - m2Score) >= 2
            )
            {
                return DynamicsScore.Inconclusive;
            }

            //going from yellow to two greens is improving
            if (m1Score == HealthScore.Healthy && m2Score == HealthScore.Healthy)
            {
                if (m3Score == HealthScore.LeftOkay || m3Score == HealthScore.RightOkay)
                    return DynamicsScore.Improving;
            }
            //going from two greens to anything non green is degrading
            if (m3Score == HealthScore.Healthy && m2Score == HealthScore.Healthy)
            {
                if (m1Score != HealthScore.Healthy)
                    return DynamicsScore.Degrading;
                else return DynamicsScore.Stable;
            }
            //all same zone but not all 3 are healthy
            if (m1Score == m2Score && m2Score == m3Score)
            {
                float errorMargin = m2 * 0.025f;//2.5% distance from the second month - total possible 5% range
                if (Math.Abs(m1 - m2) <= errorMargin && Math.Abs(m2 - m3) <= errorMargin)
                    return DynamicsScore.Stable;
            }

            var m1Zone = GetParameterZone(parameter, m1Score);
            var m2Zone = GetParameterZone(parameter, m2Score);
            var m3Zone = GetParameterZone(parameter, m3Score);

            if (parameter == Parameter.WaistMale || parameter == Parameter.WaistFemale)
            {//waist uses a ratio rather than the flat value
                if (user.Height == 0)
                    return DynamicsScore.Inconclusive;
                m1 /= user.Height;
                m2 /= user.Height;
                m3 /= user.Height;
            }
            else if (parameter == Parameter.BMI)
            {//weight stores BMI rather than the weight for calculations
                if (user.Height == 0)
                    return DynamicsScore.Inconclusive;
                m1 = GetBMI(user.Height, m1);
                m2 = GetBMI(user.Height, m2);
                m3 = GetBMI(user.Height, m3);
            }

            //how far along a specific zone is the parameter
            var m1Percentage = GetZonePercentage(m1Zone.Item1, m1Zone.Item2, m1);
            var m2Percentage = GetZonePercentage(m2Zone.Item1, m2Zone.Item2, m2);
            var m3Percentage = GetZonePercentage(m3Zone.Item1, m3Zone.Item2, m3);

            //convert percentages to values relative to other zones, greens are 0-100%, yellows are 100-200%, reds are 200-300%
            m1Percentage = Math.Abs(((2 - MapScore((int)m1Score)) * 100) - m1Percentage);
            m2Percentage = Math.Abs(((2 - MapScore((int)m2Score)) * 100) - m2Percentage);
            m3Percentage = Math.Abs(((2 - MapScore((int)m3Score)) * 100) - m3Percentage);

            //if the zones are right sided zones, make the percentage negative
            m1Percentage = (m1Score == HealthScore.RightOkay || m1Score == HealthScore.RightBad) ? m1Percentage * -1 : m1Percentage;
            m2Percentage = (m2Score == HealthScore.RightOkay || m2Score == HealthScore.RightBad) ? m2Percentage * -1 : m2Percentage;
            m3Percentage = (m3Score == HealthScore.RightOkay || m3Score == HealthScore.RightBad) ? m3Percentage * -1 : m3Percentage;



            //moving from smaller to larger percentage = degrading health
            if (Math.Abs(m3Percentage) <= Math.Abs(m2Percentage) && Math.Abs(m2Percentage) <= Math.Abs(m1Percentage))
                return DynamicsScore.Degrading;
            //moving from larger to smaller percentage = improvement
            if (Math.Abs(m3Percentage) >= Math.Abs(m2Percentage) && Math.Abs(m2Percentage) >= Math.Abs(m1Percentage))
                return DynamicsScore.Improving;

            return DynamicsScore.Inconclusive;
        }

        public static float GetBMI(float height, float weight)
        {
            if (height <= 0 || weight <= 0)
                return -1;

            return weight / ((height / 100) * (height / 100));
        }

        public static HealthScore GetBMIScore(float height, float weight)
        {
            if (height <= 0 || weight <= 0)
                return HealthScore.LeftBad;

            var BMI = GetBMI(height, weight);
            if (BMI >= ParameterZones[(int)Parameter.BMI][1] && BMI <= ParameterZones[(int)Parameter.BMI][2])
                return HealthScore.Healthy;
            else if (BMI >= ParameterZones[(int)Parameter.BMI][0] && BMI < ParameterZones[(int)Parameter.BMI][1])
                return HealthScore.LeftOkay;
            else if (BMI > ParameterZones[(int)Parameter.BMI][2] && BMI <= ParameterZones[(int)Parameter.BMI][3])
                return HealthScore.RightOkay;
            if (BMI > ParameterZones[(int)Parameter.BMI][3])
                return HealthScore.RightBad;
            return HealthScore.LeftBad;
        }

        public static HealthScore GetWaistScore(ApplicationUser user, float waistSize)
        {
            if (waistSize <= 0)
                return HealthScore.LeftBad;

            float score = waistSize / user.Height;

            if (user.Gender.Equals("male", StringComparison.CurrentCultureIgnoreCase))
            {
                if (score >= ParameterZones[(int)Parameter.WaistMale][1] && score <= ParameterZones[(int)Parameter.WaistMale][2])
                    return HealthScore.Healthy;
                else if (score >= ParameterZones[(int)Parameter.WaistMale][0] && score < ParameterZones[(int)Parameter.WaistMale][1])
                    return HealthScore.LeftOkay;
                else if (score > ParameterZones[(int)Parameter.WaistMale][2] && score <= ParameterZones[(int)Parameter.WaistMale][3])
                    return HealthScore.RightOkay;
                if (score > ParameterZones[(int)Parameter.WaistMale][3])
                    return HealthScore.RightBad;

                return HealthScore.LeftBad;
            }
            else//female
            {
                if (score >= ParameterZones[(int)Parameter.WaistFemale][1] && score <= ParameterZones[(int)Parameter.WaistFemale][2])
                    return HealthScore.Healthy;
                else if (score >= ParameterZones[(int)Parameter.WaistFemale][0] && score < ParameterZones[(int)Parameter.WaistFemale][1])
                    return HealthScore.LeftOkay;
                else if (score > ParameterZones[(int)Parameter.WaistFemale][2] && score <= ParameterZones[(int)Parameter.WaistFemale][3])
                    return HealthScore.RightOkay;
                else if (score > ParameterZones[(int)Parameter.WaistFemale][3])
                    return HealthScore.RightBad;

                return HealthScore.LeftBad;
            }
        }

        public static HealthScore GetInsulinScore(float insulin)
        {
            if (insulin <= 0)
                return HealthScore.LeftBad;

            if (insulin >= ParameterZones[(int)Parameter.Insulin][1] && insulin <= ParameterZones[(int)Parameter.Insulin][2])
                return HealthScore.Healthy;
            else if (insulin >= ParameterZones[(int)Parameter.Insulin][0] && insulin < ParameterZones[(int)Parameter.Insulin][1])
                return HealthScore.LeftOkay;
            else if (insulin > ParameterZones[(int)Parameter.Insulin][2] && insulin <= ParameterZones[(int)Parameter.Insulin][3])
                return HealthScore.RightOkay;
            else if (insulin > ParameterZones[(int)Parameter.Insulin][3])
                return HealthScore.RightBad;

            return HealthScore.LeftBad;
        }

        public static HealthScore GetCGMScore(float CGM)
        {
            if (CGM <= 0)
                return HealthScore.LeftBad;
            if (CGM >= ParameterZones[(int)Parameter.CGM][1] && CGM <= ParameterZones[(int)Parameter.CGM][2])
                return HealthScore.Healthy;
            else if (CGM >= ParameterZones[(int)Parameter.CGM][0] && CGM < ParameterZones[(int)Parameter.CGM][1])
                return HealthScore.LeftOkay;
            else if (CGM > ParameterZones[(int)Parameter.CGM][2] && CGM <= ParameterZones[(int)Parameter.CGM][3])
                return HealthScore.RightOkay;
            else if (CGM > ParameterZones[(int)Parameter.CGM][3])
                return HealthScore.RightBad;

            return HealthScore.LeftBad;
        }

        public static HealthScore GetTriglycerideScore(float triglyceride)
        {
            if (triglyceride <= 0)
                return HealthScore.LeftBad;

            if (triglyceride >= ParameterZones[(int)Parameter.Triglyceride][1] && triglyceride <= ParameterZones[(int)Parameter.Triglyceride][2])
                return HealthScore.Healthy;
            else if (triglyceride >= ParameterZones[(int)Parameter.Triglyceride][0] && triglyceride < ParameterZones[(int)Parameter.Triglyceride][1])
                return HealthScore.LeftOkay;
            else if (triglyceride > ParameterZones[(int)Parameter.Triglyceride][2] && triglyceride <= ParameterZones[(int)Parameter.Triglyceride][3])
                return HealthScore.RightOkay;
            else if (triglyceride > ParameterZones[(int)Parameter.Triglyceride][3])
                return HealthScore.RightBad;

            return HealthScore.LeftBad;
        }

        public static HealthScore GetBloodPressureScore(float bloodPressureUpper, float bloodPressureLower)
        {
            if (bloodPressureLower <= 0 || bloodPressureUpper <= 0)
                return HealthScore.LeftBad;

            if ((bloodPressureUpper <= ParameterZones[(int)Parameter.BloodPressureUpper][2] && bloodPressureUpper >= ParameterZones[(int)Parameter.BloodPressureUpper][1]) && (bloodPressureLower <= ParameterZones[(int)Parameter.BloodPressureLower][2] && bloodPressureLower >= ParameterZones[(int)Parameter.BloodPressureLower][1]))
                return HealthScore.Healthy;
            else if ((bloodPressureUpper >= ParameterZones[(int)Parameter.BloodPressureUpper][0]) && (bloodPressureUpper < ParameterZones[(int)Parameter.BloodPressureUpper][1]) && (bloodPressureLower >= ParameterZones[(int)Parameter.BloodPressureLower][0]) && (bloodPressureLower < ParameterZones[(int)Parameter.BloodPressureLower][1]))
                return HealthScore.LeftOkay;
            else if ((bloodPressureUpper > ParameterZones[(int)Parameter.BloodPressureUpper][2]) && (bloodPressureUpper <= ParameterZones[(int)Parameter.BloodPressureUpper][3]) && (bloodPressureLower > ParameterZones[(int)Parameter.BloodPressureLower][2]) && (bloodPressureLower <= ParameterZones[(int)Parameter.BloodPressureLower][3]))
                return HealthScore.RightOkay;
            else if (bloodPressureUpper > ParameterZones[(int)Parameter.BloodPressureUpper][3] || bloodPressureLower > ParameterZones[(int)Parameter.BloodPressureLower][3])
                return HealthScore.RightBad;

            return HealthScore.LeftBad;
        }

        public static HealthScore GetHDLCholesterolScore(float HDLCholesterol)
        {
            if (HDLCholesterol <= 0)
                return HealthScore.LeftBad;

            if (HDLCholesterol >= ParameterZones[(int)Parameter.HDLCholesterol][1] && HDLCholesterol <= ParameterZones[(int)Parameter.HDLCholesterol][2])
                return HealthScore.Healthy;
            else if (HDLCholesterol >= ParameterZones[(int)Parameter.HDLCholesterol][0] && HDLCholesterol < ParameterZones[(int)Parameter.HDLCholesterol][1])
                return HealthScore.LeftOkay;
            else if (HDLCholesterol > ParameterZones[(int)Parameter.HDLCholesterol][2] && HDLCholesterol <= ParameterZones[(int)Parameter.HDLCholesterol][3])
                return HealthScore.RightOkay;
            else if (HDLCholesterol > ParameterZones[(int)Parameter.HDLCholesterol][3])
                return HealthScore.RightBad;

            return HealthScore.LeftBad;
        }

        public static HealthScore GetLDLCholesterolScore(float LDLCholesterol)
        {
            if (LDLCholesterol <= 0)
                return HealthScore.LeftBad;

            if (LDLCholesterol >= ParameterZones[(int)Parameter.LDLCholesterol][1] && LDLCholesterol <= ParameterZones[(int)Parameter.LDLCholesterol][2])
                return HealthScore.Healthy;
            else if (LDLCholesterol >= ParameterZones[(int)Parameter.LDLCholesterol][0] && LDLCholesterol < ParameterZones[(int)Parameter.LDLCholesterol][1])
                return HealthScore.LeftOkay;
            else if (LDLCholesterol > ParameterZones[(int)Parameter.LDLCholesterol][2] && LDLCholesterol <= ParameterZones[(int)Parameter.LDLCholesterol][3])
                return HealthScore.RightOkay;
            else if (LDLCholesterol > ParameterZones[(int)Parameter.LDLCholesterol][3])
                return HealthScore.RightBad;

            return HealthScore.LeftBad;
        }

        public static HealthScore GetRestingHeartRateScore(float restingHeartRate)
        {
            if (restingHeartRate <= 0)
                return HealthScore.LeftBad;

            if (restingHeartRate >= ParameterZones[(int)Parameter.RestingHeartRate][1] && restingHeartRate <= ParameterZones[(int)Parameter.RestingHeartRate][2])
                return HealthScore.Healthy;
            else if (restingHeartRate >= ParameterZones[(int)Parameter.RestingHeartRate][0] && restingHeartRate < ParameterZones[(int)Parameter.RestingHeartRate][1])
                return HealthScore.LeftOkay;
            else if (restingHeartRate > ParameterZones[(int)Parameter.RestingHeartRate][2] && restingHeartRate <= ParameterZones[(int)Parameter.RestingHeartRate][3])
                return HealthScore.RightOkay;
            else if (restingHeartRate > ParameterZones[(int)Parameter.RestingHeartRate][3])
                return HealthScore.RightBad;

            return HealthScore.LeftBad;
        }

    }
}
