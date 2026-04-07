using FluentValidation.AspNetCore;

public static class ValidationExtensions
{
    public static IServiceCollection AddValidation(this IServiceCollection services)
    {
        services.AddControllers()
            .AddFluentValidation(config =>
            {
                config.RegisterValidatorsFromAssemblyContaining<Program>();
            });

        return services;
    }
}