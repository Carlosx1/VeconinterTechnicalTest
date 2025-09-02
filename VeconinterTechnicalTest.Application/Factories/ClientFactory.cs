using VeconinterTechnicalTest.Application.DTOs;
using VeconinterTechnicalTest.Domain.Entities;

namespace VeconinterTechnicalTest.Application.Factories;

public interface IClientFactory
{
    Client CreateClient(ClientDto clientDto);
    SubClient CreateSubClient(SubClientDto subClientDto);
}


public class ClientFactory : IClientFactory
{
    public Client CreateClient(ClientDto clientDto)
    {
        return new Client
        {
            Name = clientDto.Name,
            Email = clientDto.Email,
            Phone = clientDto.Phone,
            Company = clientDto.Company
        };

    }

    public SubClient CreateSubClient(SubClientDto subClientDto)
    {
        return new SubClient
        {
            Name = subClientDto.Name,
            Email = subClientDto.Email,
            Phone = subClientDto.Phone,
            ClientId = subClientDto.ClientId
        };

    }
}