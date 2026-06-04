using ECommerce.Base;
using ECommerce.lib.DTos.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthintcationSrvc authintcationSrvc) : ControllerBase
    {   
        [HttpPost("Create")]
        public async Task<IActionResult> CreateUser(CreateUser createUser)
        {
            var result = await authintcationSrvc.createuser(createUser);
            return result.success ? Ok(result) : BadRequest(result);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser(LoginUser loginUser)
        {
            var result = await authintcationSrvc.Loginuser(loginUser);
            return result.success ? Ok(result) : BadRequest(result);
        }
        [HttpPost("Refresh Token")]
        public async Task<IActionResult>RefreshToken([FromQuery] string refreshToken)
        {
            var result = await authintcationSrvc.RetriveToken(refreshToken);
            return result.success ? Ok(result) : BadRequest(result);
        }
    }
}
