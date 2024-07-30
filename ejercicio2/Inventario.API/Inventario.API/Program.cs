using Inventario.BL.Interfaces;
using Inventario.BL;
using Inventario.Common;
using Inventario.DAL;
using AutoMapper;
using Inventario.BL.Automapper;
using Inventario.DAL.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Otras configuraciones de servicios

// Registrar IProductoService
builder.Services.AddScoped<IProductoService, ProductoService>();



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddTransient<IProductoRepository, ProductoRepository>();
builder.Services.AddTransient<IDatabaseRepository, DatabaseRepository>();
builder.Services.AddAutoMapper(typeof(AutomapperProfile));


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

