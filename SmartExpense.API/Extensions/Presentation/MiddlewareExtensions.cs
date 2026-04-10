public static class MiddlewareExtensions
{
    public static IApplicationBuilder UsePresentation(
        this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseRouting();

        app.UseAuthentication();
        
        app.UseAuthorization();

        return app;
    }
}