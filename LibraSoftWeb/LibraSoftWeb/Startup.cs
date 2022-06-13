using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraSoftWeb.Models;
using Microsoft.EntityFrameworkCore;
using LibraSoftSolution.API;
using Microsoft.AspNetCore.Http;
using LibraSoftSolution.API.Contacts_Customer;
using LibraSoftSolution.API.Test;
using LibraSoftSolution.API.ReceiveMails;
using LibraSoftSolution.API.ContentWeb;

namespace LibraSoftWeb
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
            services.AddHttpClient();

            services.AddControllersWithViews();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<INavigationTitleAPI, NavigationTitleAPI>();
            services.AddTransient<ICFCountryAPI, CFCountryAPI>();
            services.AddTransient<ICFIndustryAPI, CFIndustryAPI>();
            services.AddTransient<ICFReasonReachingAPI, CFReasonReachingAPI>();
            services.AddTransient<IContactAPI, ContactAPI>();
            services.AddTransient<ITestAPI, TestAPI>();
            services.AddTransient<IEmailAPI, EmailAPI>();
            services.AddTransient<IBlockAPI, BlockAPI>();

            services.AddDbContext<PiranhaCoreContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
