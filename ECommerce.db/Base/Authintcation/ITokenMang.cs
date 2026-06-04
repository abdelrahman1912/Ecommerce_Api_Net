using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.db.Base.Authintcation
{
    public interface ITokenMang
    {
        string RefreshToken();

        List<Claim> GetClaims(string email);

        Task<bool> validateRefreshToken(string refreshToken);

        Task<string>getusridbyrefresh(string refreshToken);

        Task<int> addrefreshtoken(string userId, string refreshToken);

        Task<int>updaterefreshtoken(string userId, string refreshToken);
        string GenerateToken(List<Claim> claims);

    }
}
