using Microsoft.EntityFrameworkCore;
using Persistence;
using API.Extensions;
using System.Reflection;

/*
* CONFIGURACIÓN PREVIA
*
* Cuando creamos 'builder' estamos creando una instancia de configuración para nuestro proyecto
* de .NET a la que iremos añadiendo servicios tanto como requiera nuestro proyecto.
*
*Por ejemplo:
* Estamos agregando nuestro DbContext que previamente hemos definido en nuestra carpeta
* de persistencia. En la sentencia de este servicio estamos referenciando el string de conexión
* previamente definido en 'appsettings.json' y agregando una propiedad que configura automáticamente
* la versión del engine de MySQL 'ServerVersion.AutoDetect(connectionString)
*/

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
builder.Services.ConfigureCors();
builder.Services.AddApplicationServices();

builder.Services.AddDbContext<APIContext>(options =>{
    string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});


/*
* INICIO DE APLICACIÓN
*/
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
