public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseAppMiddlewares(this IApplicationBuilder app)
    {
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        return app;
    }
}