using FoodService.Models;
using FoodService.Models.DbEntities;
using FoodService.Models.ViewModels;
using FoodService.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FoodService.Controllers
{
    [Authorize(Policy = "AdminOrHigher")]
    public class AdminController : Controller
    {
        UserManager<AppUser> userManager;
        AppDbContext appDbContext;
        RoleManager<IdentityRole> roleManager;
        SignInManager<AppUser> signInManager;

        private IHostApplicationLifetime hostApplicationLifetime { get; set; }

        public AdminController(UserManager<AppUser> userManager, 
            AppDbContext appDbContext, 
            RoleManager<IdentityRole> roleManager,
            SignInManager<AppUser> signInManager,
            IHostApplicationLifetime hostApplicationLifetime)
        {
            this.userManager = userManager;
            this.appDbContext = appDbContext;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            this.hostApplicationLifetime = hostApplicationLifetime;
        }
        public async Task<IActionResult> Users()
        {
            List<AppUser> users = userManager.Users.ToList();
            UsersViewModel usersInfo = new();
            foreach (var user in users)
            {
                IList<string> roles = await userManager.GetRolesAsync(user);
                UserViewModel userInfo = new() { User = user, Role = roles.First() };
                if (await userManager.IsLockedOutAsync(user))
                    usersInfo.BannedUserIds.Add(user.Id);
                usersInfo.Users.Add(userInfo);
            }
            usersInfo.Roles = roleManager.Roles.OrderBy(role => role.Name).ToList();
            usersInfo.Users = usersInfo.Users.OrderBy(user => user.User.UserName).ToList();
            return View(usersInfo);
        }
        [HttpGet]
        public async Task<IActionResult> BanUser(string userId)
        {
            AppUser user = await userManager.FindByIdAsync(userId);
            if (user.UserName == User.Identity.Name)
            {
                MessageUtils.SetError(TempData, "Вы не можете заблокировать себя");
            }
            else if (await userManager.IsInRoleAsync(user, "SuperAdmin"))
            {
                MessageUtils.SetError(TempData, "Вы не можете заблокировать суперадминистратора");
            }
            else if (!await userManager.IsLockedOutAsync(user))
            {
                await userManager.UpdateSecurityStampAsync(user);
                await userManager.SetLockoutEndDateAsync(user, DateTimeOffset.MaxValue);
            }
            
            return RedirectToAction("Users");
        }
        [HttpGet]
        public async Task<IActionResult> UnbanUser(string userId)
        {
            AppUser user = await userManager.FindByIdAsync(userId);
            if (!await userManager.IsLockedOutAsync(user))
            {
                MessageUtils.SetError(TempData, "Этот пользователь не заблокирован");
            }
            else
            {
                await userManager.SetLockoutEndDateAsync(user, null);
            }
            return RedirectToAction("Users");
        }
        [HttpGet]
        public async Task<IActionResult> ChangeRole(string userId, string roleName)
        {
            AppUser user = await userManager.FindByIdAsync(userId);
            if (user.UserName == User.Identity.Name)
            {
                MessageUtils.SetError(TempData, "Вы не можете сменить свою роль");
            }
            else if (await userManager.IsInRoleAsync(user, "SuperAdmin"))
            {
                MessageUtils.SetError(TempData, "Вы не можете сменить роль суперадминистратора");
            }
            else if (roleName == "SuperAdmin")
            {
                MessageUtils.SetError(TempData, "Вы не можете назначить суперадминистратора");
            }
            else
            {
                await userManager.RemoveFromRolesAsync(user, await userManager.GetRolesAsync(user));
                await userManager.AddToRoleAsync(user, roleName);
            }
            return RedirectToAction("Users");
        }
        public IActionResult Controls()
        {
            return View();
        }
        public IActionResult RestartServer()
        {
            return RedirectToAction("Controls");
        }
        public IActionResult DbBackup()
        {
            string pgDumpPath = @"D:\Programs\PostgreSQL\bin\pg_dump";
            string outFile = @"D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\DbBackups\backup.sql";
            appDbContext.Backup(pgDumpPath, outFile, "localhost", "5432", "FoodService", "admin", "admin");
            MessageUtils.SetSuccessMessage(TempData, "Резервная копия успешно создана");
            return RedirectToAction("Controls");
        }
        public IActionResult DbRestore()
        {
            string pgRestorePath = @"D:\Programs\PostgreSQL\bin\pg_restore";
            string inputFile = @"D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\DbBackups\backup.sql";
            appDbContext.Restore(pgRestorePath, inputFile, "localhost", "5432", "FoodService", "admin", "admin");
            MessageUtils.SetSuccessMessage(TempData, "База данных успешно восстановлена");
            return RedirectToAction("Controls");
        }
        public IActionResult Products()
        {
            return View();
        }
    }
}
