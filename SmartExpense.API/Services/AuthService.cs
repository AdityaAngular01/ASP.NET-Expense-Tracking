using SmartExpense.API.DTOs.AuthDTOs;
using SmartExpense.API.Models;
using SmartExpense.API.Repositories.Auth;

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

            if (user == null || Password != authLoginDTO.Password)
                return null;

            return new
            {
                Token = _jwtService.GenerateToken(Id),
                LoggedUser = await _userService.GetUserById(Id),
            };
            
        }

        public async Task<object> Register(AuthRegisterDTO authRegisterDTO)
        {
            throw new NotImplementedException();
        }
    }
}