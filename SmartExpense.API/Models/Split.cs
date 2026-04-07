namespace SmartExpense.API.Models
{
    public class Split
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        // Who owes
        public int OwedByUserId { get; set; }
        public User OwedByUser { get; set; }

        // Who paid
        public int OwedToUserId { get; set; }
        public User OwedToUser { get; set; }

        // Expense reference
        public int ExpenseId { get; set; }
        public Expense Expense { get; set; }

        public bool IsSettled { get; set; } = false;
    }
}