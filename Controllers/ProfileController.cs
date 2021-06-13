using FoodService.Models;
using FoodService.Models.DbEntities;
using FoodService.Models.DtoModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodService.Controllers
{
    public class ProfileController : Controller
    {
        AppDbContext appDbContext;
        public ProfileController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Basket()
        {
            JObject jObject = JObject.Parse(HttpContext.Request.Cookies["productsBasketJson"]);
            int[] ids = jObject.First.First.ToObject<int[]>();
            List<Product> products = appDbContext.Products
                .Include(product => product.Image)
                .Include(product => product.Shop)
                .Where(product => ids.Contains(product.Id))
                .ToList();
            return View(products);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> BuyProducts(ProductDtoModel model)
        {
            AppUser user = appDbContext.Users.Where(user => user.UserName == User.Identity.Name).FirstOrDefault();
            Order order = new() { OrderStatusId = 1, OrderTime = DateTime.UtcNow, User = user};
            appDbContext.Orders.Add(order);
            for (int i = 0; i < model.ProductId.Length; i++)
            {
                ProductPack pack = new() { ProductId = int.Parse(model.ProductId[i]),
                    Count = int.Parse(model.ProductsCount[i]),
                    Order = order
                };
                appDbContext.ProductPacks.Add(pack);
            }

            appDbContext.Orders.Add(order);
            await appDbContext.SaveChangesAsync();
            return RedirectToAction("Basket");
        }
    }
}
