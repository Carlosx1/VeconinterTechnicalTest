using System.Reflection;
using Microsoft.EntityFrameworkCore;
using VeconinterTechnicalTest.Domain.Entities;

namespace VeconinterTechnicalTest.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<SubClient> SubClients { get; set; }
    public DbSet<User> Users { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
            
        // Aplicar todas las configuraciones del assembly actual
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
        // Datos iniciales
        SeedData(modelBuilder);
    }
    
    private static void SeedData(ModelBuilder modelBuilder)
    {
        // Usuario administrador por defecto
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                Username = "admin",
                Email = "admin@company.com",
                PasswordHash = "jGl25bVBBBW96Qi9Te4V37Fnqchz/Eu4qB9vKrRIqRg=", // "admin123"
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            }
        );
    }


    
}