using API.Data;
using API.Controller;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddDbContext<UserDataContext>();

var app = builder.Build();

app.MapControllers();

app.Run();
