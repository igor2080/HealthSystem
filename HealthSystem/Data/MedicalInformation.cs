namespace HealthSystem.Data
{
    
    public class MedicalInformation
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public float Value { get; set; }
        public float? SecondaryValue { get; set; }
        public DateTime Entry_Date { get; set; }
        public int InformationTypeId { get; set; }
        public InformationType InformationType { get; set; }
    }
}
