using System.Collections.Generic;

namespace FoodService.Utils
{
    public static class RoleSettings
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
