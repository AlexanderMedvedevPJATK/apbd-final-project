using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Context;
using Project.DTOs;
using Project.Models;
using Project.Services;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyClientsController : ControllerBase
    {
        private readonly ICompanyClientsService _companyClientsService;

        public CompanyClientsController(ICompanyClientsService companyClientsService)
        {
            _companyClientsService = companyClientsService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCompanyClient(AddCompanyClientDto clientDto)
        {
            Console.WriteLine("AddCompanyClient");
            var client = await _companyClientsService.AddCompanyClient(clientDto);
            return Created("api/companyClients", client);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateCompanyClient(int id, UpdateCompanyClientDto clientDto)
        {
            Console.WriteLine("ENTER UpdateCompanyClient");
            var client = await _companyClientsService.UpdateCompanyClient(id, clientDto);
            return Ok(client);
        }
    }
}