using System.ComponentModel.DataAnnotations;

namespace FoodService.Models.DtoModels
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Введите логин")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
