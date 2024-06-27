using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Context;
using Project.DTOs;
using Project.Models;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndividualClientsController : ControllerBase
    {
        private readonly ApbdProjectContext _context;

        public IndividualClientsController(ApbdProjectContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddIndividualClient(IndividualClientDto clientDto)
        {
         
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateIndividualClient(int id, IndividualClientDto clientDto)
        {
            
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteIndividualClient(int id)
        {
            return Ok();
        }
    }
}
