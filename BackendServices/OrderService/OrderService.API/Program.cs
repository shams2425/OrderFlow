using Microsoft.EntityFrameworkCore;
using OrderService.Core.Interfaces;
using OrderService.Infrastructure.Data;
using OrderService.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<OrderDbContext>(opt =>
opt.UseSqlServer(builder.Configuration.GetConnectionString("OrderDbConnection"))
);

builder.Services.AddScoped<IOrderRepository, OrderRepository>();

var app = builder.Build();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
