using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VeconinterTechnicalTest.Application.Factories;
using VeconinterTechnicalTest.Application.Services.Implementation;
using VeconinterTechnicalTest.Application.Services.Interfaces;
using VeconinterTechnicalTest.Domain.Interfaces;
using VeconinterTechnicalTest.Infrastructure.Data;
using VeconinterTechnicalTest.Infrastructure.Data.Repositories;

namespace VeconinterTechnicalTest.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        // Base de datos
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            
        // Repositorios
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<ISubClientRepository, SubClientRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
            
        // Servicios de aplicación
        services.AddScoped<IClientService, ClientService>();
        services.AddScoped<ISubClientService, SubClientService>();
        services.AddScoped<IAuthService, AuthService>();
            
        // Factory Pattern
        services.AddScoped<IClientFactory, ClientFactory>();
            
        // Strategy Pattern - Validaciones
        services.AddScoped<EmailValidationStrategy>();
        services.AddScoped<PhoneValidationStrategy>();
            
        // AutoMapper
        services.AddAutoMapper(_ => { }, AppDomain.CurrentDomain.GetAssemblies());
            
        return services;
    }

}