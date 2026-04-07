using SmartExpense.API.Models;

namespace SmartExpense.API.Repositories
{
    public interface IExpenseRepository
    {
        Task<IEnumerable<Expense>> GetAllAsync();
        Task AddAsync(Expense expense);

        Task<Expense?> GetByIdAsync(int id);

        
    }
}