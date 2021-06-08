using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodService.Models.DbEntities
{
    public class BannedUser
    {
        [Key]
        public int Id { get; set; }
        public AppUser User { get; set; }
    }
}
