using Project.Context;
using Project.DTOs;
using Project.Exceptions;
using Project.Models;
using Project.Repositories.Abstraction;

namespace Project.Services;

public class CompanyClientsService : ICompanyClientsService
{
    
    private readonly ICompanyClientsRepository _companyClientsRepository;
    
    public CompanyClientsService(ICompanyClientsRepository companyClientsRepository)
    {
        _companyClientsRepository = companyClientsRepository;
    }
    
    public async Task<CompanyClient> AddCompanyClient(AddCompanyClientDto clientDto)
    {
        var client = new CompanyClient
        {
            Address = clientDto.Address,
            Email = clientDto.Email,
            PhoneNumber = clientDto.PhoneNumber,
            CompanyName = clientDto.CompanyName,
            KrsNumber = clientDto.KrsNumber
        };

        await _companyClientsRepository.AddAsync(client);

        return client;
    }

    public async Task<CompanyClient> UpdateCompanyClient(int id, UpdateCompanyClientDto clientDto)
    {
        var client = await _companyClientsRepository.FindAsync(id);
        if (client == null)
        {
            throw new ClientNotFoundException("Client not found");
        }

        if (clientDto.PhoneNumber != null) client.PhoneNumber = clientDto.PhoneNumber;
        if (clientDto.Email != null) client.Email = clientDto.Email;
        if (clientDto.Address != null) client.Address = clientDto.Address;
        if (clientDto.CompanyName != null) client.KrsNumber = clientDto.CompanyName;

        await _companyClientsRepository.UpdateAsync(client);

        return client;
    }
}