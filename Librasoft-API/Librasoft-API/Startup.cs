
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
using Librasoft.DataAccess.EFs;
using Librasoft_API.Librasoft.DataAccess.Repositorys;
using Librasoft_API.Librasoft.DataAccess.Repositorys.Constracts;
using Librasoft_API.DataAccess.Repositorys.Constracts;
using Librasoft_API.DataAccess.Repositorys;
using Librasoft.Services.Constract;
using Librasoft.DataAccess.Repositorys.Constracts;
using Librasoft.DataAccess.Repositorys;
using Librasoft.Services;
using System.Reflection;

namespace Librasoft_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_MyAllowSpecificOrigins";
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins, 
                    builder => {
                        builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });
            services.AddDbContext<PiranhaCoreContext>(options => { options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")); });
            services.AddControllersWithViews();
            services.AddAutoMapper(typeof(Startup));
            #region Repositories
            services.AddTransient(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IAliasRepository, PiranhaAliasRepository>();
            services.AddScoped<IPagesRepository, PiranhaPagesRepository>();
            services.AddScoped<IContactFormRepository, ContactFormRepository>();
            services.AddScoped<ICFCountryRepository, CFCountryRepository>();
            services.AddScoped<ICFIndustryRepository, CFIndustryRepository>();
            services.AddScoped<ICFReasonReachingRepository, CFReasonReachingRepository>();
            services.AddScoped<IBlockFieldsRepository, BlockFieldsRepository>();
            services.AddScoped<IBlocksRepository, BlocksRepository>();
            services.AddScoped<IPageRevisionsRepository, PagesRevisionRepository>();

            services.AddScoped<ISendEmailRepository, SendEmailRepository>();

            services.AddScoped<IPageBlocksRepository, PageBlocksRepository>();
            services.AddScoped<IApplicationFormRepository, ApplicationFormRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IEventParticipantsRepository, EventParticipantsRepository>();

            #endregion

            #region Services

            services.AddScoped(typeof(IPagesServices), typeof(PagesServices));
            services.AddScoped(typeof(IContactFormsServices), typeof(ContactFormService));
            services.AddScoped(typeof(ICFCountryServices), typeof(CFCountryServices));
            services.AddScoped(typeof(ICFIndustryServices), typeof(CFIndustryServices));
            services.AddScoped(typeof(ICFReasonReachingServices), typeof(CFReasonReachingServices));
            services.AddScoped(typeof(IBlockFieldsServices), typeof(BlockFieldsServices));
            services.AddScoped(typeof(IBlocksServices), typeof(BlocksServices));
            services.AddScoped(typeof(IPageRevisionsServices), typeof(PageRevisionsServices));

            services.AddScoped(typeof(ISendEmailServices), typeof(SendEmailServices));

            services.AddScoped(typeof(IPageBlocksServices), typeof(PageBlockServices));
            services.AddScoped(typeof(IApplicationFormServices), typeof(ApplicationFormServices));
            services.AddScoped(typeof(IEventServices), typeof(EventServices));
            services.AddScoped(typeof(IEventParticipantsServices), typeof(EventParticipantsServices));
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

            app.UseCors(MyAllowSpecificOrigins);

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
