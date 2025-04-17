using Analista.Middlewares;
using Analista.Persintencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Cargar el .env
DotNetEnv.Env.Load();

var host = Environment.GetEnvironmentVariable("DB_HOST");
var port = Environment.GetEnvironmentVariable("DB_PORT");
var database = Environment.GetEnvironmentVariable("DB_NAME");
var user = Environment.GetEnvironmentVariable("DB_USER");
var password = Environment.GetEnvironmentVariable("DB_PASSWORD");

// Armar cadena de conexión para PostgreSQL
var connectionString = $"Host={host};Port={port};Database={database};Username={user};Password={password}";

// Registrar el DbContext con Npgsql
builder.Services.AddDbContext<MiDbContext>(options =>
    options.UseNpgsql(connectionString));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{    
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "API Analista",
        Description = "Esta API facilita el trabajo de un analista funcional para la redacción de Requisitos y Casos de Uso "
    });
    options.EnableAnnotations();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ErrorLoggingMiddleware>(); //Middelware para registro de excepciones 

app.UseAuthorization();

app.MapControllers();

app.Run();
