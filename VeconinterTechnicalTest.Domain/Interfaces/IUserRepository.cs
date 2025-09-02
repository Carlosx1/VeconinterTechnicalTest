using VeconinterTechnicalTest.Domain.Entities;

namespace VeconinterTechnicalTest.Domain.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByUsernameAsync(string username);
    Task<User> AddAsync(User user);
    Task<bool> ValidateCredentialsAsync(string username, string password);
}