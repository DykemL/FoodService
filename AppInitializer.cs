using FoodService.Models;
using FoodService.Models.DbEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodService
{
    public static class AppInitializer
    {
        public static async Task Init(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var appDbContext = services.GetRequiredService<AppDbContext>();
                var userManager = services.GetRequiredService<UserManager<AppUser>>();
                var rolesManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                await ApplicationDbInitializer.InitializeAsync(appDbContext, userManager, rolesManager);
            }
            catch (Exception exception)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(exception, "Init error");
            }
        }
    }
}
