namespace HealthSystem.Data
{
    public class MedicalInformation
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string Information_Type { get; set; }
        public string Value { get; set; }
        public DateTime Entry_Date { get; set; }
    }
}
