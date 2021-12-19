using FoodService.Models.DbEntities;

namespace FoodService.Models.DtoModels
{
    public class UserDto
    {
        public AppUser User { get; set; }
        public string Role { get; set; }
    }
}
