using ECommerce.db.Base.Authintcation;
using ECommerce.db.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.db.Repos.Authintcation
{
    public class RoleMang(UserManager<AppUser> userManager) : IRoleMang
    {
        public async Task<bool> AddUserToRole(AppUser user, string rolename)
        {
            return (await userManager.AddToRoleAsync(user, rolename)).Succeeded;
        }

        public async Task<string?> GetUserRole(string useremail)
        {
            var user =await userManager.FindByEmailAsync(useremail);
            return (await userManager.GetRolesAsync(user!)).FirstOrDefault();
        }
    }
}
