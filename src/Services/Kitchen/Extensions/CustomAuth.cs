using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Kitchen.Extensions
{
    public static class CustomAuth
    {
        public static void AddCustomAuth(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.Authority = "http://localhost:5000";
                o.Audience = "kitchen";
                o.RequireHttpsMetadata = false;
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Worker", policy => policy.RequireClaim("scope", "kitchen", "admin"));
                options.AddPolicy("Admin", policy => policy.RequireClaim(ClaimTypes.Role, "admin"));
            });
        }
    }
}
