using SmartExpense.API.DTOs;
using SmartExpense.API.DTOs.Responses;
using SmartExpense.API.Models;
using SmartExpense.API.Repositories;
using AutoMapper;
using SmartExpense.API.DTOs.UserDTOs;
namespace SmartExpense.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<int> AddUser(UserDTO dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = dto.Password
            };

            await _repo.AddAsync(user);

            return user.Id;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _repo.GetByIdAsync(id);
            if (user == null)
                return false;
            
            return await _repo.DeleteByIdAsync(user);
        }

        public async Task<IEnumerable<object>> GetAllUsers()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<PaginationDataDTO<User>> GetAllUsers(QueryParams queryParams)
        {
            return await _repo.GetAllAsync(queryParams);
        }

        public async Task<User?> GetUserById(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<(User?, User?)> UpdateUser(int id, UserUpdateDTO dto)
        {
            var user = await _repo.GetByIdAsync(id);

            var oldUserData = _mapper.Map<User>(user);

            if (user == null)
                return (null, null);
            
            if(!string.IsNullOrWhiteSpace(dto.Name))
                user.Name = dto.Name;
            
            if(!string.IsNullOrWhiteSpace(dto.Email))
                user.Email = dto.Email;
            
            if(!string.IsNullOrWhiteSpace(dto.Password))
                user.PasswordHash = dto.Password;
            
            return (oldUserData, await _repo.UpdateAsync(user));
        }
    }
}