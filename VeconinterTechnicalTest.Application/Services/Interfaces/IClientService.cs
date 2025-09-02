using VeconinterTechnicalTest.Application.DTOs;

namespace VeconinterTechnicalTest.Application.Services.Interfaces;

public interface IClientService
{
    Task<IEnumerable<ClientDto>> GetAllClientsAsync();
    Task<ClientDto?> GetClientByIdAsync(int id);
    Task<ClientDto> CreateClientAsync(ClientDto clientDto);
    Task<ClientDto> UpdateClientAsync(ClientDto clientDto);
    Task DeleteClientAsync(int id);
    Task<bool> ClientExistsAsync(int id);

}