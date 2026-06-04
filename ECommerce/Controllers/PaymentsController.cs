using ECommerce.lib.Base;
using ECommerce.lib.DTos.Payments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController(IPaymentMethodSrvc paymentSrvc) : ControllerBase
    {
        [HttpGet("PayMethods")]
        public async Task<ActionResult<IEnumerable<PaymentsMethodDto>>> GetPaymentMethodes()
        {
            var payMethods = await paymentSrvc.GetPaymentMethod();
            if(!payMethods.Any())
                return NotFound("No payment methods found.");
            return Ok(payMethods);
        }
    }
}
