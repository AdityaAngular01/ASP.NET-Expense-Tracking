using SmartExpense.API.DTOs;
using SmartExpense.API.DTOs.ExpenseDTOs;
using SmartExpense.API.DTOs.Responses;
using SmartExpense.API.Models;

namespace SmartExpense.API.Services
{
    public interface IExpenseService
    {
        Task<IEnumerable<object>> GetAllExpenses();

        Task<PaginationDataDTO<Expense>> GetAllExpenses(QueryParams queryParams);

        Task<int> AddExpense(ExpenseDTO dto);

        Task<Expense?> GetExpenseById(int id);

        Task<bool> DeleteExpense(int id);

        Task<(Expense?, Expense?)> UpdateExpense(int id, ExpenseUpdateDTO dto);
    }
}