using DataBaseEverything.Configuration;
using DataBaseevEverythingForHome.Database;
using DataBaseevEverythingForHome.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectEverything.Infrastucture;
using ProjectEverything.Service;
using ProjectEverything.Service.Carts;
using ProjectEverything.Service.Shop;
using ProjectEverything.Service.User;
using ProjectEverything.Service.Users;
using ProjectEverything.Views.Order;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = ConnectionPath.DB_CONNECTION_PATH;
builder.Services.AddDbContext<EverythingForHomeDBContext>(options =>
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("ProjectEverything")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddControllersWithViews();
builder.Services.AddDefaultIdentity<Account>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<EverythingForHomeDBContext>();
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<ICartService, CartService>();
builder.Services.AddTransient<IOrderService, OrderService>();
var app = builder.Build();

app.PrepareDatabase();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

