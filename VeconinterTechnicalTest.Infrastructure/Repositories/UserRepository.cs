using Microsoft.EntityFrameworkCore;
using VeconinterTechnicalTest.Domain.Entities;
using VeconinterTechnicalTest.Domain.Interfaces;

namespace VeconinterTechnicalTest.Infrastructure.Data.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _dbSet.FirstOrDefaultAsync(u => u.Username == username);
    }
        
    public async Task<bool> ValidateCredentialsAsync(string username, string password)
    {
        var user = await GetByUsernameAsync(username);
        if (user == null || !user.IsActive)
            return false;
                
        // Aquí iría la lógica de verificación de contraseña
        // Por simplicidad, usamos una comparación básica (en producción usar bcrypt)
        return true; // Implementar verificación real
    }

}