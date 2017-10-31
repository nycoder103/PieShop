using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PieShop.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace PieShop
{
    public class Startup
    {
        private IConfigurationRoot _configurationRoot; 

        public Startup(IHostingEnvironment hostingEnvironment)
        {
            _configurationRoot = new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
        }

        /// <summary>
        /// Contains list of services registered with the Dependency Injection System
        /// </summary>
        /// <param name="services"></param>
        /// <remarks>AddTransient creates a new instance every time the interface is invoked</remarks>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(_configurationRoot.GetConnectionString("DefaultConnection")));
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IPieRepository, PieRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ShoppingCart>(sp => ShoppingCart.GetCart(sp));
            services.AddMvc();

            services.AddMemoryCache();
            services.AddSession();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //Register Middleware Components/Pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, AppDbContext dbContext)
        {
            //Useful error messages
            app.UseDeveloperExceptionPage();
                              
            //Text-only status codes
            app.UseStatusCodePages();

            //Ability for site to serve static files
            app.UseStaticFiles();

            app.UseSession();

            //Sets up MVC Middleware with default routing schema
            //app.UseMvcWithDefaultRoute();

            app.UseMvc(routes => 
            {
                routes.MapRoute(
                    name: "categoryFilter",
                    template: "Pie/{action}/{category?}",
                    defaults: new { Controller = "Pie", action = "List" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //Fill database with initial data
            DbInitializer.Seed(app, dbContext);
            

        }
    }
}
