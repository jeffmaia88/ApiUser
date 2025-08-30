using API.Controllers;
using API.Data;
using API.Repositories;
using API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

object value = builder.Services.AddDbContext<UserDataContext>(options =>
    options.UseSqlServer("Server=localhost,1433;Database=ApiDatabase;User ID=sa;Password=Figure09LP$;TrustServerCertificate=True;"));


builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserService>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
