using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Persistence.Data.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder){
        builder.ToTable("User");

        builder.Property(u => u.Username).IsRequired().HasMaxLength(50);
        builder.Property(u => u.Password).IsRequired();
        builder.Property(u => u.Email).IsRequired();

        builder.HasMany(u => u.Vehicles) // User
            .WithOne(v => v.User) // Vehice
            .HasForeignKey(v => v.IdUser); // Vehicle
    }
}
