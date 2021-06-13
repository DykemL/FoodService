using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodService.Utils
{
    public static class OrdersUtils
    {
        public static Dictionary<string, string> OrderStatusStyles = new()
        {
            { "InProgress", "text-primary" },
            { "Completed", "text-success" },
            { "Canceled", "text-danger" }
        };
    }
}
