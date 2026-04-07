using SmartExpense.API.DTOs;
using SmartExpense.API.Models;

namespace SmartExpense.API.Services
{
    public interface IExpenseService
    {
        Task<IEnumerable<object>> GetAllExpenses();
        Task<int> AddExpense(ExpenseDto dto);

        Task<Expense?> GetExpenseById(int id);
    }
}