using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHealthChecks()
    .AddRedis("localhost:6379"    )
    .AddNpgSql("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=postgres;");

var app = builder.Build();
app.UseHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.Run();
