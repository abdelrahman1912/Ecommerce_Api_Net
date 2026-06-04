using ECommerce.db.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.db.Base.Authintcation
{
    public interface IUserMang
    {
        Task<bool> CreateUser(AppUser user, string password);
        Task<bool> LoginUser(string user,string password);

        Task<AppUser?> GetUserByEmail(string email);

        Task<AppUser?> GetUserById(string userId);

        Task<IEnumerable<AppUser>> GetAllUsers();
        Task<int> removeuserbyid(string userId);
        Task<List<Claim>> GetUserClaim(string email);

    }
}
