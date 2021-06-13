using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodService.Models.DbEntities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public List<ProductPack> ProductPacks { get; set; } = new List<ProductPack>();
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public int OrderStatusId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime OrderTime { get; set; }
    }
}
