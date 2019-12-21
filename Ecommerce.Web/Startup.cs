using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EcommerceApp.DatabaseContext;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
             .AddMvcOptions(option =>
             {
                 option.OutputFormatters.Add(new XmlSerializerOutputFormatter());
             })
             .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<EcommerceDbContext>(opts =>
           opts.UseSqlServer(Configuration.GetConnectionString("AppConnectionString")));
            IoCContainer.IoCConfiguration.Configure(services);

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services
               .AddAuthentication(options =>
               {
                   options.DefaultScheme = "Cookies";
                   options.DefaultChallengeScheme = "oidc";
               })
               .AddCookie("Cookies")
               .AddOpenIdConnect("oidc",option => {
                   option.Authority = "https://localhost:44344/";
                   option.ClientId = "web_client";
                   option.ClientSecret = "secret";
                   option.RequireHttpsMetadata = true;
                   option.ResponseType = "code id_token";
                   option.SignInScheme = "Cookies";
                   option.SaveTokens = true;                   
                   option.GetClaimsFromUserInfoEndpoint = true;

               });
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });






        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
