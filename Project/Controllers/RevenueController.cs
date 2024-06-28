using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Services.Abstraction;

namespace Project.Controllers
{
    
    [Authorize(Roles = "Employee")]
    [Route("api/[controller]")]
    [ApiController]
    public class RevenueController : ControllerBase
    {
        
        private readonly IRevenueService _revenueService;
        
        public RevenueController(IRevenueService revenueService)
        {
            _revenueService = revenueService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRevenueCompany()
        {
            var revenue = await _revenueService.GetRevenueCompany();
            return Ok("Company revenue: " + revenue + " PLN");
        }
        
        [HttpGet("{idSoftware:int}")]
        public async Task<IActionResult> GetRevenueSoftware(int idSoftware)
        {
            var revenue = await _revenueService.GetRevenueSoftware(idSoftware);
            return Ok("Software with id " + idSoftware + " revenue: " + revenue + " PLN");
        }
    }
}
