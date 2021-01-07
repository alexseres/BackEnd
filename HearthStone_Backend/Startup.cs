using System;
using HearthStone_Backend.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using HearthStone_Backend.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace HearthStone_Backend
{
    public class Startup
    {
        private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            string[] allowOrigins = Configuration.GetSection("CorsAllowedOrigins").GetChildren().Select(key => key.Value).ToArray();

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins(allowOrigins).AllowAnyHeader().AllowAnyMethod().AllowCredentials();
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
                    options.Cookie.SecurePolicy = CookieSecurePolicy.None;
                });


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


            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCors(MyAllowSpecificOrigins);           
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
