using VeconinterTechnicalTest.Application.DTOs;

namespace VeconinterTechnicalTest.Application.Services.Interfaces;

public interface ISubClientService
{
    Task<IEnumerable<SubClientDto>> GetSubClientsByClientIdAsync(int clientId);
    Task<SubClientDto?> GetSubClientByIdAsync(int id);
    Task<SubClientDto> CreateSubClientAsync(SubClientDto subClientDto);
    Task<SubClientDto> UpdateSubClientAsync(SubClientDto subClientDto);
    Task DeleteSubClientAsync(int id);
}