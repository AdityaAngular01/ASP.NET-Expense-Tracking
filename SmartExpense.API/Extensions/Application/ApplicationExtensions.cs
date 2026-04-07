using SmartExpense.API.Services;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        // Services (Business Logic)
        services.AddScoped<IExpenseService, ExpenseService>();

        return services;
    }
}