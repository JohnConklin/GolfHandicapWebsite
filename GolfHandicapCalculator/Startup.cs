using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using GolfHandicapCalculator.Models;
using System.IO;

namespace GolfHandicapCalculator
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
            services.AddCors();
            services.AddMvc();

            var connection = Configuration["ConnectionString"];
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<UserContext>(options =>
                {
                    options.UseSqlServer(connection);
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //adding to avoid using "api/values" on startup.
            app.Use(async (context, next) =>
            {
                await next();

                if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value) && !context.Request.Path.Value.StartsWith("api"))
                {
                    context.Request.Path = "/Index.html";
                    context.Response.StatusCode = 200;
                    await next();
                }
            });

            //Added to avoid using api/values on startup
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseCors(p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());

            app.UseMvc();
        }
    }
}
