// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;

namespace IdentityServerWithAspNetIdentity
{
    public class Config
    {
        // scopes define the resources in your system
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("apiApp", "My API")
            };
        }

        // clients want to access resources (aka scopes)
        public static IEnumerable<Client> GetClients(IConfiguration configuration)
        {
            // client credentials client
            return new List<Client>
            {
                new Client
                {
                    ClientId = "clientApp",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { "apiApp" }
                },

                // OpenID Connect implicit flow client (MVC)
                new Client
                {
                    ClientId = "mvcex",
                    ClientName = "MVC Client",
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,

                    RequireConsent = true,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    RedirectUris = { $"{configuration["ClientAddress2"]}/signin-oidc" },
                    PostLogoutRedirectUris = { $"{configuration["ClientAddress2"]}/signout-callback-oidc" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "apiApp"
                    },
                    AllowOfflineAccess = true
                },

                // OpenID Connect implicit flow client (Angular)
                new Client
                {
                    ClientId = "ng2",
                    ClientName = "Angular Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = true,

                    RedirectUris = { $"{configuration["ClientAddress2"]}/callback" },
                    PostLogoutRedirectUris = { $"{configuration["ClientAddress2"]}/home" },
                    AllowedCorsOrigins = { configuration["ClientAddress2"] },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "apiApp"
                    },

                },

                new Client
                {
                    ClientName = "OIDC demo mobile",
                    ClientId = "oidcdemomobile",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AccessTokenType = AccessTokenType.Jwt,
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,
                    UpdateAccessTokenClaimsOnRefresh = true,
                    RefreshTokenUsage = TokenUsage.OneTimeOnly,
                    AllowOfflineAccess = true,

                    
                    AllowedScopes = {
                       IdentityServerConstants.StandardScopes.OpenId,
                       IdentityServerConstants.StandardScopes.Profile,
                       "apiApp"
                    },
                    AllowRememberConsent = true,
                    RedirectUris = new List<string>
                    {
                        "http://localhost/oidc",
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "http://localhost/oidc",
                    },
                    AllowedCorsOrigins = new List<string>
                    {
                        "file://\\*",
                        "http://localhost/",
                        "http://evil.com/"
                    }
                }
                ,
                new Client
                {
                    ClientName = "React Web",
                    ClientId = "oidcreactwev",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AccessTokenType = AccessTokenType.Jwt,
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,
                    UpdateAccessTokenClaimsOnRefresh = true,
                    RefreshTokenUsage = TokenUsage.OneTimeOnly,

                    AllowedScopes = {
                       IdentityServerConstants.StandardScopes.OpenId,
                       IdentityServerConstants.StandardScopes.Profile,
                       "apiApp"
                    },
                    AllowRememberConsent = true,
                    RedirectUris =           { "http://localhost:51540/callback" },
                    PostLogoutRedirectUris = { "http://localhost:51540/home" },
                    AllowedCorsOrigins =     { "http://localhost:51540" },
                    //RedirectUris = new List<string>
                    //{
                    //    //"http://localhost/oidc",
                    //    "http://localhost/callback",
                    //},
                    //PostLogoutRedirectUris = new List<string>
                    //{
                    //    "http://localhost/oidc",
                    //},
                    //AllowedCorsOrigins = new List<string>
                    //{
                    //    "file://\\*",
                    //    "http://localhost:51540/",
                    //    "http://evil.com/"
                    //}
                }
            };
        }

        //public static List<TestUser> GetUsers()
        //{
        //    return new List<TestUser>
        //    {
        //        new TestUser
        //        {
        //            SubjectId = "1",
        //            Username = "alice",
        //            Password = "password",

        //            Claims = new List<Claim>
        //            {
        //                new Claim("name", "Alice"),
        //                new Claim("website", "https://alice.com")
        //            }
        //        },
        //        new TestUser
        //        {
        //            SubjectId = "2",
        //            Username = "bob",
        //            Password = "password",

        //            Claims = new List<Claim>
        //            {
        //                new Claim("name", "Bob"),
        //                new Claim("website", "https://bob.com")
        //            }
        //        }
        //    };
        //}
    }
}