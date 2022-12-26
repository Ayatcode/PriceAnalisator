using DataAccess.Contexts;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Services
builder.Services.AddControllersWithViews();
var constr = builder.Configuration["ConnectionStrings:Default"];
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(constr);
});


builder.Services.AddScoped<IShippingItemRepository, ShippingItemRepository>();
builder.Services.AddScoped<ISlideItems, SlideItemsRepository>();
var app = builder.Build();

//handle http request
app.UseStaticFiles();

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
