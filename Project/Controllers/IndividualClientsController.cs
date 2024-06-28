using Microsoft.AspNetCore.Mvc;
using Project.DTOs;
using Project.Services;
using Project.Services.Abstraction;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndividualClientsController : ControllerBase
    {
        private readonly IIndividualClientsService _individualClientsService;

        public IndividualClientsController(IIndividualClientsService individualClientsService)
        {
            _individualClientsService = individualClientsService;
        }

        [HttpPost]
        public async Task<IActionResult> AddIndividualClient(AddIndividualClientDto clientDto)
        {
            var client = await _individualClientsService.AddIndividualClient(clientDto);
            return Created("api/individualClients", client);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateIndividualClient(int id, UpdateIndividualClientDto clientDto)
        {
            var client = await _individualClientsService.UpdateIndividualClient(id, clientDto);
            return Ok(client);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIndividualClient(int id)
        {
            await _individualClientsService.DeleteIndividualClient(id);
            return NoContent();
        }
    }
}
