using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodService.Models.DbEntities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int ShopId { get; set; }
        public Shop Shop { get; set; }
        public int ImageId { get; set; }
        public LocalImage Image { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
