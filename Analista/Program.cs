using Analista.Middlewares;
using Analista.Persintencia;
using Analista.Repositorios.Interfaces;
using Analista.Repositorios;
using Analista.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Analista.Models;
using Analista.Services;

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

// Repositorios
builder.Services.AddScoped<IRepositorio<Actor>, ActorRepositorio>();
builder.Services.AddScoped<IRepositorio<CasoDeUso>, CasoDeUsoRepositorio>();
builder.Services.AddScoped<IRepositorio<CondicionPorCasoDeUso>, CondicionPorCasoDeUsoRepositorio>();
builder.Services.AddScoped<IRepositorio<Condicion>, CondicionRepositorio>();
builder.Services.AddScoped<IRepositorio<CriterioDeAceptacion>, CriterioDeAcpetacionRepositorio>();
builder.Services.AddScoped<IRepositorio<Requisito>, RequisitoRepositorio>();
builder.Services.AddScoped<IRepositorio<Servicio>, ServicioRepositorio>();
builder.Services.AddScoped<IRepositorio<SubTipoRequisito>, SubTipoRequisitoRepositorio>();
builder.Services.AddScoped<IRepositorio<TipoRequisito>, TipoRequisitoRepositorio>();

// Unidad de Trabajo
builder.Services.AddScoped<IUnidadDeTrabajo, UnidadDeTrabajo>();

// Servicios
builder.Services.AddScoped<ITipoRequisitoService, TipoRequisitoService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Analista.xml"));
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
