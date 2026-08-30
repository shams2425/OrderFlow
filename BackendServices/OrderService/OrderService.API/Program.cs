using Microsoft.EntityFrameworkCore;
using OrderService.Core.Interfaces;
using OrderService.Core.Mappers;
using AutoMapper;
using OrderService.Infrastructure.Data;
using OrderService.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAutoMapper(cfg => cfg.AddProfile<OrderMappingProfile>());

builder.Services.AddDbContext<OrderDbContext>(opt =>
opt.UseSqlServer(builder.Configuration.GetConnectionString("OrderDbConnection"))
);

builder.Services.AddScoped<IOrderRepository, OrderRepository>();

var app = builder.Build();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
