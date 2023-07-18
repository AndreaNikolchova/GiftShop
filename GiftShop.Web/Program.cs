using GiftShop.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<GiftShopDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<GiftShopDbContext>();
builder.Services.AddControllersWithViews();
string clouldName = builder.Configuration.GetValue<string>("Cloudinary:CloudName");
string apiKey = builder.Configuration.GetValue<string>("Cloudinary:ApiKey");
string apiSecret = builder.Configuration.GetValue<string>("Cloudinary:ApiSecret");

Account cloudinaryCredentials = new Account(
        clouldName,
        apiKey,
        apiSecret
    );

Cloudinary cloudinary = new Cloudinary(cloudinaryCredentials);
builder.Services.AddSingleton(cloudinary);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
