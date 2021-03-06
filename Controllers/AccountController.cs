using System;
using System.Linq;
using System.Threading.Tasks;
using FoodService.Models.DbEntities;
using FoodService.Models.DtoModels;
using FoodService.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FoodService.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        private const double Tolerance = 0.00000001;        

        public AccountController(UserManager<AppUser> userManager,
                                 SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
            => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Login, model.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, result.IsLockedOut ? "Данный аккаунт заблокирован" : "Неверный логин или пароль");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
            => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            if (userManager.Users.Any(user => user.UserName == model.Login))
            {
                ModelState.AddModelError("", "Пользователь с таким именем уже существует");
            }
            else if (ModelState.IsValid)
            {
                AppUser user = new(model.Login) {Email = model.Email};
                await userManager.CreateAsync(user, model.Password);
                await userManager.AddToRoleAsync(user, "User");
                await signInManager.SignInAsync(user, true);
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        public IActionResult AccessDenied()
            => View();

        [HttpGet]
        public IActionResult Pay(string moneyAmount)
        {
            CardPaymentDto model = new();
            if (moneyAmount == null)
            {
                model.MoneyAmount = 0.ToString();
            }
            else
            {
                model.MoneyAmount = moneyAmount;
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Pay(CardPaymentDto model)
        {
            if (!double.TryParse(model.MoneyAmount, out var amount))
            {
                ModelState.AddModelError("doubleParseFailed", "Неверно введённая сумма");
                return View(model);
            }

            var productsModel = TempStorage.GetObject<ProductsDto>(User.Identity.Name);
            if (productsModel == null)
            {
                ModelState.AddModelError("wrongUserName", "Расхождение в именах заказчика");
                return View(model);
            }

            if (Math.Abs(productsModel.CountTotalPrice() - amount) > Tolerance)
            {
                ModelState.AddModelError("wrongMoneyAmount", "Неверная сумма оплаты");
                return View(model);
            }

            productsModel.isPaid = true;
            return Redirect("/Profile/BuyProducts");
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}