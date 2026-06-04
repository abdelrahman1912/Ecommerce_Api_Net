using ECommerce.db.Base.Authintcation;
using ECommerce.db.Context;
using ECommerce.db.Entities.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.db.Repos.Authintcation
{
    public class TokenMang(AppDbContext context,IConfiguration configuration) : ITokenMang
    {
        public async Task<int> addrefreshtoken(string userId, string refreshToken)
        {
            context.RefreshTokens.Add(new RefreshToken { UserId = userId, Token = refreshToken });
            return await context.SaveChangesAsync();
        }


        public string GenerateToken(List<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddHours(2);
            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public List<Claim> GetClaims(string email)
        {
           var tokenhandler = new JwtSecurityTokenHandler();
            var token = tokenhandler.ReadJwtToken(email);
            if (token!=null)
            {
                return token.Claims.ToList();
            }
            else
            {
                return [];
            }
        }

        public async Task<string> getusridbyrefresh(string refreshToken)
        {
            return (await context.RefreshTokens.FirstOrDefaultAsync(rt => rt.Token == refreshToken))!.UserId;
        }

        public string RefreshToken()
        {
            const int bytesize = 64;
            byte[]randombytes=new byte[bytesize];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randombytes);
            }
            return Convert.ToBase64String(randombytes);
        }

        public async Task<int> updaterefreshtoken(string userId, string refreshToken)
        {
            var oldToken = await context.RefreshTokens
                .FirstOrDefaultAsync(rt => rt.UserId == userId);

            if (oldToken == null)
            {
                var token = new RefreshToken
                {
                    UserId = userId,
                    Token = refreshToken,
                    IsActive = true,
                };

                await context.RefreshTokens.AddAsync(token);
            }
            else
            {
                oldToken.Token = refreshToken;
                oldToken.IsActive = true;
            }

            return await context.SaveChangesAsync();
        }

        public async Task<bool> validateRefreshToken(string refreshToken)
        {
            return await context.RefreshTokens
        .FirstOrDefaultAsync(rt => rt.Token == refreshToken && rt.IsActive) != null;
        }
    }
}
