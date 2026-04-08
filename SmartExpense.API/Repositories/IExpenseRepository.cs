using SmartExpense.API.DTOs;
using SmartExpense.API.DTOs.Responses;
using SmartExpense.API.Models;

namespace SmartExpense.API.Repositories
{
    public interface IExpenseRepository
    {
        Task<IEnumerable<Expense>> GetAllAsync();
        Task AddAsync(Expense expense);

        Task<Expense?> GetByIdAsync(int id);

        Task<PaginationDataDTO<Expense>> GetAllAsync(QueryParams queryParams);

        Task<bool> DeleteByIdAsync(int id);

        Task<Expense?> UpdateAsync(Expense expense);

    }
}