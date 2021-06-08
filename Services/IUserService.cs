using FoodService.Models.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodService.Services
{
    public interface IUserService<TUser> where TUser : class
    {
        Task AddToRoleAsync(TUser user, string role);
        Task AddToRoleAsync(string userName, string role);
        Task AddToRolesAsync(TUser user, IEnumerable<string> roles);
        Task AddToRolesAsync(string userName, IEnumerable<string> roles);
        Task RemoveFromRoleAsync(TUser user, string role);
        Task RemoveFromRoleAsync(string userName, string role);
        Task RemoveFromRolesAsync(TUser user, IEnumerable<string> roles);
        Task RemoveFromRolesAsync(string userName, IEnumerable<string> roles);
    }
}
