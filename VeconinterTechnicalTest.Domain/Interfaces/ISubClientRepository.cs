using VeconinterTechnicalTest.Domain.Entities;

namespace VeconinterTechnicalTest.Domain.Interfaces;

public interface ISubClientRepository
{
    Task<IEnumerable<SubClient>> GetAllByClientIdAsync(int clientId);
    Task<SubClient?> GetByIdAsync(int id);
    Task<SubClient> AddAsync(SubClient subClient);
    Task UpdateAsync(SubClient subClient);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);

}