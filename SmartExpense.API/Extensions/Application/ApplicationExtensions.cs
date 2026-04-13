using SmartExpense.API.Services;
using SmartExpense.API.Services.Auth;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        // Business Services
        services.AddScoped<IExpenseService, ExpenseService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ICategoryService, CategoryService>();

        // JWT Service
        services.AddScoped<IJwtService, JwtService>();

        // Current User Service
        services.AddHttpContextAccessor();
        services.AddScoped<ICurrentUserService, CurrentUserService>();

        // AutoMapper (scan entire Application layer)
        services.AddAutoMapper(typeof(ApplicationExtensions).Assembly);

        return services;
    }
}