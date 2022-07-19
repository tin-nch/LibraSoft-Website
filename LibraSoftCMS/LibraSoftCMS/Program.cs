using LibraSoftCMS.Models;
using LibraSoftSolution.API.ContactCustomer;
using LibraSoftSolution.API.ContentBlock;
using LibraSoftSolution.API.ContentBlocsk;
using LibraSoftSolution.API.ContentWeb;
using LibraSoftSolution.API.Event;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Piranha;
using Piranha.AspNetCore.Identity.SQLServer;
using Piranha.AttributeBuilder;
using Piranha.Data.EF.SQLServer;
using Piranha.Manager.Editor;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddTransient<IContactAPI, ContactAPI>();
builder.Services.AddTransient<ICFReasonReachingAPI, CFReasonReachingAPI>();
builder.Services.AddTransient<IRegistersApi, RegistersApi>();
builder.Services.AddTransient<IBlockAPI, BlockAPI>();
builder.Services.AddTransient<IPartnerCTAPI, PartnerCTAPI>();
builder.Services.AddTransient<IClientCTAPI, ClientCTAPI>();
builder.Services.AddTransient<IAboutUsCTAPI, AboutUsCTAPI>();
builder.Services.AddTransient<IServiceCTAPI, ServiceCTAPI>();
builder.Services.AddTransient<IFactCTAPI, FactCTAPI>();
builder.Services.AddTransient<IMapCTAPI, MapCTAPI>();
builder.Services.AddTransient<IWorkCTAPI, WorkCTAPI>();

builder.Services.AddLocalization(opt => { opt.ResourcesPath = "Resources"; });
builder.Services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();
builder.Services.Configure<RequestLocalizationOptions>(
    opt =>
    {
        var supportedCultures = new List<CultureInfo>
        {
            new CultureInfo("En"),
            new CultureInfo("Vi")
        };
        opt.DefaultRequestCulture = new RequestCulture("En");
        opt.SupportedCultures = supportedCultures;
        opt.SupportedUICultures = supportedCultures;
    });

builder.Services.AddDbContext<LibraSoftCMSContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("piranha")));

builder.AddPiranha(options =>
{
    /**
     * This will enable automatic reload of .cshtml
     * without restarting the application. However since
     * this adds a slight overhead it should not be
     * enabled in production.
     */
    options.AddRazorRuntimeCompilation = true;

    options.UseCms();
    options.UseManager();

    options.UseFileStorage(naming: Piranha.Local.FileStorageNaming.UniqueFolderNames);
    options.UseImageSharp();
    options.UseTinyMCE();
    options.UseMemoryCache();

    var connectionString = builder.Configuration.GetConnectionString("piranha");
    options.UseEF<SQLServerDb>(db => db.UseSqlServer(connectionString));
    options.UseIdentityWithSeed<IdentitySQLServerDb>(db => db.UseSqlServer(connectionString));

    /**
     * Here you can configure the different permissions
     * that you want to use for securing content in the
     * application.
    options.UseSecurity(o =>
    {
        o.UsePermission("WebUser", "Web User");
    });
     */

    /**
     * Here you can specify the login url for the front end
     * application. This does not affect the login url of
     * the manager interface.
    options.LoginUrl = "login";
     */
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
var options = ((IApplicationBuilder)app).ApplicationServices.GetRequiredService<IOptions<RequestLocalizationOptions>>();

app.UseRequestLocalization(options.Value);
app.UsePiranha(options =>
{
    // Initialize Piranha
    App.Init(options.Api);

    // Build content types
    new ContentTypeBuilder(options.Api)
        .AddAssembly(typeof(Program).Assembly)
        .Build()
        .DeleteOrphans();

    // Configure Tiny MCE
    EditorConfig.FromFile("editorconfig.json");

    options.UseManager();
    options.UseTinyMCE();
    options.UseIdentity();
});

app.Run();