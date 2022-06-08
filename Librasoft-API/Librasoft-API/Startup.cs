
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
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Librasoft_API.Librasoft.DataAccess.EFs;
using Librasoft_API.Librasoft.DataAccess.Repositorys;
using Librasoft_API.Librasoft.DataAccess.Repositorys.Constracts;
using Librasoft_API.DataAccess.Repositorys.Constracts;
using Librasoft_API.DataAccess.Repositorys;
using Librasoft.Services.Constract;
using Librasoft.DataAccess.Repositorys.Constracts;
using Librasoft.DataAccess.Repositorys;
using Librasoft.Services;

namespace Librasoft_API
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
            services.AddDbContext<PiranhaCoreContext>(options => { options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")); });
            services.AddControllersWithViews();

            #region Repositories
            services.AddTransient(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IAliasRepository, PiranhaAliasRepository>();
            services.AddScoped<IPagesRepository, PiranhaPagesRepository>();
            #endregion

            #region Services
            services.AddScoped(typeof(IPages), typeof(PagesServices));
            
            #endregion
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
