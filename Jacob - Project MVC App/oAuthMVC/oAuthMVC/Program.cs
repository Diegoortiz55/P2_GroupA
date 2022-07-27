using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using oAuthMVC.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication().AddFacebook(fb =>
{
    fb.AppId = "458466315802760";
    fb.AppSecret = "5aac249814eee406bb95fa4c08794251";
});

builder.Services.AddAuthentication().AddGoogle(ggl =>
{
    ggl.ClientId = "325392458618-jhsf0k5j6dog5rrqb6no55tdskhmv267.apps.googleusercontent.com";
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
