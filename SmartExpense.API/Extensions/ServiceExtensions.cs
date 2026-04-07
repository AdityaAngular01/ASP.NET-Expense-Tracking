using SmartExpense.API.Repositories;
using SmartExpense.API.Services;

public static class ServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IExpenseRepository, ExpenseRepository>();
        services.AddScoped<IExpenseService, ExpenseService>();

        return services;
    }
}