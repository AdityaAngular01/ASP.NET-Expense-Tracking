namespace SmartExpense.API.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Foreign Keys
        public int UserId { get; set; }
        public User User { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        public int? GroupId { get; set; }
        public Group Group { get; set; }

        // Navigation
        public ICollection<Split> Splits { get; set; }
    }
}