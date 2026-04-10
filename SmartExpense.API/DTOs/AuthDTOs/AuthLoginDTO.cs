namespace SmartExpense.API.DTOs.AuthDTOs
{
    public class AuthLoginDTO
    {
        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}