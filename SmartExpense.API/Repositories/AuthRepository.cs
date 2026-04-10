using Microsoft.EntityFrameworkCore;
using SmartExpense.API.Data;
using SmartExpense.API.Models;

namespace SmartExpense.API.Repositories.Auth
{
    public class AuthRepository : IAuthRepository
    {

        private readonly AppDbContext _context;

        public AuthRepository(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<(int Id, string Email, string Password)?> GetUserByEmailAsync(string email)
        {
            var user = await _context.Users.Select(u => new { Id = u.Id, Email = u.Email, Password = u.PasswordHash })
                                            .Where(u => u.Email == email)
                                            .FirstOrDefaultAsync();
                                            
            if (user == null) return null;

            return (user.Id, user.Email, user.Password);
        }

        public async Task RegisterAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}