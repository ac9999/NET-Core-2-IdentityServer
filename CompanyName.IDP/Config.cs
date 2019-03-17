using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CompanyName.IDP
{
    public static class Config
    {

        // test users
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "d860efca-22d9-47fd-8249-791ba61b07c7",
                    Username = "testuser",
                    Password = "password",

                    Claims = new List<Claim>
                    {
                        new Claim("given_name", "Test"),
                        new Claim("family_name", "User"),
                    }
                },
                new TestUser
                {
                    SubjectId = "b7539694-97e7-4dfe-84da-b4256e1ff5c7",
                    Username = "admin",
                    Password = "password",

                    Claims = new List<Claim>
                    {
                        new Claim("given_name", "Admin"),
                        new Claim("family_name", "Account"),
                    }
                }
            };
        }

        // identity-related resources (scopes)
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(), // requirement ensures SubjectId is included.
                new IdentityResources.Profile() // maps to given name and family name claims in identity token.
                      };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>();
        }
    }
}
