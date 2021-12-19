using FoodService.Models;
using FoodService.Models.DbEntities;
using FoodService.Models.DtoModels;
using FoodService.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            List<Product> products = new();
            if (HttpContext.Request.Cookies.TryGetValue("productsBasketJson", out string strJObject))
            {
                JObject jObject;
                try
                {
                    jObject = JObject.Parse(strJObject);
                }
                catch
                {
                    return View(products);
                }
                int[] ids = jObject.First.First.ToObject<int[]>();
                products = appDbContext.Products
                    .Include(product => product.Image)
                    .Include(product => product.Shop)
                    .Where(product => ids.Contains(product.Id))
                    .ToList();
                
            }
            return View(products);
        }
        [Authorize]
        [HttpPost]
        public IActionResult StartPaymentTransaction(ProductsDto model)
        {
            for (int i = 0; i < model.ProductsCount.Length; i++)
            {
                if (model.ProductsCount[i] == "" || model.ProductsCount[i] == null)
                    model.ProductsCount[i] = "1";
                else if (!double.TryParse(model.ProductsCount[i], out _))
                {
                    MessageUtils.SetError(TempData, "Неправильный формат числа продукта");
                    return RedirectToAction("Basket");
                }
            }
            try
            {
                double[] prices = model.Prices.Select(price => double.Parse(price)).ToArray();
            }
            catch (Exception)
            {
                return NotFound();
            }
            TempStorage.RemoveObject(User.Identity.Name);
            TempStorage.SetObject(User.Identity.Name, model);
            return LocalRedirect($"~/Account/Pay?moneyAmount={model.CountTotalPrice()}");
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> BuyProducts()
        {
            ProductsDto products = TempStorage.GetObject<ProductsDto>(User.Identity.Name);
            if (!products.isPaid)
                return NotFound();

            AppUser user = appDbContext.Users.Where(user => user.UserName == User.Identity.Name).FirstOrDefault();
            Order order = new() { OrderStatusId = 1, OrderTimeStart = DateTime.UtcNow, User = user};
            appDbContext.Orders.Add(order);
            for (int i = 0; i < products.ProductIds.Length; i++)
            {
                if (!int.TryParse(products.ProductsCount[i], out int count))
                    count = 1;
                ProductPack pack = new() { ProductId = int.Parse(products.ProductIds[i]),
                    Count = count,
                    Order = order
                };
                appDbContext.ProductPacks.Add(pack);
            }
            appDbContext.Orders.Add(order);
            await appDbContext.SaveChangesAsync();
            HttpContext.Response.Cookies.Delete("productsBasketJson");
            HttpContext.Response.Cookies.Append("productsBasketJson", "");
            MessageUtils.SetSuccessMessage(TempData, "Товары успешно заказаны!");
            TempStorage.RemoveObject(User.Identity.Name);
            return RedirectToAction("Orders");
        }
        public IActionResult Orders()
        {
            List<Order> orders = appDbContext.Orders
                .Include(o => o.OrderStatus)
                .Include(o => o.User)
                .Where(o => o.User.UserName == User.Identity.Name)
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
