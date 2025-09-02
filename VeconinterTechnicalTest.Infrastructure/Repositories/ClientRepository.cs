using Microsoft.EntityFrameworkCore;
using VeconinterTechnicalTest.Domain.Entities;
using VeconinterTechnicalTest.Domain.Interfaces;

namespace VeconinterTechnicalTest.Infrastructure.Data.Repositories;

public class ClientRepository : BaseRepository<Client>, IClientRepository
{
    public ClientRepository(ApplicationDbContext context) : base(context)
    {
    }

    public override async Task<Client?> GetByIdAsync(int id)
    {
        return await _dbSet
            .Include(c => c.SubClients)
            .FirstOrDefaultAsync(c => c.Id == id);
    }
        
    public async Task<Client?> GetByEmailAsync(string email)
    {
        return await _dbSet
            .Include(c => c.SubClients)
            .FirstOrDefaultAsync(c => c.Email == email);
    }
        
    public override async Task<IEnumerable<Client>> GetAllAsync()
    {
        return await _dbSet
            .Include(c => c.SubClients)
            .OrderBy(c => c.Name)
            .ToListAsync();
    }

}