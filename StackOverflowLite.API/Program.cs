var builder = WebApplication.CreateBuilder(args);

// Add controller support
builder.Services.AddControllers();

// Add API explorer for Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// HTTPS
app.UseHttpsRedirection();

// Authorization
app.UseAuthorization();

// Map controllers
app.MapControllers();

app.Run();