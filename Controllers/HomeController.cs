using FoodService.Models;
using FoodService.Models.DbEntities;
using FoodService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FoodService.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext appDbContext;

        public HomeController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IActionResult Index(string nameFilter = null, string shopFilter = null)
        {
            IEnumerable<Product> products = appDbContext.Products
                .Include(product => product.Image)
                .Include(product => product.Shop);
            if (nameFilter != null)
                products = products.Where(product => product.Name.ToLower().Contains(nameFilter.ToLower())).ToList();
            if (shopFilter != null)
                products = products.Where(product => product.Shop.Name.ToLower().Contains(shopFilter.ToLower())).ToList();

            return View(products.ToList());
        }
        public IActionResult Product(string productId)
        {
            Product product = null;
            bool isInBasket = false;
            if (productId == null)
                return View(new Tuple<Product, bool>(product, isInBasket));
            product = appDbContext.Products
                .Where(product => product.Id == int.Parse(productId))
                .Include(product => product.Image)
                .Include(product => product.Shop)
                .FirstOrDefault();

            if (HttpContext.Request.Cookies.TryGetValue("productsBasketJson", out string strJObject))
            {
                JObject jObject;
                try
                {
                    jObject = JObject.Parse(strJObject);
                }
                catch
                {
                    return View(new Tuple<Product, bool>(null, false));
                }
                int[] ids = jObject.First.First.ToObject<int[]>();
                if (ids.Contains(product.Id))
                    isInBasket = true;
            }
            return View(new Tuple<Product, bool>(product, isInBasket));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
