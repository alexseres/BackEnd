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
using Microsoft.AspNetCore.Identity;

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
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                                  });
            });
            services.AddDbContextPool<CardDBContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("CardDBConnection")));

            services.AddIdentity<User, IdentityRole>(config =>
                {
                    config.Password.RequiredLength = 4;
                })
                .AddEntityFrameworkStores<CardDBContext>()
                .AddDefaultTokenProviders();
            services.ConfigureApplicationCookie(config =>
            {
                config.Cookie.Name = "Identity.Email";
                config.LoginPath = "/Login";
            });    
            
            services.AddMvc().AddNewtonsoftJson();
            services.AddControllers();

            services.AddScoped<ICardRepository, SQLCardRepository>();
            services.AddScoped<APIfetcher>();
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
            }
            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthentication();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
