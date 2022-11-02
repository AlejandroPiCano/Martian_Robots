using MartianRobots.API.Security;
using MartianRobots.Application.Configurations;
using MartianRobots.Infrastructure;
using MartianRobots.Infrastructure.Configurations;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
   config.SwaggerDoc("v1", new OpenApiInfo() { Title = "Martian Robots API", Version = "V1" });
  
    config.AddSecurityDefinition("basic", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the basic scheme. Example: \"Basic {token}\"",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = SecuritySchemeType.Http.ToString()
    });
});

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

// Authentication using Basic authentication
builder.Services.AddAuthentication("BasicAuthentication")
 .AddScheme<AuthenticationSchemeOptions, APIBasicAuthenticationHandler>
 ("BasicAuthentication", null);
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
