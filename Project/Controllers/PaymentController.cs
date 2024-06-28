using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.DTOs;
using Project.Services.Abstraction;

namespace Project.Controllers
{
    [Authorize(Roles = "Employee")]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        
        private readonly IPaymentService _paymentService;
        
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        
        [HttpPost]
        public IActionResult AddPayment(int idContract, double amount)
        {
            _paymentService.PayForContract(idContract, amount);
            return Ok();
        }
    }
}
