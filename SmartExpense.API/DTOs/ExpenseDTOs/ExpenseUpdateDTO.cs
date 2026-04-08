namespace SmartExpense.API.DTOs.ExpenseDTOs
{
    public class ExpenseUpdateDTO
    {
        public string? Title { get; set; }

        public decimal? Amount { get; set; }

        // Optional fields
        public int? CategoryId { get; set; }

        public int? GroupId { get; set; }
    }
}