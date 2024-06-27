using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Context;
using Project.DTOs;
using Project.Models;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyClientsController : ControllerBase
    {
        private readonly ApbdProjectContext _context;

        public CompanyClientsController(ApbdProjectContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddCompanyClient(CompanyClientDto clientDto)
        {
         
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCompanyClient(int id, CompanyClientDto clientDto)
        {
            
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteCompanyClient(int id)
        {
            return Ok();
        }
    }
}