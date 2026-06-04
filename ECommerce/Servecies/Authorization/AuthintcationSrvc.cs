using AutoMapper;
using ECommerce.Base;
using ECommerce.db.Base.Authintcation;
using ECommerce.db.Context;
using ECommerce.db.Entities.Identity;
using ECommerce.lib.Base;
using ECommerce.lib.DTos;
using ECommerce.lib.DTos.Identity;
using FluentValidation;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Servecies.Authorization
{
    public class AuthintcationSrvc(AppDbContext context,IRoleMang roleMang, IUserMang userMang, ITokenMang tokenMang, IAppLoger<AuthintcationSrvc> logger, IMapper mapper, IValidator<CreateUser> Createuservalidator, IValidator<LoginUser> Loginuservalidator, IValidateSrvc validateSrvc) : IAuthintcationSrvc
    {
        public async Task<ResponseDto> createuser(CreateUser User)
        {
            var validationResult = await validateSrvc.ValidateAsync(User, Createuservalidator);
            if (!validationResult.success)
            {
                return validationResult;
            }
            var mappedUser = mapper.Map<AppUser>(User);
            mappedUser.UserName = User.Email;
            //mappedUser.PasswordHash = User.Password;
            mappedUser.Email = User.Email;
            mappedUser.FullName = User.FullName;
            var result = await userMang.CreateUser(mappedUser, User.Password);
            if (!result)
            {
                return new ResponseDto { success = false, message = "invalid data" };
            }
                var _user = await userMang.GetUserByEmail(User.Email);
                var users = await userMang.GetAllUsers();
                bool assignedResult = await roleMang.AddUserToRole(_user!, users.Count() > 1 ? "User" : "Admin");

            if (!assignedResult)
            {

                int removeuser = await userMang.removeuserbyid(_user!.Email!);
                if (removeuser <= 0)
                {
                    logger.LogError(new Exception("Failed to remove user after role assignment failure."), "error in role");
                    return new ResponseDto { message = "can't create new user account" };
                }
            }
            return new ResponseDto { success = true, message = "success user account has been created" };

        }

        public async Task<LoginDto> Loginuser(LoginUser User)
        {
            var validationResult = await validateSrvc.ValidateAsync(User, Loginuservalidator);
            if (!validationResult.success)
            {
                return new LoginDto { success = false, message = validationResult.message };
            }

            bool loginresult = await userMang.LoginUser(User.Email, User.Password);
            if (!loginresult)
            {
                return new LoginDto { success = false, message = "can't Login user account" };
            }

            var _user = await userMang.GetUserByEmail(User.Email);
            if (_user == null)
            {
                return new LoginDto { success = false, message = "user not found" };
            }

            var claims = await userMang.GetUserClaim(_user.Email!);

            var jwttoken = tokenMang.GenerateToken(claims);
            var refreshtoken = tokenMang.RefreshToken();

            var saveresult = await tokenMang.updaterefreshtoken(_user.Id, refreshtoken);

            if (saveresult <= 0)
            {
                // fallback create
                await tokenMang.addrefreshtoken(_user.Id, refreshtoken);
            }

            return new LoginDto
            {
                success = true,
                message = "success Login",
                token = jwttoken,
                refreshToken = refreshtoken
            };
        }

        public async Task<LoginDto> RetriveToken(string refreshToken)
        {
            bool validateTokenResult = await tokenMang.validateRefreshToken(refreshToken);
            if (!validateTokenResult)
                return new LoginDto { success = false, message = "Invalid Token" };

            string userId = await tokenMang.getusridbyrefresh(refreshToken);
            AppUser? appUser = await userMang.GetUserById(userId);
            var claims = await userMang.GetUserClaim(appUser!.Email!);
            string newJwtToken = tokenMang.GenerateToken(claims);
            string newRefreshToken = tokenMang.RefreshToken();
            await tokenMang.updaterefreshtoken(userId, newRefreshToken);
            return new LoginDto { success = true, token = newJwtToken, refreshToken = newRefreshToken };
        }
    }
}
