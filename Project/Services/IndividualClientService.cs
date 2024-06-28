using Project.Context;
using Project.DTOs;
using Project.Exceptions;
using Project.Models;
using Project.Repositories.Abstraction;
using Project.Services.Abstraction;

namespace Project.Services;

public class IndividualClientService : IIndividualClientService
{
    
    private readonly IIndividualClientsRepository _individualClientsRepository;
    
    public IndividualClientService(IIndividualClientsRepository individualClientsRepository)
    {
        _individualClientsRepository = individualClientsRepository;
    }
    
    public async Task<IndividualClient> AddIndividualClient(AddIndividualClientDto clientDto)
    {
        var client = new IndividualClient
        {
            Address = clientDto.Address,
            Email = clientDto.Email,
            PhoneNumber = clientDto.PhoneNumber,
            FirstName = clientDto.FirstName,
            LastName = clientDto.LastName,
            Pesel = clientDto.Pesel
        };

        await _individualClientsRepository.AddAsync(client);
       
       return client;
    }

    public async Task<IndividualClient> UpdateIndividualClient(int id, UpdateIndividualClientDto clientDto)
    {
        var client = await _individualClientsRepository.FindByIdAsync(id);
        
        if (client == null)
        {
            throw new ClientNotFoundException("Client not found");
        }

        if (client.IsDeleted)
        {
            throw new DeletedClientException("Cannot update deleted client");
        }
        
        if (clientDto.PhoneNumber != null) client.PhoneNumber = clientDto.PhoneNumber;
        if (clientDto.Email != null) client.Email = clientDto.Email;
        if (clientDto.Address != null) client.Address = clientDto.Address;
        if (clientDto.FirstName != null) client.FirstName = clientDto.FirstName;
        if (clientDto.LastName != null) client.LastName = clientDto.LastName;

        await _individualClientsRepository.UpdateAsync(client);
        
        return client;
    }

    public async Task DeleteIndividualClient(int id)
    {
       await _individualClientsRepository.DeleteAsync(id);
    }
}