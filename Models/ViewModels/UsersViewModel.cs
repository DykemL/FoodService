using FoodService.Models.DbEntities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodService.Models.ViewModels
{
    public class UsersViewModel
    {
        public List<UserViewModel> Users { get; set; }
        public List<string> BannedUserIds { get; set; }
        public List<IdentityRole> Roles { get; set; }
        public UsersViewModel()
        {
            Users = new();
            BannedUserIds = new();
            Roles = new();
        }
    }
}
