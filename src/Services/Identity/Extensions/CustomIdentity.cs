
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Identity.Extensions
{
    public static class CustomIdentity
    {
        public static void AddCustomIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<DataContext>()
            .AddDefaultTokenProviders();

            services.AddIdentityServer().AddDeveloperSigningCredential()
            .AddOperationalStore(options =>
            {
               options.ConfigureDbContext = builder
                => builder.UseSqlServer(configuration["ConnectionStrings"], b => b.MigrationsAssembly("Identity"));  
               options.EnableTokenCleanup = true;
               options.TokenCleanupInterval = 30;
            })
            .AddInMemoryIdentityResources(Config.GetIdentityResources())
            .AddInMemoryApiResources(Config.GetApiResources())
            .AddInMemoryClients(Config.GetClients())
            .AddAspNetIdentity<User>();
        }
    }
}
