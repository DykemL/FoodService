using FoodService.Models;
using FoodService.Models.DbEntities;
using FoodService.Models.ViewModels;
using FoodService.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FoodService.Controllers
{
    [Authorize(Policy = "ManagerOrHigher")]
    public class AdminController : Controller
    {
        UserManager<AppUser> userManager;
        AppDbContext appDbContext;
        RoleManager<IdentityRole> roleManager;
        SignInManager<AppUser> signInManager;

        private IWebHostEnvironment appEnvironment;
        private IHostApplicationLifetime hostApplicationLifetime { get; set; }

        public AdminController(UserManager<AppUser> userManager, 
            AppDbContext appDbContext, 
            RoleManager<IdentityRole> roleManager,
            SignInManager<AppUser> signInManager,
            IHostApplicationLifetime hostApplicationLifetime,
            IWebHostEnvironment appEnvironment)
        {
            this.userManager = userManager;
            this.appDbContext = appDbContext;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            this.hostApplicationLifetime = hostApplicationLifetime;
            this.appEnvironment = appEnvironment;
        }

        private async Task InitCurrentUserRole()
        {
            IList<string> roles = await userManager.GetRolesAsync(userManager.Users
                .Where(user => user.UserName == User.Identity.Name)
                .FirstOrDefault());
            ViewBag.UserRole = roles.FirstOrDefault();
        }
        [HttpGet]

        [Authorize(Policy = "AdminOrHigher")]
        public async Task<IActionResult> Users()
        {
            await InitCurrentUserRole();
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
        [Authorize(Policy = "AdminOrHigher")]
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
        [Authorize(Policy = "AdminOrHigher")]
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
        [Authorize(Policy = "AdminOrHigher")]
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
        [HttpGet]
        [Authorize(Policy = "AdminOrHigher")]
        public async Task<IActionResult> Controls()
        {
            await InitCurrentUserRole();
            return View();
        }
        [Authorize(Policy = "AdminOrHigher")]
        public IActionResult RestartServer()
        {
            return RedirectToAction("Controls");
        }
        [Authorize(Policy = "AdminOrHigher")]
        public IActionResult DbBackup()
        {
            string pgDumpPath = @"D:\Programs\PostgreSQL\bin\pg_dump";
            string outFile = @"D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\DbBackups\backup.sql";
            appDbContext.Backup(pgDumpPath, outFile, "localhost", "5432", "FoodService", "admin", "admin");
            MessageUtils.SetSuccessMessage(TempData, "Резервная копия успешно создана");
            return RedirectToAction("Controls");
        }
        [Authorize(Policy = "AdminOrHigher")]
        public IActionResult DbRestore()
        {
            string pgRestorePath = @"D:\Programs\PostgreSQL\bin\pg_restore";
            string inputFile = @"D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\DbBackups\backup.sql";
            appDbContext.Restore(pgRestorePath, inputFile, "localhost", "5432", "FoodService", "admin", "admin");
            MessageUtils.SetSuccessMessage(TempData, "База данных успешно восстановлена");
            return RedirectToAction("Controls");
        }
        [HttpGet]
        public async Task<IActionResult> Products()
        {
            await InitCurrentUserRole();
            List<Product> products = appDbContext.Products
                .Include(product => product.Image)
                .Include(product => product.Shop)
                .ToList();
            return View(products);
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(string name, string description, string price, string shopName, IFormFile image)
        {
            if (name == "" || name == null)
                MessageUtils.SetError(TempData, "Вы не ввели название товара");
            else if (!double.TryParse(price, out double doublePrice))
                MessageUtils.SetError(TempData, "Неверный формат цены. Используйте число");
            else
            {
                Shop shop = appDbContext.Shops.Where(shop => shop.Name == shopName).FirstOrDefault();
                if (shop == null)
                {
                    shop = new Shop() { Name = shopName };
                    await appDbContext.Shops.AddAsync(shop);
                }

                Product product = new() { Name = name, Description = description, Price = doublePrice, Shop = shop };
                await appDbContext.Products.AddAsync(product);

                if (image != null && image.FileName != "DefaultImage.jpg")
                {
                    string path = "/Images/" + image.FileName;
                    using (var fileStream = new FileStream(appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await image.CopyToAsync(fileStream);
                    }
                    LocalImage imageModel = new() { Name = image.FileName, Path = path };
                    appDbContext.Images.Add(imageModel);
                    product.Image = imageModel;
                }
                else
                {
                    LocalImage imageModel = appDbContext.Images.Where(image => image.Name == "DefaultImage.jpg").First();
                    product.Image = imageModel;
                }
                MessageUtils.SetSuccessMessage(TempData, "Продукт успешно добавлен");
                appDbContext.SaveChanges();
            }
            return RedirectToAction("Products");
        }
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            Product product = appDbContext.Products.Include(product => product.Image).Where(product => product.Id == productId).FirstOrDefault();
            if (product != null)
            {
                if (product.Image.Name != "DefaultImage.jpg")
                {
                    appDbContext.Images.Remove(product.Image);
                    System.IO.File.Delete(appEnvironment.WebRootPath + product.Image.Path);
                }
                    
                appDbContext.Products.Remove(product);
                await appDbContext.SaveChangesAsync();
            }
            else
            {
                MessageUtils.SetError(TempData, "Такого товара не существует");
            }
            MessageUtils.SetSuccessMessage(TempData, "Продукт успешно удалён");
            return RedirectToAction("Products");
        }
        [HttpPost]
        public async Task<IActionResult> ChangeProduct(int productId, string name, string description, string price, string shopName, IFormFile image)
        {
            if (name == "" || name == null)
                MessageUtils.SetError(TempData, "Вы не ввели название товара");
            else if (!double.TryParse(price, out double doublePrice))
                MessageUtils.SetError(TempData, "Неверный формат цены. Используйте число");
            else
            {
                Shop shop = appDbContext.Shops.Where(shop => shop.Name == shopName).FirstOrDefault();
                if (shop == null)
                {
                    shop = new Shop() { Name = shopName };
                    await appDbContext.Shops.AddAsync(shop);
                }

                Product product = appDbContext.Products.Where(product => product.Id == productId).FirstOrDefault();
                product.Name = name;
                product.Description = description;
                product.Price = doublePrice;

                if (image != null && image.FileName != "DefaultImage.jpg")
                {
                    string path = "/Images/" + image.FileName;
                    using (var fileStream = new FileStream(appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await image.CopyToAsync(fileStream);
                    }
                    LocalImage imageModel = new() { Name = image.FileName, Path = path };
                    appDbContext.Images.Add(imageModel);
                    product.Image = imageModel;
                }
                MessageUtils.SetSuccessMessage(TempData, "Продукт успешно изменён");
                appDbContext.SaveChanges();
            }
            return RedirectToAction("Products");
        }
        [HttpGet]
        public async Task<IActionResult> OrdersList()
        {
            await InitCurrentUserRole();
            List<Order> orders = appDbContext.Orders
                .Include(o => o.OrderStatus)
                .Include(o => o.User)
                .Where(order => order.OrderStatusId == 1)
                .OrderByDescending(order => order.OrderTimeStart)
                .ToList();
            List<ProductPack> packs = appDbContext.ProductPacks
                .Include(pack => pack.Order)
                .Include(pack => pack.Product)
                .ToList();
            foreach (var order in orders)
                order.ProductPacks = packs.Where(pack => pack.Order == order).ToList();
            return View(orders);
        }
        public async Task<IActionResult> OrderConfirm(string orderId)
        {
            Order order = appDbContext.Orders.Where(order => order.Id == int.Parse(orderId)).FirstOrDefault();
            order.OrderStatusId = 2;
            order.OrderTimeEnd = DateTime.UtcNow;
            await appDbContext.SaveChangesAsync();
            return RedirectToAction("OrdersList");
        }
        public async Task<IActionResult> OrderReject(string orderId)
        {
            Order order = appDbContext.Orders.Where(order => order.Id == int.Parse(orderId)).FirstOrDefault();
            order.OrderStatusId = 3;
            await appDbContext.SaveChangesAsync();
            return RedirectToAction("OrdersList");
        }
        [HttpGet]
        public async Task<IActionResult> OrdersHistory()
        {
            await InitCurrentUserRole();
            List<Order> orders = appDbContext.Orders
                .Include(o => o.OrderStatus)
                .Include(o => o.User)
                .OrderByDescending(o => o.OrderTimeStart)
                .ToList();
            List<ProductPack> packs = appDbContext.ProductPacks
                .Include(pack => pack.Order)
                .Include(pack => pack.Product)
                .ToList();
            foreach (var order in orders)
                order.ProductPacks = packs.Where(pack => pack.Order == order).ToList();
            return View(orders);
        }
    }
}
