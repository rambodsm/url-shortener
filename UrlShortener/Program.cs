using UrlShortener.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.AddSwaggerConfiguration();

var app = builder.Build();

app.UseSwaggerConfiguration();

app.Run();