using SmartExpense.API.Services;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        // Business Services
        services.AddScoped<IExpenseService, ExpenseService>();
        services.AddScoped<IUserService, UserService>();

        // AutoMapper (scan entire Application layer)
        services.AddAutoMapper(typeof(ApplicationExtensions).Assembly);

        return services;
    }
}