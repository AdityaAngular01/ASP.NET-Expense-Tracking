using FluentValidation.AspNetCore;

public static class PresentationExtensions
{
    public static IServiceCollection AddPresentation(
        this IServiceCollection services)
    {
        services.AddControllers();

        services.AddFluentValidation(config =>
        {
            config.RegisterValidatorsFromAssemblyContaining<Program>();
        });

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
}