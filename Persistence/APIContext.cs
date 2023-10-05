using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data.Configurations;

namespace Persistence;

/*
 * APIContext - Contexto de la base de datos para la aplicación.
 * 
 * Este contexto representa una sesión con la base de datos, permitiendo realizar operaciones CRUD en las entidades.
 * 
 * Propiedades:
 * - Users: Representa la tabla `Users` en la base de datos.
 * - Vehicles: Representa la tabla `Vehicles` en la base de datos.
 * 
 * Configuraciones:
 * El método `OnModelCreating` se utiliza para configurar el modelo de la base de datos. Aquí se pueden definir las relaciones, claves primarias, 
 * índices, y otros detalles de mapeo entre las entidades y la base de datos. En este caso estamos trayendo esas configuraciones desde otro lugar,
 * así no tenemos que definir esas propiedades directamente aquí
 */


public class APIContext : DbContext 
{
    /* Incluyendo las entidades */
    public DbSet<User> Users {get; set;}
    public DbSet<Vehicle> Vehicles {get; set;}

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        /* Aplicando las configuraciones antes definidas */
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new VehicleConfiguration());
    }
}
