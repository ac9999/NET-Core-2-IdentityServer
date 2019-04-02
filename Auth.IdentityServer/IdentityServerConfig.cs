﻿using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Auth.IdentityServer
{
    public static class IdentityServerConfig
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource> {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client> {
                new Client {
                    ClientId = "Website1",
                    ClientName = "Website1",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RedirectUris = { "https://localhost:5001/signin-oidc" },
                    PostLogoutRedirectUris = new List<string> { "https://localhost:5001/signout-callback-oidc" },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                },
                 new Client {
                    ClientId = "Website2",
                    ClientName = "Website2",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RedirectUris = { "https://localhost:5002/signin-oidc" },
                    PostLogoutRedirectUris = new List<string> { "https://localhost:5002/signout-callback-oidc" },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                },
                  new Client {
                    ClientId = "Website3",
                    ClientName = "Website3",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RedirectUris = { "https://localhost:5003/signin-oidc" },
                    PostLogoutRedirectUris = new List<string> { "https://localhost:5003/signout-callback-oidc" },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                }
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser> {
                new TestUser
                {
                    SubjectId = "01ab3fd998c74b75b53b9ece8dcb9b35",
                    Username = "user1",
                    Password = "test",
                    Claims = new []
                    {
                        new Claim("name", "user1")
                    }
                }
            };
        }
    }
}
