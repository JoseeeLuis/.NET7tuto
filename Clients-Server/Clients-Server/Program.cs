﻿global using Clients_Server.Models;
global using Serilog;
using Clients_Server.Data;
using Clients_Server.Repositories;
using Clients_Server.Services.WorkerService;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IWorkerService, WorkerServices>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IWorkerDetailsRepository, WorkerDetailsRepository>();
builder.Services.AddScoped<IWorkerRepository, WorkerRepository>();
Log.Logger = new LoggerConfiguration()
                 .MinimumLevel
                 .Information()
                 .WriteTo.Console()
                 .WriteTo.File("logs/WorkersLogs-.txt",rollingInterval: RollingInterval.Day)
                 .CreateLogger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
