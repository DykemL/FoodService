using FoodService.Models;
using FoodService.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodService.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationContext context;
        public AccountController(ApplicationContext context)
        {
            this.context = context;
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register(RegisterDto model)
        {
            if (model.Login == null)
                ModelState.AddModelError("", "Вы не ввели логин");
            return View(model);
        }
    }
}
