using App.Shared;
using App.System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Portal.Data.Common;
using Portal.Data.System;
using Portal.Domain.System;
using Portal.Web.Data;
using Portal.Web.System.Services;
using System.IO;
using System.Text;

namespace Portal.Web
{
    public class Startup
    {
        private readonly IConfigurationRoot config;

        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddUserSecrets<Startup>();

            config = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication()
                .AddJwtBearer(options =>
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = config["Tokens:Issuer"],
                        ValidAudience = config["Tokens:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Tokens:Key"]))
                    }
                );

            services.AddDbContext<SystemContext>(options =>
                options.UseSqlServer(config["connectionString"]));

            services.AddMvcCore()
                .AddJsonFormatters();

            services.AddSingleton<TokenService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<SystemManager>();

            services.AddScoped<SystemService>();

            services.AddScoped<DataService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();
        }
    }
}