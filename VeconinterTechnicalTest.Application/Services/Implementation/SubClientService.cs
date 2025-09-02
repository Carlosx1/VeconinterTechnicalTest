using AutoMapper;
using VeconinterTechnicalTest.Application.DTOs;
using VeconinterTechnicalTest.Application.Factories;
using VeconinterTechnicalTest.Application.Services.Interfaces;
using VeconinterTechnicalTest.Domain.Interfaces;

namespace VeconinterTechnicalTest.Application.Services.Implementation;

public class SubClientService : ISubClientService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IClientFactory _clientFactory;
    private readonly IValidationStrategy<string> _emailValidation;
    private readonly IValidationStrategy<string> _phoneValidation;
    
    public SubClientService(
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
    public async Task<IEnumerable<SubClientDto>> GetSubClientsByClientIdAsync(int clientId)
    {
        var subClients = await _unitOfWork.SubClients.GetAllByClientIdAsync(clientId);
        return _mapper.Map<IEnumerable<SubClientDto>>(subClients);
    }

    public async Task<SubClientDto?> GetSubClientByIdAsync(int id)
    {
        var subClient = await _unitOfWork.SubClients.GetByIdAsync(id);
        return subClient != null ? _mapper.Map<SubClientDto>(subClient) : null;
    }

    public async Task<SubClientDto> CreateSubClientAsync(SubClientDto subClientDto)
    {
        // Validación usando Strategy Pattern
        if (!_emailValidation.IsValid(subClientDto.Email))
            throw new ArgumentException(_emailValidation.GetValidationMessage());
                
        if (!_phoneValidation.IsValid(subClientDto.Phone))
            throw new ArgumentException(_phoneValidation.GetValidationMessage());
            
        // Creación usando Factory Pattern
        var subClient = _clientFactory.CreateSubClient(subClientDto);
            
        var createdSubClient = await _unitOfWork.SubClients.AddAsync(subClient);
        await _unitOfWork.SaveChangesAsync();
            
        return _mapper.Map<SubClientDto>(createdSubClient);
    }

    public async Task<SubClientDto> UpdateSubClientAsync(SubClientDto subClientDto)
    {
        var existingSubClient = await _unitOfWork.SubClients.GetByIdAsync(subClientDto.Id);
        if (existingSubClient == null)
            throw new ArgumentException("SubCliente no encontrado");
            
        // Validación usando Strategy Pattern
        if (!_emailValidation.IsValid(subClientDto.Email))
            throw new ArgumentException(_emailValidation.GetValidationMessage());
                
        if (!_phoneValidation.IsValid(subClientDto.Phone))
            throw new ArgumentException(_phoneValidation.GetValidationMessage());
            
        existingSubClient.UpdateInfo(subClientDto.Name, subClientDto.Email, subClientDto.Phone);
            
        await _unitOfWork.SubClients.UpdateAsync(existingSubClient);
        await _unitOfWork.SaveChangesAsync();
            
        return _mapper.Map<SubClientDto>(existingSubClient);

    }

    public async Task DeleteSubClientAsync(int id)
    {
        await _unitOfWork.SubClients.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();

    }
}