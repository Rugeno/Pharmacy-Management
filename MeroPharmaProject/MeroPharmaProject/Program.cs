using MeroPharmaProject.Models.Domain;
using MeroPharmaProject.Repositories.Implementation;
using MeroPharmaProject.Repository.Abstaract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration
    .GetConnectionString("MVCConnectionString")));

// For Identity
builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<DatabaseContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options => options.LoginPath = "/UserAuthentication/Login");

builder.Services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=UserAuthentication}/{action=Login}/{id?}");

app.Run();
