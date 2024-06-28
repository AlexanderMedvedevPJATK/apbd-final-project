using Project.DTOs;
using Project.Models;

namespace Project.Services.Abstraction;

public interface IContractService
{
    Task<Contract> CreateContract(AddContractDto contractDto);
}