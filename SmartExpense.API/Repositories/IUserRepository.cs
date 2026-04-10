

using SmartExpense.API.DTOs;
using SmartExpense.API.DTOs.Responses;
using SmartExpense.API.Models;

namespace SmartExpense.API.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        
        Task AddAsync(User user);
        
        Task<User?> GetByIdAsync(int id);

        Task<PaginationDataDTO<User>> GetAllAsync(QueryParams queryParams);
        
        Task<bool> DeleteByIdAsync(User user);
        
        Task<User?> UpdateAsync(User user);

        Task<User?> GetUserByEmailAsync(string email);
    }
}