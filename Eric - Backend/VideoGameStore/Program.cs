using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VideoGameStore.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication().AddFacebook(fb =>
{
    fb.AppId = "427676729375990";
    fb.AppSecret = "2e31d919f19ac7f0745ba2345678fc79";
});

builder.Services.AddAuthentication().AddGoogle(ggl =>
{
    ggl.ClientId = "fdlkjfiuuiebgisbgkjgskbgiwbwihe";
    ggl.ClientSecret = "fsmdlksdnfiweby2vfdsfbehfbdkmbfonfjrfijfsmlnfdsjkfdsfew";
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
