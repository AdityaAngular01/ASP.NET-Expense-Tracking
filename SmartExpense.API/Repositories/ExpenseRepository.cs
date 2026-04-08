using Microsoft.EntityFrameworkCore;
using SmartExpense.API.Data;
using SmartExpense.API.DTOs;
using SmartExpense.API.DTOs.Responses;
using SmartExpense.API.Models;

namespace SmartExpense.API.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly AppDbContext _context;

        public ExpenseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Expense>> GetAllAsync()
        {
            return await _context.Expenses.ToListAsync();
        }

        public async Task<PaginationDataDTO<Expense>> GetAllAsync(QueryParams queryParams)
        {
            return await _context.Expenses.Select(e => e).ToPagedResultAsync(queryParams);
        }

        public async Task AddAsync(Expense expense)
        {
            await _context.Expenses.AddAsync(expense);
            await _context.SaveChangesAsync();
        }

        public async Task<Expense?> GetByIdAsync(int id)
        {
            return await _context.Expenses.FindAsync(id);
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);

            if (expense == null)
                return false;

            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Expense?> UpdateAsync(Expense expense)
        {
            _context.Expenses.Update(expense);
            await _context.SaveChangesAsync();

            return expense;
        }
    }
}