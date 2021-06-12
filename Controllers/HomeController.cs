using FoodService.Models;
using FoodService.Models.DbEntities;
using FoodService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly UserManager<AppUser> userManager;
        private readonly AppDbContext appDbContext;

        public HomeController(UserManager<AppUser> userManager, AppDbContext appDbContext)
        {
            this.userManager = userManager;
            this.appDbContext = appDbContext;
        }

        public IActionResult Index(string filterByName = null)
        {
            List<Product> products;
            if (filterByName == null)
            {
                products = appDbContext.Products
                .Include(product => product.Image)
                .Include(product => product.Shop)
                .ToList();
            }
            else
            {
                products = appDbContext.Products
                .Include(product => product.Image)
                .Include(product => product.Shop)
                .Where(product => product.Name.ToLower().Contains(filterByName.ToLower()))
                .ToList();
            }

            return View(products);
        }

        public async Task<IActionResult> Privacy()
        {
            AppUser user = await userManager.FindByNameAsync("Admin");
            await userManager.RemoveFromRolesAsync(user, await userManager.GetRolesAsync(user));
            await userManager.AddToRolesAsync(user, new string[] { "Admin" });
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
