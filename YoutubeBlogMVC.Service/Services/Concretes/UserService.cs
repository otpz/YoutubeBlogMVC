using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlogMVC.Data.UnitOfWorks;
using YoutubeBlogMVC.Entity.Entities;
using YoutubeBlogMVC.Entity.ModelViews.Users;
using YoutubeBlogMVC.Service.Services.Abstraction;

namespace YoutubeBlogMVC.Service.Services.Concretes
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> CreateUserAsync(UserAddModelView userAddModelView)
        {
            var userMap = _mapper.Map<AppUser>(userAddModelView); // add mv'den user'a map'leme işlemi yapıldı.
            userMap.UserName = userAddModelView.Email;
            var result = await _userManager.CreateAsync(userMap, string.IsNullOrEmpty(userAddModelView.Password) ? "" : userAddModelView.Password);
            if (result.Succeeded)
            {
                var findRole = await _roleManager.FindByIdAsync(userAddModelView.RoleId.ToString());
                await _userManager.AddToRoleAsync(userMap, findRole.ToString());
                return result;
            }
            else
            {
                return result;
            }
        }

        public async Task<(IdentityResult identityResult, string? userEmail)> DeleteUserAsync(Guid userId)
        {
            var user = await GetAppUserByIdAsync(userId);
            var result = await _userManager.DeleteAsync(user);
            return (result, user.Email);
        }

        public async Task<List<AppRole>> GetAllRolesAsync()
        {
            var roles = await _roleManager.Roles.ToListAsync();

            return roles;
        }

        public async Task<List<UserModelView>> GetAllUsersWithRoleAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            var userModelViewMap = _mapper.Map<List<UserModelView>>(users);

            foreach (var user in userModelViewMap)
            {
                var findUser = await _userManager.FindByIdAsync(user.Id.ToString());
                var role = await _userManager.GetRolesAsync(findUser);

                user.Role = role[0];
            }

            return userModelViewMap;
        }

        public async Task<AppUser> GetAppUserByIdAsync(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            return user;
        }

        public async Task<string> GetUserRoleAsync(AppUser user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            return userRoles[0];
        }

        public async Task<IdentityResult> UpdateUserAsync(UserUpdateModelView userUpdateModelView)
        {
            var user = await GetAppUserByIdAsync(userUpdateModelView.Id);
            var userRole = await GetUserRoleAsync(user);

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                await _userManager.RemoveFromRoleAsync(user, userRole);
                var findRole = await _roleManager.FindByIdAsync(userUpdateModelView.RoleId.ToString());
                await _userManager.AddToRoleAsync(user, findRole.Name);
                return result;
            }
            else
            {
                return result;
            }
        }
    }
}   
