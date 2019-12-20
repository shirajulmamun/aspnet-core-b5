using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static IdentityModel.OidcConstants;

namespace Ecommerce.Auth
{
    public static class Config
    {
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>(){
                new TestUser()
                {
                    SubjectId = "1",
                    Username ="Mamun",
                    Password = "password"
                },
                new TestUser()
                {
                    SubjectId = "2",
                    Username ="James",
                    Password = "password"
                }
            };

        }

        public static List<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>()
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public static List<Client> GetClients()
        {

            return new List<Client>()
            {
                new Client()
                {
                    ClientId = "web_client",
                    ClientSecrets = new List<Secret>()
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedGrantTypes = IdentityServer4.Models.GrantTypes.Hybrid,
                    RedirectUris =
                    {
                        "https://localhost:44397/signin-oidc"
                    },
                      AllowedScopes =
                    {
                        StandardScopes.OpenId,
                        StandardScopes.Profile
                    },
                }

            };

        }
    }
}
