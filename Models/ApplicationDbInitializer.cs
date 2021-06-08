using FoodService.Models.DbEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodService.Models
{
    public static class ApplicationDbInitializer
    {
        public static async Task InitializeAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (await roleManager.FindByNameAsync("User") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("User"));
            }
            if (await roleManager.FindByNameAsync("Admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            if (await roleManager.FindByNameAsync("SuperAdmin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
            }
            if (await roleManager.FindByNameAsync("Manager") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Manager"));
            }
            if (await roleManager.FindByNameAsync("Banned") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Banned"));
            }
            if (await userManager.FindByNameAsync("Admin") == null)
            {
                string adminEmail = "admin@foodservice.com";
                string password = "admin";
                AppUser admin = new(){ UserName = "Admin", Email = adminEmail };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
            }
            if (await userManager.FindByNameAsync("SuperAdmin") == null)
            {
                string adminEmail = "superadmin@foodservice.com";
                string password = "admin";
                AppUser admin = new() { UserName = "SuperAdmin", Email = adminEmail };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "SuperAdmin");
                }
            }
        }
    }
}
