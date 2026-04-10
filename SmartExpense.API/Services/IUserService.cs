using SmartExpense.API.DTOs;
using SmartExpense.API.DTOs.Responses;
using SmartExpense.API.DTOs.UserDTOs;
using SmartExpense.API.Models;

namespace SmartExpense.API.Services
{
    public interface IUserService
    {
        Task<IEnumerable<object>> GetAllUsers();

        Task<PaginationDataDTO<User>> GetAllUsers(QueryParams queryParams);

        Task<int> AddUser(UserDTO dto);

        Task<User?> GetUserById(int id);

        Task<bool> DeleteUser(int id);

        Task<(User?, User?)> UpdateUser(int id, UserUpdateDTO dto);

        Task<User?> GetUserByEmail(string email);
    }
}