using System.Collections.Generic;
using System.Threading.Tasks;
using FoodService.Models;
using Microsoft.AspNetCore.Identity;

namespace FoodService.Services
{
    public class UserService<TUser> : IUserService<TUser> where TUser : class
    {
        private readonly UserManager<TUser> userManager;
        private readonly SignInManager<TUser> signInManager;
        private readonly AppDbContext appDbContext;

        public UserService(UserManager<TUser> userManager, SignInManager<TUser> signInManager, AppDbContext appDbContext)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.appDbContext = appDbContext;
        }

        public async Task AddToRoleAsync(TUser user, string role)
        {
            await userManager.AddToRoleAsync(user, role);
        }

        public async Task AddToRoleAsync(string userName, string role)
        {
            var user = await userManager.FindByNameAsync(userName);
            await AddToRoleAsync(user, role);
        }

        public async Task AddToRolesAsync(TUser user, IEnumerable<string> roles)
        {
            await userManager.AddToRolesAsync(user, roles);
        }

        public async Task AddToRolesAsync(string userName, IEnumerable<string> roles)
        {
            var user = await userManager.FindByNameAsync(userName);
            await AddToRolesAsync(user, roles);
        }

        public async Task RemoveFromRoleAsync(TUser user, string role)
        {
            await userManager.RemoveFromRoleAsync(user, role);
        }

        public async Task RemoveFromRoleAsync(string userName, string role)
        {
            var user = await userManager.FindByNameAsync(userName);
            await RemoveFromRoleAsync(user, role);
        }

        public async Task RemoveFromRolesAsync(TUser user, IEnumerable<string> roles)
        {
            await userManager.RemoveFromRolesAsync(user, roles);
        }

        public async Task RemoveFromRolesAsync(string userName, IEnumerable<string> roles)
        {
            var user = await userManager.FindByNameAsync(userName);
            await RemoveFromRolesAsync(user, roles);
        }
    }
}