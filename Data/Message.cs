namespace HealthSystem.Data
{
    public class Message
    {
        public int Id { get; set; }
        public string SenderId { get; set; }
        public virtual ApplicationUser Sender { get; set; }
        public string ReceiverId { get; set; }
        public virtual ApplicationUser Receiver { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }
    }
}
