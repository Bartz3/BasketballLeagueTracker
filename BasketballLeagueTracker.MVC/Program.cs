using BasketballLeagueTracker.Domain.Entities;
using BasketballLeagueTracker.Infrastructure.Extensions;
using BasketballLeagueTracker.Infrastructure.Persistence;
using BasketballLeagueTracker.Infrastructure.Seeders;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddInfrastracture(builder.Configuration); // Register database

builder.Services.RegisterApplicationUser(); // Register app user 

builder.Services.AddScoped<UserManager<IdentityUser>>();

var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder= scope.ServiceProvider.GetRequiredService<TeamSeeder>();
await seeder.Seed();
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

app.MapRazorPages(); // RazorPages mapping -> Identity is working on Razor Pages

app.Run();
//Entities added to DB, IServiceCollection added, Connection String to DB added