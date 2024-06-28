using Project.DTOs;
using Project.Models;

namespace Project.Services;

public interface ICompanyClientsService
{
    Task<CompanyClient> AddCompanyClient(AddCompanyClientDto clientDto);
    Task<CompanyClient> UpdateCompanyClient(int id, UpdateCompanyClientDto clientDto);
}