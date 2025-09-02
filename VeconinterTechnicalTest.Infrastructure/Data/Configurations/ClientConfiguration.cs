using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VeconinterTechnicalTest.Domain.Entities;

namespace VeconinterTechnicalTest.Infrastructure.Data.Configurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Clients");
            
        builder.HasKey(c => c.Id);
            
        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);
                
        builder.Property(c => c.Email)
            .IsRequired()
            .HasMaxLength(255);
                
        builder.Property(c => c.Phone)
            .IsRequired()
            .HasMaxLength(20);
                
        builder.Property(c => c.Company)
            .IsRequired()
            .HasMaxLength(100);
                
        builder.Property(c => c.CreatedAt)
            .IsRequired();
                
        builder.Property(c => c.UpdatedAt)
            .IsRequired();
            
        // Índices
        builder.HasIndex(c => c.Email).IsUnique();
            
        // Relación con SubClients
        builder.HasMany(c => c.SubClients)
            .WithOne(sc => sc.Client)
            .HasForeignKey(sc => sc.ClientId)
            .OnDelete(DeleteBehavior.Cascade);
        
        

    }
}