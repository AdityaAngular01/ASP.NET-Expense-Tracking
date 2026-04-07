using SmartExpense.API.DTOs;
using SmartExpense.API.Models;
using SmartExpense.API.Repositories;

namespace SmartExpense.API.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _repo;

        public ExpenseService(IExpenseRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<object>> GetAllExpenses()
        {
            var data = await _repo.GetAllAsync();
            return data.Select(e => new
            {
                e.Id,
                e.Title,
                e.Amount
            });
        }

        public async Task<int> AddExpense(ExpenseDto dto)
        {
            var expense = new Expense
            {
                Title = dto.Title,
                Amount = dto.Amount,
                UserId = 1 //
            };

            await _repo.AddAsync(expense);

            return expense.Id;
        }

        public async Task<Expense?> GetExpenseById(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        
    }
}