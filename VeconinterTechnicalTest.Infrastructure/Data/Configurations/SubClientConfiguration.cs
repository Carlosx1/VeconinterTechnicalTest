using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VeconinterTechnicalTest.Domain.Entities;

namespace VeconinterTechnicalTest.Infrastructure.Data.Configurations;

public class SubClientConfiguration : IEntityTypeConfiguration<SubClient>
{
    public void Configure(EntityTypeBuilder<SubClient> builder)
    {
        builder.ToTable("SubClients");
            
        builder.HasKey(sc => sc.Id);
            
        builder.Property(sc => sc.Name)
            .IsRequired()
            .HasMaxLength(100);
                
        builder.Property(sc => sc.Email)
            .IsRequired()
            .HasMaxLength(255);
                
        builder.Property(sc => sc.Phone)
            .IsRequired()
            .HasMaxLength(20);
                
        builder.Property(sc => sc.CreatedAt)
            .IsRequired();
                
        builder.Property(sc => sc.UpdatedAt)
            .IsRequired();
            
        // Índices
        builder.HasIndex(sc => sc.Email);
        builder.HasIndex(sc => sc.ClientId);

    }
}