using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Services.Abstraction;

namespace Project.Controllers
{
    [Authorize(Roles = "Employee")]
    [Route("api/[controller]")]
    [ApiController]
    public class PredictedRevenueController : ControllerBase
    {

        private readonly IPredictedRevenueService _predictedRevenueService;

        public PredictedRevenueController(IPredictedRevenueService predictedRevenueService)
        {
            _predictedRevenueService = predictedRevenueService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPredictedRevenueCompany()
        {
            var revenue = await _predictedRevenueService.GetPredictedRevenueCompany();
            return Ok("Company predicted revenue: " + revenue + " PLN");
        }

        [HttpGet("{idSoftware:int}")]
        public async Task<IActionResult> GetPredictedRevenueSoftware(int idSoftware)
        {
            var revenue = await _predictedRevenueService.GetPredictedRevenueSoftware(idSoftware);
            return Ok("Software with id " + idSoftware + " predicted revenue: " + revenue + " PLN");
        }
    }
}
