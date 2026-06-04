using ECommerce.lib.Base;
using ECommerce.lib.DTos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryServicies srvCategory) : ControllerBase
    {

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var products = await srvCategory.GetAllAsync();
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
            var product = await srvCategory.GetById(id);
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
        public async Task<IActionResult> Addnew(CategoryDto product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);   
            }
            var result = await srvCategory.AddAsync(product);
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
        public async Task<IActionResult> Update(UpdateCategoryDto product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await srvCategory.UpdateAsync(product);
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
            var result = await srvCategory.DeleteAsync(id);
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
