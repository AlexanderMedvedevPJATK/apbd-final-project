using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.DTOs;
using Project.Services;
using Project.Services.Abstraction;

namespace Project.Controllers
{
    [Authorize(Roles = "Employee")]
    [Route("api/[controller]")]
    [ApiController]
    public class IndividualClientController : ControllerBase
    {
        private readonly IIndividualClientService _individualClientService;

        public IndividualClientController(IIndividualClientService individualClientService)
        {
            _individualClientService = individualClientService;
        }

        [HttpPost]
        public async Task<IActionResult> AddIndividualClient(AddIndividualClientDto clientDto)
        {
            var client = await _individualClientService.AddIndividualClient(clientDto);
            return Created("api/individualClients", client);
        }

        [Authorize(Roles = "Admin")]
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateIndividualClient(int id, UpdateIndividualClientDto clientDto)
        {
            var client = await _individualClientService.UpdateIndividualClient(id, clientDto);
            return Ok(client);
        }
        
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIndividualClient(int id)
        {
            await _individualClientService.DeleteIndividualClient(id);
            return NoContent();
        }
    }
}
