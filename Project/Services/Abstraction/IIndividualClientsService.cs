using Project.DTOs;
using Project.Models;

namespace Project.Services.Abstraction;

public interface IIndividualClientsService
{
    Task<IndividualClient> AddIndividualClient(AddIndividualClientDto clientDto);
    Task<IndividualClient> UpdateIndividualClient(int id, UpdateIndividualClientDto clientDto);
    Task DeleteIndividualClient(int id);
}