using FoodService.Models;
using FoodService.Models.DbEntities;
using FoodService.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        public AdminController(UserManager<AppUser> userManager, 
            AppDbContext appDbContext, 
            RoleManager<IdentityRole> roleManager,
            SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.appDbContext = appDbContext;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }
        public async Task<IActionResult> Users()
        {
            List<AppUser> users = userManager.Users.ToList();
            UsersInfoModel usersInfo = new();
            foreach (var user in users)
            {
                IList<string> roles = await userManager.GetRolesAsync(user);
                UserInfoModel userInfo = new() { User = user, Role = roles.First() };
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
                ErrorUtils.SetError(TempData, "Вы не можете заблокировать себя");
            }
            if (!await userManager.IsLockedOutAsync(user))
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
            if (await userManager.IsLockedOutAsync(user))
            {
                await userManager.SetLockoutEndDateAsync(user, null);
            }
            return RedirectToAction("Users");
        }
        [HttpGet]
        public async Task<IActionResult> ChangeRole(string userId, string roleName)
        {
            AppUser user = await userManager.FindByIdAsync(userId);
            await userManager.RemoveFromRolesAsync(user, await userManager.GetRolesAsync(user));
            await userManager.AddToRoleAsync(user, roleName);
            return RedirectToAction("Users");
        }
    }
}
