using Microsoft.EntityFrameworkCore;
using Mini_Blockchain.Data;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.Use(async (context, next) =>
{
    Console.WriteLine($"{DateTime.Now} | {context.Request.Method} {context.Request.Path}");
    await next();
});

app.UseAuthorization();

app.MapControllers();

app.Run();