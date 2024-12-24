using static HealthSystem.Data.Utils;

namespace HealthSystem.Data
{
    public class TriggerParameter
    {
        public int Id { get; set; }
        public int InformationTypeId { get; set; }
        public InformationType Type { get; set; }
        public DynamicsScore DynamicsScore { get; set; }
        public int RecommendationId { get; set; }
        public Recommendation Recommendation { get; set; }
    }
}
