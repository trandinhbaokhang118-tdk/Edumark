using EduMark.Api.Middleware;
using EduMark.Infrastructure;
using EduMark.Infrastructure.Persistence;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); builder.Services.AddEndpointsApiExplorer(); builder.Services.AddSwaggerGen(); builder.Services.AddInfrastructure(builder.Configuration);
var app = builder.Build();
app.UseMiddleware<ExceptionHandlingMiddleware>(); app.UseSwagger(); app.UseSwaggerUI();
app.MapGet("/health", () => Results.Ok(new { status = "healthy", service = "edumark-catalog-service", utc = DateTime.UtcNow })); app.MapControllers();
using (var scope = app.Services.CreateScope()) await DatabaseSeeder.SeedAsync(scope.ServiceProvider.GetRequiredService<EduMarkDbContext>());
app.Run();
public partial class Program { }
