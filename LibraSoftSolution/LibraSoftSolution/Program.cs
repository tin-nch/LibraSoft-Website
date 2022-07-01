using LibraSoftSolution.API.ContactCustomer;
using LibraSoftSolution.API.ContentBlock;
using LibraSoftSolution.API.ContentBlocsk;
using LibraSoftSolution.API.ContentWeb;
using LibraSoftSolution.API.Event;
using LibraSoftSolution.Models;
using Microsoft.EntityFrameworkCore;

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






builder.Services.AddDbContext<PiranhaCoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
