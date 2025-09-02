using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VeconinterTechnicalTest.Domain.Entities;

namespace VeconinterTechnicalTest.Infrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
            
        builder.HasKey(u => u.Id);
            
        builder.Property(u => u.Username)
            .IsRequired()
            .HasMaxLength(50);
                
        builder.Property(u => u.PasswordHash)
            .IsRequired()
            .HasMaxLength(255);
                
        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(255);
                
        builder.Property(u => u.CreatedAt)
            .IsRequired();
                
        builder.Property(u => u.IsActive)
            .IsRequired();
            
        // Índices
        builder.HasIndex(u => u.Username).IsUnique();
        builder.HasIndex(u => u.Email).IsUnique();
    }
}