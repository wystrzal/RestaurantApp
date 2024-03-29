﻿using Account.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Account.Helpers
{
    public static class TokenGenerator
    {
        public static async Task<TokenModel> GenerateJwtToken(User user, IConfiguration config,
            UserManager<User> userManager)
        {
            var currentUser = await userManager.FindByIdAsync(user.Id);
            var userClaim = await userManager.GetClaimsAsync(currentUser);
            var roles = userClaim.Where(c => c.Type == "role").ToList();

            var claims = new List<Claim>
            {
              new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
              new Claim(ClaimTypes.Name, user.UserName)
            };

            var roleClaims = new List<string>();

            //Add role claims for user.
            if (roles.Count() > 0 && roles != null)
            {
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.Value));
                    roleClaims.Add(role.Value);
                }
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            TokenModel tokenModel = new TokenModel
            {
                Token = tokenHandler.WriteToken(token),
                RoleClaims = roleClaims
            };
            
            return tokenModel;
        }
}
}
