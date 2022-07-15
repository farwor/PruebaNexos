using Datos.Models;
using Microsoft.EntityFrameworkCore;
using Servicios.Autor;
using Servicios.Libro;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var cadenaConexion = builder.Configuration.GetConnectionString("PruebaNexos");

builder.Services.AddDbContext<ModelContext>(options =>
    options.UseOracle(
        cadenaConexion,
        options => options.UseOracleSQLCompatibility("11")
    )
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ILibroService, LibroService>();
builder.Services.AddTransient<IAutorService, AutorService>();

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
