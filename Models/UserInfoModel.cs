using FoodService.Models.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodService.Models
{
    public class UserInfoModel
    {
        public AppUser User { get; set; }
        public string Role { get; set; }
    }
}
