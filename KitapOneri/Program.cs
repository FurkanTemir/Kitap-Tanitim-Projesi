using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using KitapOneri.Data.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Hosting.Internal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<RecommendedContext>(opt =>
{
    opt.UseSqlServer("server=mavi\\SQLEXPRESS; database=KitapDB; integrated security=true;TrustServerCertificate=true");
});

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<HostingEnvironment>();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
{
    option.LoginPath = "/User/Giris";
    option.ExpireTimeSpan = TimeSpan.FromMinutes(20);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),
    "node_modules")),
    RequestPath = "/node_modules"
});
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=User}/{action=Giris}/{id?}");


app.Run();
