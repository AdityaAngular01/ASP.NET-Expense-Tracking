public static class AuthExtensions
{
    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration config)
    {
        var key = config["Jwt:Key"];

        // Add JWT logic here

        return services;
    }
}