using Microsoft.EntityFrameworkCore;
using VeconinterTechnicalTest.Domain.Entities;
using VeconinterTechnicalTest.Domain.Interfaces;

namespace VeconinterTechnicalTest.Infrastructure.Data.Repositories;

public class SubClientRepository : BaseRepository<SubClient>, ISubClientRepository
{
    public SubClientRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<SubClient>> GetAllByClientIdAsync(int clientId)
    {
        return await _dbSet
            .Include(sc => sc.Client)
            .Where(sc => sc.ClientId == clientId)
            .OrderBy(sc => sc.Name)
            .ToListAsync();
    }
        
    public override async Task<SubClient?> GetByIdAsync(int id)
    {
        return await _dbSet
            .Include(sc => sc.Client)
            .FirstOrDefaultAsync(sc => sc.Id == id);
    }

}