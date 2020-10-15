using Assessment.DomainModel;
using Assessment.GlueService;
using Honeywell_Backend_Assessment.AuthenticationModels;
using Honeywell_Backend_Assessment.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeywell_Backend_Assessment
{
    public static class ProductExtensions
    {
        public static void InjectServices(this IServiceCollection collection, IConfiguration config)
        {
            collection.AddSingleton<IInstanceGenerator, InstanceGenerator>((service) =>
            {
                return new InstanceGenerator();
            });

            collection.AddSingleton<IProductService, ProductService>();

        }
        public static bool LoadConfig(this IWebHostEnvironment env, IConfiguration config)
        {
            ProjectConfig.ConnectionString = config["connectionString"] ?? @"Data Source=(localdb)\MSSQLLOCALDB;Initial Catalog=AssessmentDB;Integrated Security=True";
            return true;
        }
        public static void AddTokenBasedAuthentication(this IServiceCollection services, IConfiguration config)
        {
            IConfigurationSection appSettingsSection = config.GetSection(Constants.APP_SETTINGS);
            AppSettings appSettings = appSettingsSection.Get<AppSettings>();
            byte[] key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.Configure<AppSettings>(appSettingsSection);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,

                };
            });
        }
    }
}
