using SmartExpense.API.DTOs.AuthDTOs;
using SmartExpense.API.Models;
using SmartExpense.API.Repositories.Auth;
using BCrypt.Net;

namespace SmartExpense.API.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IJwtService _jwtService;

        private readonly IUserService _userService;
        public AuthService(IAuthRepository authRepository, IJwtService jwtService, IUserService userService)
        {
            _authRepository = authRepository;
            _jwtService = jwtService;
            _userService = userService;
        }


        public async Task<object> Login(AuthLoginDTO authLoginDTO)
        {
            var user = await _authRepository.GetUserByEmailAsync(authLoginDTO.Email);

            var (Id, Email, Password) = user.Value;

            if (user == null)
                return null;
            
            if (!BCrypt.Net.BCrypt.Verify(text: authLoginDTO.Password, hash: Password))
                return null;

            return new
            {
                Token = _jwtService.GenerateToken(Id),
                LoggedUser = await _userService.GetUserById(Id),
            };
            
        }

        public async Task<object> Register(AuthRegisterDTO authRegisterDTO)
        {
            Console.WriteLine($"Received registration request for email: {authRegisterDTO.Email}, name: {authRegisterDTO.Name} {authRegisterDTO.Password} {authRegisterDTO.ConfirmPassword}");
            var newUser = new User
            {
                Email = authRegisterDTO.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(authRegisterDTO.Password),
                Name = authRegisterDTO.Name
            };

            await _authRepository.RegisterAsync(newUser);
            
            return newUser.Id;
        }
    }
}