namespace SmartExpense.API.Models
{
    public class Payment
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public int PaidByUserId { get; set; }
        public User PaidByUser { get; set; }

        public int PaidToUserId { get; set; }
        public User PaidToUser { get; set; }

        public DateTime PaidAt { get; set; } = DateTime.UtcNow;
    }
}