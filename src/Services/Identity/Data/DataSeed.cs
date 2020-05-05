using Identity.Infrastructure.Constants;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Data
{
    public static class DataSeed
    {
        public static void AddData(UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                User user = new User { UserName = "admin" };

                userManager.CreateAsync(user, "Admin123").Wait();

                userManager.AddClaimAsync(user, new System.Security.Claims.Claim("role", Roles.Admin)).Wait();
            };
        }
    }
}
