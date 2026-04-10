using SmartExpense.API.DTOs.AuthDTOs;

namespace SmartExpense.API.Services.Auth
{
    public interface IAuthService
    {
        Task<object> Login(AuthLoginDTO authLoginDTO);
        Task<object> Register(AuthRegisterDTO authRegisterDTO);
    }
}