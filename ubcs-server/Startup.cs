using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ubcs_server.Data;
using ubcs_server.Data.Models;
using ubcs_server.Infrastructure;

namespace ubcs_server
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
            var appsettings = services.GetApplicationSettings(Configuration);

            services.AddDbContext<UbcsDbContext>(options => options.UseSqlServer(
                     Configuration.GetDefaultConnectionString()))
            .AddIdentity()
            .AddJwtAuthentication(appsettings)
            .AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
                app.UseDatabaseErrorPage();
            }

            app
                .UseHttpsRedirection()
                .UseStaticFiles()

                .UseRouting()

                .UseCors(option => option
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
                )

                .UseAuthentication()
                .UseAuthorization()

                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                })

                .ApplyMigrations();
        }
    }
}
