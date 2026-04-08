using SmartExpense.API.Models;

namespace SmartExpense.API.DTOs.ExpenseDTOs
{
    public class ExpenseUpdateResponseDTO
    {
        public Expense OldExpense { get; set; }
        public Expense UpdatedToExpense { get; set; }

        public bool Success => true;

        public int StatusCode => StatusCodes.Status200OK;

        public string Message => "Expense updated successfully";
    }
}