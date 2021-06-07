using FoodService.Models;
using FoodService.Models.DbEntities;
using FoodService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FoodService.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserSignService<AppUser> userService;

        public HomeController(IUserSignService<AppUser> userService)
        {
            this.userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public async Task<IActionResult> Privacy()
        {
            await userService.AddToRolesAsync("Admin", new string[] { "Admin", "User" });

            return View();
        }
        public IActionResult AddUser()
        {
            return new OkResult();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
