using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RetroStoreMVC2.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication().AddFacebook(fb =>
{
    fb.AppId = "446292387168422";
    fb.AppSecret = "38fb1ff21495607c872e415266b2efb4";
});

builder.Services.AddAuthentication().AddGoogle(ggl =>
{
    ggl.ClientId = "302155869063-ajf5fu6om2rk2g1i29vrc8t9em3hrgg5.apps.googleusercontent.com";
    ggl.ClientSecret = "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";
});

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

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

