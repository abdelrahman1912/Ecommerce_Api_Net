using ECommerce.lib.DTos;
using ECommerce.lib.DTos.Identity;

namespace ECommerce.Base
{
    public interface IAuthintcationSrvc
    {
        Task<ResponseDto> createuser(CreateUser User);
        Task<LoginDto> Loginuser(LoginUser User);
        Task<LoginDto> RetriveToken(string refreshToken);
    }
}
