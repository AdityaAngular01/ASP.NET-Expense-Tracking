using SmartExpense.API.Models;

namespace SmartExpense.API.Repositories.Auth
{
    public interface IAuthRepository
    {
        Task RegisterAsync(User user);

        Task<(int Id, string Email, string Password)?> GetUserByEmailAsync(string email);
    }
}