using ECommerce.db.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.db.Base.Authintcation
{
    public interface IRoleMang
    {
        Task<string?> GetUserRole(string useremail);
        Task<bool> AddUserToRole(AppUser user, string rolename);
    }
}
