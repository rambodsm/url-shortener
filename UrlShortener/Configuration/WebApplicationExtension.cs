namespace UrlShortener.Configuration;

/// <summary>
/// Some extension method for "webApplication" class and config middlewares
/// </summary>
public static class WebApplicationExtension
{
    /// <summary>
    /// Add swagger json configuration and add swagger middleware
    /// </summary>
    /// <param name="application"></param>
    public static void UseSwaggerConfiguration(this WebApplication application)
    {
        application.UseSwagger(options => { options.RouteTemplate = "swagger/{documentName}/docs.json"; });
        application.UseSwaggerUI(options => options.RoutePrefix = "swagger");
    }
}