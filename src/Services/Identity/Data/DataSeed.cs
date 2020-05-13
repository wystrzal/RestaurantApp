using Identity.Helpers;
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
                var users = new List<User>
                {
                    new User {UserName = "Admin", FirstName = "admin", LastName = "admin", Name = "admin"},
                    new User {UserName = "Restaurant", FirstName = "restaurant", LastName = "restaurant", Name = "restaurant"},
                    new User {UserName = "Kitchen", FirstName = "kitchen", LastName = "kitchen", Name = "kitchen"}
                };

                foreach (var user in users)
                {
                    userManager.CreateAsync(user, user.UserName + "123").Wait();
                }

                userManager.AddClaimAsync(users[0], new System.Security.Claims.Claim("role", Roles.Admin)).Wait();
                userManager.AddClaimAsync(users[1], new System.Security.Claims.Claim("role", Roles.Restaurant)).Wait();
                userManager.AddClaimAsync(users[2], new System.Security.Claims.Claim("role", Roles.Kitchen)).Wait();


            };
        }
    }
}
