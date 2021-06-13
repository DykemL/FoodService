using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodService.Utils
{
    public static class RoleUtils
    {
        public static HashSet<string> AdminOrHigherSet = new() 
        { 
            "Admin", "SuperAdmin"
        };
        public static HashSet<string> ManagerOrHigherSet = new()
        {
            "Manager", "Admin", "SuperAdmin"
        };
        public static Dictionary<string, string> RoleStyles = new()
        {
            { "Admin", "text-primary" },
            { "SuperAdmin", "text-danger" },
            { "User", "text-secondary" },
            { "Manager", "text-warning" }
        };
    }
}
