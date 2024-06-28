using Project.Models;

namespace Project.Repositories.Abstraction;

public interface IClientRepository
{
    Task<Client?> FindByIdAsync(int id);

    Task<bool> ClientHasContractOnThisSoftware(int clientId, int softwareId);
}