using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace FoodService.Models.DtoModels
{
    public class UsersDto
    {
        public List<UserDto> Users { get; set; }
        public List<string> BannedUserIds { get; set; }
        public List<IdentityRole> Roles { get; set; }
        public UsersDto()
        {
            Users = new();
            BannedUserIds = new();
            Roles = new();
        }
    }
}
