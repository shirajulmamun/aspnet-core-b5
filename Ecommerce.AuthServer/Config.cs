using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace Ecommerce.AuthServer
{
    public static class Config
    {
        public static List<TestUser> Users()
        {

            return new List<TestUser>()
            {
                new TestUser()
                {
                    SubjectId = "1",
                    Username = "Mamun",
                    Password = "Password",
                    Claims = new List<Claim>
                    {
                        new Claim("given_name", "Shirajul"),
                        new Claim("family_name","Mamun")
                    }
                },
                new TestUser()
                {
                    SubjectId = "2",
                    Username = "john",
                    Password = "Password",
                    Claims = new List<Claim>
                    {
                        new Claim("given_name", "John"),
                        new Claim("family_name","Dane")
                    }
                }
        };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>()
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client()
                {
                    ClientName = "Web Client",
                    ClientId =  "web_client",
                      ClientSecrets =
                        {
                            new Secret("secret".Sha256())
                        },


                    AllowedGrantTypes = GrantTypes.Hybrid,
                    RedirectUris = new List<string>()
                    {
                        "https://localhost:44397/signin-oidc"
                    },

                   PostLogoutRedirectUris = { "https://localhost:44397/signout-callback-oidc" },

                    AllowedScopes =
                    {
                        StandardScopes.OpenId,
                        StandardScopes.Profile
                    },
                    //AlwaysIncludeUserClaimsInIdToken = true
                }
            };

        }
    }
}
