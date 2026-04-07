using Microsoft.EntityFrameworkCore;
using SmartExpense.API.Data;

public static class DatabaseExtensions
{
    public static IServiceCollection AddDatabase(
        this IServiceCollection services,
        IConfiguration config)
    {
        var connectionString =
            config.GetConnectionString("DefaultConnection")
            ?? config["DB_CONNECTION"];

        if (string.IsNullOrWhiteSpace(connectionString))
            throw new InvalidOperationException("Database connection string is not configured.");

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));

        return services;
    }
}