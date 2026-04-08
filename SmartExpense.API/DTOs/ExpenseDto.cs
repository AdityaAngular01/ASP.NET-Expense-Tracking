namespace SmartExpense.API.DTOs
{
    public class ExpenseDto
    {
        public string Title { get; set; }

        public decimal Amount { get; set; }

        // Optional fields
        public int? CategoryId { get; set; }

        public int? GroupId { get; set; }
    }
}