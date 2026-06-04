using ECommerce.db.Base.Authintcation;
using ECommerce.db.Context;
using ECommerce.db.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.db.Repos.Authintcation
{
    public class UserMang(UserManager<AppUser>userManager,IRoleMang role,AppDbContext context) : IUserMang
    {
        public async Task<bool> CreateUser(AppUser user ,string password)
        {
            var userExist = await userManager.FindByEmailAsync(user.Email!);
            if (userExist == null)
            {

                return (await userManager.CreateAsync(user,password!)).Succeeded;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<AppUser>> GetAllUsers()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<AppUser?> GetUserByEmail(string email)
        {
           return (await userManager.FindByEmailAsync(email));
        }

        public async Task<AppUser?> GetUserById(string userId)
        {
            return await userManager.FindByIdAsync(userId);
        }

        public async Task<List<Claim>> GetUserClaim(string email)
        {
            var user= await GetUserByEmail(email);
            string? rolename= await role.GetUserRole(user!.Email!);
                List<Claim> claim = [
                    new Claim("full name", user!.FullName!),
                    new Claim(ClaimTypes.NameIdentifier, user.Id!),
                    new Claim(ClaimTypes.Email, user.Email!),
                    new Claim(ClaimTypes.Role, rolename!)

                    ];
            return claim;
        }

        public async Task<bool> LoginUser(string email,string password)
        {
            var userExist = await GetUserByEmail(email!);
            if (userExist == null) { return false; }
            var rolename = await role.GetUserRole(userExist!.Email!);
            if(string.IsNullOrWhiteSpace(rolename)) { return false; }
            return await userManager.CheckPasswordAsync(userExist, password);
        }

        public async Task<int> removeuserbyid(string userId)
        {
            var user = await context.Users.FirstOrDefaultAsync(x=>x.Email == userId);
            context.Users.Remove(user!);    
            return await context.SaveChangesAsync();
        }
    }
}
