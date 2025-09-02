using AutoMapper;
using VeconinterTechnicalTest.Application.DTOs;
using VeconinterTechnicalTest.Application.Factories;
using VeconinterTechnicalTest.Application.Services.Interfaces;
using VeconinterTechnicalTest.Domain.Interfaces;

namespace VeconinterTechnicalTest.Application.Services.Implementation;

public class ClientService : IClientService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IClientFactory _clientFactory;
    private readonly IValidationStrategy<string> _emailValidation;
    private readonly IValidationStrategy<string> _phoneValidation;

    public ClientService(
        IUnitOfWork unitOfWork, 
        IMapper mapper, 
        IClientFactory clientFactory,
        IValidationStrategy<string> emailValidation, 
        IValidationStrategy<string> phoneValidation)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _clientFactory = clientFactory;
        _emailValidation = emailValidation;
        _phoneValidation = phoneValidation;
    }


    public async Task<IEnumerable<ClientDto>> GetAllClientsAsync()
    {
        var clients = await _unitOfWork.Clients.GetAllAsync();
        return _mapper.Map<IEnumerable<ClientDto>>(clients);

    }

    public async Task<ClientDto?> GetClientByIdAsync(int id)
    {
        var client = await _unitOfWork.Clients.GetByIdAsync(id);
        return client != null ? _mapper.Map<ClientDto>(client) : null;

    }

    public async Task<ClientDto> CreateClientAsync(ClientDto clientDto)
    {
        // Validación usando Strategy Pattern
        if (!_emailValidation.IsValid(clientDto.Email))
            throw new ArgumentException(_emailValidation.GetValidationMessage());
                
        if (!_phoneValidation.IsValid(clientDto.Phone))
            throw new ArgumentException(_phoneValidation.GetValidationMessage());
            
        // Creación usando Factory Pattern
        var client = _clientFactory.CreateClient(clientDto);
            
        var createdClient = await _unitOfWork.Clients.AddAsync(client);
        await _unitOfWork.SaveChangesAsync();
            
        return _mapper.Map<ClientDto>(createdClient);
    }

    public async Task<ClientDto> UpdateClientAsync(ClientDto clientDto)
    {
        var existingClient = await _unitOfWork.Clients.GetByIdAsync(clientDto.Id);
        if (existingClient == null)
            throw new ArgumentException("Cliente no encontrado");
            
        // Validación usando Strategy Pattern
        if (!_emailValidation.IsValid(clientDto.Email))
            throw new ArgumentException(_emailValidation.GetValidationMessage());
                
        if (!_phoneValidation.IsValid(clientDto.Phone))
            throw new ArgumentException(_phoneValidation.GetValidationMessage());
            
        existingClient.UpdateInfo(clientDto.Name, clientDto.Email, clientDto.Phone, clientDto.Company);
            
        await _unitOfWork.Clients.UpdateAsync(existingClient);
        await _unitOfWork.SaveChangesAsync();
            
        return _mapper.Map<ClientDto>(existingClient);

    }

    public async Task DeleteClientAsync(int id)
    {
        await _unitOfWork.Clients.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();

    }

    public async Task<bool> ClientExistsAsync(int id)
    {
        return await _unitOfWork.Clients.ExistsAsync(id);
    }
}