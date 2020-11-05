using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HearthStone_Backend.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using HearthStone_Backend.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.CookiePolicy;

namespace HearthStone_Backend
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // TODO: Cors address should be specific and stored in appsettings.json
            var allowedOrigins = new[] { "http://localhost:000/", "http://localhost:3000", "http://localhost:3000/login" };

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins(allowedOrigins).AllowAnyHeader().AllowAnyMethod().AllowCredentials();
                                  });
            });
            services.AddDbContextPool<CardDBContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("CardDBConnection")));

            services.AddIdentity<User, IdentityRole>(config =>
                {
                    config.Password.RequiredLength = 4;
                    config.SignIn.RequireConfirmedEmail = false;
                    config.Password.RequireDigit = false;
                    config.Password.RequireUppercase = false;
                    config.Password.RequireNonAlphanumeric = false;
                })
                .AddEntityFrameworkStores<CardDBContext>();


            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.Cookie.Name = "Identity.Cookie";
                    options.ExpireTimeSpan = new TimeSpan(0, 5, 0);
                    options.Cookie.HttpOnly = false;
                });

            /*services.ConfigureApplicationCookie(config =>
            {
                config.Cookie.Name = "User.Cookie";
                config.ExpireTimeSpan = new TimeSpan(1, 5, 0);
                config.Cookie.HttpOnly = false;
            });*/

            /*services.AddAuthentication("OAuth")
                .AddJwtBearer("OAuth", config =>
            {

            });*/



            services.AddMvc();
            services.AddControllers();

            services.AddScoped<ICardRepository, SQLCardRepository>();
            services.AddScoped<APIfetcher>();
            services.AddScoped<PasswordHasher>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            //var allowedOrigins = new[] { "localhost:5000", "localhost:3000/login", "localhost:3000/" };

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCors(MyAllowSpecificOrigins);
            //app.UseSession();
           
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
