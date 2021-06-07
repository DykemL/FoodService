using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodService.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Введите логин")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
