using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Persistence.Data.Configurations;
public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder){
        builder.ToTable("Vehicles");

        builder.Property(v => v.Model).IsRequired();
        builder.Property(v => v.Year).IsRequired();
        builder.Property(v => v.Color).IsRequired();
    }
}