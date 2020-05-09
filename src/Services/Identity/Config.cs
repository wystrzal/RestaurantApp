﻿using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Identity
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("menu", "Menu Service"),
                new ApiResource("order", "Order Service"),
                new ApiResource("kitchen", "Kitchen Service"),
                new ApiResource("restaurant", "Restaurant Service")

            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                new Client {
                    RequireConsent = false,
                    ClientId = "mvc",
                    ClientSecrets = {new Secret("secret".Sha256())},
                    ClientName = "MVC Client",
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = {"http://localhost:5050/signin-oidc"},
                    PostLogoutRedirectUris = {"http://localhost:5050/signout-callback-oidc"},         
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "menu",
                        "order",
                        "kitchen",
                        "restaurant"
                    }               
                },
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = {new Secret("secret".Sha256())},

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = {"menu", "order", "kitchen", "restaurant"},  
                }
            };
        }
    }
}
