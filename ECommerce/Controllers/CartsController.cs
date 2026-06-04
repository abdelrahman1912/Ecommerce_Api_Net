using ECommerce.Base;
using ECommerce.lib.DTos.Carts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController(ICartsSrvc cartsSrvc) : ControllerBase
    {
        [HttpPost("checkout")]
        public async Task<IActionResult> Checkout([FromBody] CheckoutDto checkout)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            else
            {
                var result = await cartsSrvc.Dbcheckout(checkout, "0");
                return result.success ? Ok(result) : BadRequest(result);
            }
        }
        [HttpPost("saveCheckout")]
        public async Task<IActionResult> SaveCheckout([FromBody] IEnumerable<ProductHistoryDto> productHistoryDtos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var result = await cartsSrvc.SaveCheckoutHistory(productHistoryDtos);
                return result.success ? Ok(result) : BadRequest(result);
            }
        }
    }
}