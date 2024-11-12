namespace HealthSystem.Data
{
    public class TriggerParameter
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public float Lower_Boundary { get; set; }
        public float Upper_Boundary { get; set; }
        public int RecommendationId { get; set; }
        public Recommendation Recommendation { get; set; }
    }
}
