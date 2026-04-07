using SmartExpense.API.Repositories;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
    {
        // Repositories
        services.AddScoped<IExpenseRepository, ExpenseRepository>();

        return services;
    }
}