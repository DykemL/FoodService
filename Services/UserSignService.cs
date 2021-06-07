using FoodService.Models.DbEntities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodService.Services
{
    public class UserSignService<TUser> : IUserSignService<TUser> where TUser : class
    {
        private readonly UserManager<TUser> userManager;
        private readonly SignInManager<TUser> signInManager;
        public UserSignService(UserManager<TUser> userManager, SignInManager<TUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public async Task AddToRoleAsync(TUser user, string role)
        {
            await userManager.AddToRoleAsync(user, role);
            await signInManager.RefreshSignInAsync(user);
        }

        public async Task AddToRoleAsync(string userName, string role)
        {
            var user = await userManager.FindByNameAsync(userName);
            await AddToRoleAsync(user, role);
        }

        public async Task AddToRolesAsync(TUser user, IEnumerable<string> roles)
        {
            await userManager.AddToRolesAsync(user, roles);
            await signInManager.RefreshSignInAsync(user);
        }

        public async Task AddToRolesAsync(string userName, IEnumerable<string> roles)
        {
            var user = await userManager.FindByNameAsync(userName);
            await AddToRolesAsync(user, roles);
        }

        public async Task RemoveFromRoleAsync(TUser user, string role)
        {
            await userManager.RemoveFromRoleAsync(user, role);
            await signInManager.RefreshSignInAsync(user);
        }

        public async Task RemoveFromRoleAsync(string userName, string role)
        {
            var user = await userManager.FindByNameAsync(userName);
            await RemoveFromRoleAsync(user, role);
        }

        public async Task RemoveFromRolesAsync(TUser user, IEnumerable<string> roles)
        {
            await userManager.RemoveFromRolesAsync(user, roles);
            await signInManager.RefreshSignInAsync(user);
        }

        public async Task RemoveFromRolesAsync(string userName, IEnumerable<string> roles)
        {
            var user = await userManager.FindByNameAsync(userName);
            await RemoveFromRolesAsync(user, roles);
        }
    }
}
