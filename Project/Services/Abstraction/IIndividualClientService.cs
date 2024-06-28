using Project.DTOs;
using Project.Models;

namespace Project.Services.Abstraction;

public interface IIndividualClientService
{
    Task<IndividualClient> AddIndividualClient(AddIndividualClientDto clientDto);
    Task<IndividualClient> UpdateIndividualClient(int id, UpdateIndividualClientDto clientDto);
    Task DeleteIndividualClient(int id);
}