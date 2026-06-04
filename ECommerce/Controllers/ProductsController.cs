using ECommerce.lib.Base;
using ECommerce.lib.DTos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductServiecies srvProduct) : ControllerBase
    {
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var products = await srvProduct.GetAllAsync();
            if (products.Count() > 0)
            {
                return Ok(products);
            }
            else
            {
                return NoContent();
            }
        }
        [HttpGet("item/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await srvProduct.GetById(id);
            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost("add")]
        public async Task<IActionResult> Addnew(ProductDto product) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await srvProduct.AddAsync(product);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }

        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateProductDto product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await srvProduct.UpdateAsync(product);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }

        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await srvProduct.DeleteAsync(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }

        }
    }
}
