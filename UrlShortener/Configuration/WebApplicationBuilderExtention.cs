using System.Reflection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;

namespace UrlShortener.Configuration;

/// <summary>
/// Some extension methods for application configuration
/// </summary>
public static class ApplicationServiceExtension
{
    /// <summary>
    /// Add swagger configuration like auth and description etc
    /// </summary>
    /// <param name="builder"></param>
    public static void AddSwaggerConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(c =>
        {
            var securityScheme = new OpenApiSecurityScheme()
            {
                Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            };
    
            var securityReauirement = new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            };
            
            c.EnableAnnotations();
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "UrlShortener", Version = "v1"});
            c.IncludeXmlComments(XmlCommentsFilePath);
            c.CustomSchemaIds(type => type.FullName);
            c.AddSecurityDefinition("Bearer", securityScheme);
            c.AddSecurityRequirement(securityReauirement);
        });
    }
    
    static string XmlCommentsFilePath
    {
        get
        {
            var basePath = PlatformServices.Default.Application.ApplicationBasePath;
            var fileName = typeof(Program).GetTypeInfo().Assembly.GetName().Name + ".xml";
            return Path.Combine(basePath, fileName);
        }
    }

}