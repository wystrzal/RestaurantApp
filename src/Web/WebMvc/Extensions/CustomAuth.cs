using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebMvc.Extensions
{
    public static class CustomAuth
    {
        public static void AddCustomAuth(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
            .AddCookie("Cookies")
            .AddOpenIdConnect("oidc", options =>
            {
                options.Authority = "http://localhost:5000";
                options.RequireHttpsMetadata = false;

                options.ClientId = "mvc";
                options.ClientSecret = "secret";
                options.ResponseType = "code";
                options.SaveTokens = true;
                options.GetClaimsFromUserInfoEndpoint = true;

                options.Scope.Clear();
                options.Scope.Add("openid");

                options.Scope.Add("order");
                options.Scope.Add("menu");
                options.Scope.Add("restaurant");
                options.ClaimActions.Add(new MapAllClaimsAction());
                options.ClaimActions.DeleteClaim(JwtClaimTypes.Role);
                options.ClaimActions.MapJsonKey(JwtClaimTypes.Role, JwtClaimTypes.Role, JwtClaimTypes.Role);
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireClaim(ClaimTypes.Role, "admin"));
            });
        }
    }
}
