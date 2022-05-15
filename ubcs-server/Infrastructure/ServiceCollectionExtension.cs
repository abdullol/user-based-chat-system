using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ubcs_server.Data;
using ubcs_server.Data.Models;

namespace ubcs_server.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection
            AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>(options =>
                {
                    options.Password.RequiredLength = 6;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                })
             .AddEntityFrameworkStores<UbcsDbContext>();
            return services;
        }

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services,
            AppSettings appsettings)
        {

            var key = Encoding.ASCII.GetBytes(appsettings.Secret);

            services
              .AddAuthentication(x =>
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
                         ValidateAudience = false
                     };
                 });

            return services;
        }
    }
}
