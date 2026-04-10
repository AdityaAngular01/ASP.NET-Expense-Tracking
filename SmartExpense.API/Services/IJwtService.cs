namespace SmartExpense.API.Services
{
    public interface IJwtService
    {
        string GenerateToken(int userId);
    }
}