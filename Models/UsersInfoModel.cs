using FoodService.Models.DbEntities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodService.Models
{
    public class UsersInfoModel
    {
        public List<UserInfoModel> Users { get; set; }
        public List<string> BannedUserIds { get; set; }
        public List<IdentityRole> Roles { get; set; }
        public UsersInfoModel()
        {
            Users = new();
            BannedUserIds = new();
            Roles = new();
        }
    }
}
