using FoodService.Models;
using FoodService.Models.DbEntities;
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
                UserInfoModel userInfo = new() { User = user, Role = roles[0] };
                usersInfo.Users.Add(userInfo);
            }
            usersInfo.BannedUsers = appDbContext.BannedUsers.Select(user => user.User.Id).ToHashSet();
            usersInfo.Roles = roleManager.Roles.ToHashSet();
            return View(usersInfo);
        }
        [HttpGet]
        public async Task<IActionResult> BanUser(string userId)
        {
            AppUser user = await userManager.FindByIdAsync(userId);
            BannedUser bannedUser = appDbContext.BannedUsers.Where(user => user.User.Id == userId).FirstOrDefault();
            if (bannedUser == null)
            {
                await userManager.RemoveFromRolesAsync(user, await userManager.GetRolesAsync(user));
                await userManager.AddToRoleAsync(user, "Banned");
            }
            
            return RedirectToAction("Users");
        }
        [HttpGet]
        public async Task<IActionResult> PardonUser(string userId)
        {
            AppUser user = await userManager.FindByIdAsync(userId);
            BannedUser bannedUser = appDbContext.BannedUsers.Where(user => user.User.Id == userId).FirstOrDefault();
            if (bannedUser != null)
            {
                await userManager.RemoveFromRolesAsync(user, await userManager.GetRolesAsync(user));
                await userManager.AddToRoleAsync(user, "User");
            }
            return RedirectToAction("Users");
        }
    }
}
