using FluentValidation;
using MartianRobots.API.Configurations;
using MartianRobots.Application.DTOs;
using MartianRobots.Application.DTOs.Validators;
using MartianRobots.Application.Services;
using MartianRobots.Domain.Entities;
using MartianRobots.Domain.Repository.Contracts;
using MartianRobots.Domain.Services;
using MartianRobots.Domain.Services.Contracts;
using MartianRobots.Infrastructure;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adding Validations
builder.Services.AddScoped<IValidator<MartianRobotDTO>, MartianRobotDTOValidator>();
builder.Services.AddScoped<IValidator<MartianRobotsInputDTO>, MartianRobotsInputDTOValidator>();
builder.Services.AddScoped<IValidator<MartianRobotsOutputDTO>, MartianRobotsOutputDTOValidator>();

// Adding Automapper
builder.Services.AddAutoMapperConfiguration();

//MongoDB
builder.Services.AddScoped<IRepository<MartianRobotsInput>, MartianRobotInputMongoDBRepository>();
builder.Services.AddScoped<IRepository<MartianRobotsOutput>, MartianRobotOutputMongoDBRepository>();
builder.Services.Configure<MongoDBDatabaseSettings>(builder.Configuration.GetSection(nameof(MongoDBDatabaseSettings)));
builder.Services.AddSingleton<IMongoDBDatabaseSettings>(sp => sp.GetRequiredService<IOptions<MongoDBDatabaseSettings>>().Value);
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("MongoDBDatabaseSettings:ConnectionString")));

// Add Services
builder.Services.AddScoped<IMartianRobotsDomainService, MartianRobotsDomainService>();
builder.Services.AddScoped<IMartianRobotsInputApplicationService, MartianRobotsInputApplicationService>();
builder.Services.AddScoped<IMartianRobotsOutputApplicationService, MartianRobotsOutputApplicationService>();
builder.Services.AddScoped<IMartianRobotsApplicationService, MartianRobotsApplicationService>();

// Adding MediatR for Domain Events and Notifications
var assemblies = AppDomain.CurrentDomain.GetAssemblies();
builder.Services.AddMediatR(assemblies);

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
