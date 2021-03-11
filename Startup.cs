using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using assignment5.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using assignment5.Pages;
using assignment5.Models.ViewModels;

namespace assignment5
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //add connection string to the services so that it will connect with the local database
            services.AddDbContext<BookDbContext>(options =>
            {
                options.UseSqlite(Configuration.GetConnectionString("BookDbConnection"));
            });
            services.AddScoped<IBookRepository, EFBookRepository>();

            //add cart razor page and session storage services
            services.AddRazorPages();

            services.AddMemoryCache();

            services.AddSession();

            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp)); // specifies that the same object should be used to satisfy related requests for Cart instances

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //tell the app to use the session storage service
            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("categorypage",
                    "{category}/{pagenum:int}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("pagenum",
                    "{pagenum:int}",
                    new { Controller = "Home", Action = "Index" });

                endpoints.MapControllerRoute("category",
                    "{category}",
                    new { Controller = "Home", action = "Index", pagenum = 1 });

                endpoints.MapControllerRoute(
                    //name: "default",
                    //pattern: "{controller=Home}/{action=Index}/{id?}");
                    //this is what alters the url appearence to make it look a little better
                    "pagination",
                    "P{pagenum}",
                    new { Controller = "Home", Action = "Index" });

                endpoints.MapDefaultControllerRoute();

                //include razor pages in the endpoints
                endpoints.MapRazorPages();
            });

            //call the seed data method so that the first time it is run it will check to make sure the
            //database has been seeded, if not then it will add the seed data, if it pulls the data from the database
            SeedData.EnsurePopulated(app);
        }
    }
}
