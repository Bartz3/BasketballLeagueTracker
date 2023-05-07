using BasketballLeagueTracker.Domain.Entities;
using BasketballLeagueTracker.Infrastructure.Persistence;
using BasketballLeagueTracker.Infrastructure.Seeders;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballLeagueTracker.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastracture(this IServiceCollection services,IConfiguration configuration )
        {
            services.AddDbContext<BasketballLeagueTrackerDbContext>(options => options.UseSqlServer
                (configuration.GetConnectionString("BasketballLeagueTrackerCS"))); // Database register

            services.AddScoped<TeamSeeder>();
        }
        public static void RegisterApplicationUser(this IServiceCollection services) {
            services.AddIdentity<ApplicationUser,IdentityRole>()
                .AddEntityFrameworkStores<BasketballLeagueTrackerDbContext>()
                .AddDefaultTokenProviders();
        }

    }
}
