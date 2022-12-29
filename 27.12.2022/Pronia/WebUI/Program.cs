using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Services
builder.Services.AddControllersWithViews();
var constr = builder.Configuration["ConnectionStrings:Default"];
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(constr);
});

builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
{
    opt.Password.RequiredLength = 8;
    opt.Password.RequireNonAlphanumeric = true;
    opt.Password.RequireLowercase= true;
    opt.Password.RequireUppercase= true;
    opt.Password.RequireDigit= true;

    opt.User.RequireUniqueEmail= true;
    opt.Lockout.MaxFailedAccessAttempts= 5;
    opt.Lockout.DefaultLockoutTimeSpan= TimeSpan.FromMinutes(30);
    opt.Lockout.AllowedForNewUsers= true;

}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

builder.Services.AddSession(opt =>
{
    opt.IdleTimeout = TimeSpan.FromSeconds(10);
});

builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.LoginPath = "/Auth/Login";
});

builder.Services.AddScoped<IShippingItemRepository, ShippingItemRepository>();
builder.Services.AddScoped<ISlideItems, SlideItemsRepository>();
var app = builder.Build();

//handle http request
app.UseStaticFiles();
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
 name: "areas",
 pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{Id?}"
);


//Area
app.Run();
