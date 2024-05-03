using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlogMVC.Entity.Entities;
using YoutubeBlogMVC.Entity.ModelViews.Users;

namespace YoutubeBlogMVC.Service.Services.Abstraction
{
    public interface IUserService
    {
        Task<List<UserModelView>> GetAllUsersWithRoleAsync();
        Task<List<AppRole>> GetAllRolesAsync();
        Task<IdentityResult> CreateUserAsync(UserAddModelView userAddModelView);
        Task<IdentityResult> UpdateUserAsync(UserUpdateModelView userUpdateModelView);
        Task<(IdentityResult identityResult, string? userEmail)> DeleteUserAsync(Guid userId);  
        Task<AppUser> GetAppUserByIdAsync(Guid userId);
        Task<string> GetUserRoleAsync(AppUser user);
    }
}
