using FluentValidation;
using MartianRobots.Application.Configurations;
using MartianRobots.Domain.Services.Contracts;
using MartianRobots.Infrastructure;
using MartianRobots.Infrastructure.Configurations;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adding Validations
builder.Services.AddFluentValidationConfiguration();

// Adding Auto mapper
builder.Services.AddAutoMapperConfiguration();

//MongoDB
builder.Services.AddMongoDBConfiguration(builder.Configuration.GetSection(nameof(MongoDBDatabaseSettings)), builder.Configuration.GetValue<string>("MongoDBDatabaseSettings:ConnectionString"));

// Add Infrastructure Services
builder.Services.AddInfrastructureServicesConfiguration();

// Add Application Services
builder.Services.AddApplicationServicesConfiguration();

// Adding MediatR for Domain Events and Notifications
var assemblies = AppDomain.CurrentDomain.GetAssemblies();
builder.Services.AddMediatRConfiguration(assemblies);

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
