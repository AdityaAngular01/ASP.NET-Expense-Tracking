

using Microsoft.EntityFrameworkCore;
using SmartExpense.API.Data;
using SmartExpense.API.DTOs;
using SmartExpense.API.DTOs.Responses;
using SmartExpense.API.Models;

namespace SmartExpense.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteByIdAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<PaginationDataDTO<User>> GetAllAsync(QueryParams queryParams)
        {
            return await _context.Users.Select(u => u).ToPagedResultAsync(queryParams);
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User?> UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}