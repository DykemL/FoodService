using FoodService.Models;
using FoodService.Models.DbEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodService.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        UserManager<AppUser> userManager;
        public AdminController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<IActionResult> Users()
        {
            List<AppUser> users = userManager.Users.ToList();
            List<UserRoleModel> userPairs = new();
            foreach (var user in users)
            {
                IList<string> roles = await userManager.GetRolesAsync(user);
                userPairs.Add(new UserRoleModel() { User = user, Role = roles[0]});
            }
            return View(userPairs);
        }
    }
}
