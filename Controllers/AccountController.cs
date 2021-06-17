using FoodService.Models;
using FoodService.Models.DbEntities;
using FoodService.Models.DtoModels;
using FoodService.Models.ViewModels;
using FoodService.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FoodService.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> userManager, 
            RoleManager<IdentityRole> roleManager, 
            SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDtoModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Login, model.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else if (result.IsLockedOut)
                {
                    ModelState.AddModelError(string.Empty, "Данный аккаунт заблокирован");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Неверный логин или пароль");
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDtoModel model)
        {
            if (userManager.Users.Any(user => user.UserName == model.Login))
                ModelState.AddModelError("", "Пользователь с таким именем уже существует");
            else if (ModelState.IsValid)
            {
                AppUser user = new(model.Login) { Email = model.Email };
                await userManager.CreateAsync(user, model.Password);
                await userManager.AddToRoleAsync(user, "User");
                await signInManager.SignInAsync(user, true);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Pay(string moneyAmount)
        {
            CardPaymentDtoModel model = new();
            if (moneyAmount == null)
                model.MoneyAmount = 0.ToString();
            else
                model.MoneyAmount = moneyAmount;
            return View(model);
        }
        [HttpPost]
        public IActionResult Pay(CardPaymentDtoModel model)
        {
            if (!double.TryParse(model.MoneyAmount, out var amount))
            {
                ModelState.AddModelError("doubleParseFailed", "Неверно введённая сумма");
                return View(model);
            }
            ProductsDtoModel productsModel = TempStorage.GetObject<ProductsDtoModel>(User.Identity.Name);
            if (productsModel == null)
            {
                ModelState.AddModelError("wrongUserName", "Расхождение в именах заказчика");
                return View(model);
            }
            if (productsModel.CountTotalPrice() != amount)
            {
                ModelState.AddModelError("wrongMoneyAmount", "Неверная сумма оплаты");
                return View(model);
            }
            productsModel.isPaid = true;
            return Redirect($"/Profile/BuyProducts");
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
