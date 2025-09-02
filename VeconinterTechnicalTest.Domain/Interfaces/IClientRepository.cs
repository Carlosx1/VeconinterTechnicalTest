using VeconinterTechnicalTest.Domain.Entities;

namespace VeconinterTechnicalTest.Domain.Interfaces;

public interface IClientRepository
{
    Task<IEnumerable<Client>> GetAllAsync();
    Task<Client?> GetByIdAsync(int id);
    Task<Client?> GetByEmailAsync(string email);
    Task<Client> AddAsync(Client client);
    Task UpdateAsync(Client client);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);

}