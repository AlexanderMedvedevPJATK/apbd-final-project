using System.Globalization;
using Microsoft.IdentityModel.Tokens;
using Project.Config;
using Project.DTOs;
using Project.Exceptions;
using Project.Models;
using Project.Repositories.Abstraction;
using Project.Services.Abstraction;

namespace Project.Services;

public class ContractService : IContractService
{
    private readonly ISoftwareRepository _softwareRepository;
    private readonly IContractRepository _contractRepository;
    private readonly IClientRepository _clientRepository;
    
    public ContractService(
        ISoftwareRepository softwareRepository,
        IContractRepository contractRepository,
        IClientRepository clientRepository)
    {
        _softwareRepository = softwareRepository;
        _contractRepository = contractRepository;
        _clientRepository = clientRepository;
    }
    
    public async Task<Contract> CreateContract(AddContractDto contractDto)
    {

        var software = await _softwareRepository.FindByIdAsync(contractDto.SoftwareSystemId);
        
        if (software == null)
        {
            throw new SoftwareNotFoundException("Software not found");
        }
        
        var client = await _clientRepository.FindByIdAsync(contractDto.ClientId);
        if (client == null)
        {
            throw new ClientNotFoundException("Client not found");
        }
        
        if (client is IndividualClient individualClient && individualClient.IsDeleted)
        {
            throw new DeletedClientException("Cannot create contract for deleted client");
        }
        
        if (await _clientRepository.ClientHasContractOnThisSoftware(client.IdClient, software.Id))
        {
            throw new ClientAlreadyHasContractException("Client already has a contract on this software");
        }
        
        if (contractDto.EndDate < contractDto.StartDate)
        {
            throw new InvalidDateRangeException("End date must be after start date");
        }
        
        var contractTimeSpan = (contractDto.EndDate - contractDto.StartDate).Days;
        if (contractTimeSpan < 3)
        {
            throw new InvalidDateRangeException("Contract duration must be at least 3 days");
        }
        if (contractTimeSpan > 30)
        {
            throw new InvalidDateRangeException("Contract duration must be at most 30 days");
        }
        
        var parts = contractDto.BasePrice.ToString(new CultureInfo("en-US")).Split('.');
        if (parts.Length == 2 && parts[1].Length > 2)
        {
            throw new InvalidPriceException("Price must have at most 2 decimal places");
        }
        
        if (contractDto.BasePrice < 0)
        {
            throw new InvalidPriceException("Base price must be a positive number");
        }
        
        if (contractDto.DurationInYears < 1)
        {
            throw new InvalidSupportDurationException("Duration must be at least 1 year");
        }
        if (contractDto.DurationInYears > 3)
        {
            throw new InvalidSupportDurationException("Duration must be at most 3 years");
        }
        
        if (contractDto.SoftwareSystemVersion == null)
        {
            contractDto.SoftwareSystemVersion = software.Version;
        }

        if (!software.Discounts.IsNullOrEmpty()) 
        {
            var maximalDiscount = software.GetMaximalDiscount();
            contractDto.BasePrice -= contractDto.BasePrice * maximalDiscount.Percentage;
        }
        
        if (contractDto.PreviousClientDiscount)
        {
            contractDto.BasePrice -= contractDto.BasePrice * AppSettings.PreviousClientDiscount;
        }
        
        var contract = new Contract
        {
            SoftwareSystem = software,
            Client = client,
            Price = Math.Floor(contractDto.BasePrice * 100) / 100,
            StartDate = contractDto.StartDate,
            EndDate = contractDto.EndDate,
            DurationInYears = contractDto.DurationInYears,
            SoftwareSystemVersion = contractDto.SoftwareSystemVersion,
            Updates = contractDto.Updates
        };
        
        await _contractRepository.AddAsync(contract);
        
        return contract;
    }
}