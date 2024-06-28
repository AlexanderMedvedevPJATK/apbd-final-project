using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.DTOs;
using Project.Services.Abstraction;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly IContractService _contractService;
        
        public ContractController(IContractService contractService)
        {
            _contractService = contractService;
        }
        
        [HttpPost]
        public IActionResult AddContract(AddContractDto contractDto)
        {
            var contract = _contractService.CreateContract(contractDto);
            return Created("api/contract", contract);
        }
    }
}
