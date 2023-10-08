using Domain.Interfaces;
using Application.UnitOfWork;

/*
 * EXTENSIONES DE SERVICIOS DE APLICACIÓN
 * 
 * Este archivo contiene métodos de extensión para IServiceCollection, facilitando la configuración y el registro
 * de servicios en la aplicación de manera organizada y modular.
 * 
 * RAZONES PARA ESTE ARCHIVO:
 * 1. Desacoplamiento: Al utilizar interfaces (como IUnitOfWork), el código no depende directamente de implementaciones específicas.
 *    Esto permite flexibilidad, facilita las pruebas y promueve una arquitectura limpia y mantenible.
 * 
 * 2. Centralización: Agrupar configuraciones relacionadas, como CORS y servicios de aplicación, en métodos de extensión
 *    ayuda a mantener el código de configuración principal (como Startup.cs) limpio y fácil de leer.
 * 
 * CONTENIDO PRINCIPAL:
 * 1. ConfigureCors: Configura la política CORS de la aplicación. CORS (Cross-Origin Resource Sharing) es esencial
 *    para controlar qué recursos de la aplicación pueden ser accedidos y desde qué orígenes, especialmente en aplicaciones web.
 * 
 * 2. AddApplicationServices: Registra servicios específicos de la aplicación, como el UnitOfWork, que se utilizan en toda la aplicación.
 *    La inyección de dependencias facilita la provisión de instancias de estos servicios donde se necesiten.
 * 
 * RECOMENDACIÓN:
 * Mantenga este archivo enfocado en extensiones relacionadas con la configuración de servicios de la aplicación. Si surgen
 * otras categorías de configuración, considere organizarlas en sus propios archivos de extensión para mantener una estructura clara.
 */

namespace API.Extensions;
public static class ApplicationServiceExtension
{
    public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()    //WithOrigins("https://domain.com")
                    .AllowAnyMethod()       //WithMethods("GET","POST)
                    .AllowAnyHeader());     //WithHeaders("accept","content-type")
        });
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    
}
