using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlogMVC.Data.UnitOfWorks;
using YoutubeBlogMVC.Entity.Entities;
using YoutubeBlogMVC.Entity.ModelViews.Users;
using YoutubeBlogMVC.Service.Extensions;
using YoutubeBlogMVC.Service.Helpers.Images;
using YoutubeBlogMVC.Service.Services.Abstraction;
using YoutubeBlogMVC.Entity.Enums;

namespace YoutubeBlogMVC.Service.Services.Concretes
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IImageHelper _imageHelper;
        private readonly ClaimsPrincipal _user;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IHttpContextAccessor httpContextAccessor, SignInManager<AppUser> signInManager, IImageHelper imageHelper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _httpContextAccessor = httpContextAccessor;
            _signInManager = signInManager;
            _imageHelper = imageHelper;
            _user = _httpContextAccessor.HttpContext.User;
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

        public async Task<UserProfileModelView> GetUserProfileAsync()
        {
            var userId = _user.GetLoggedInUserId();
            var getUserWithImage = await _unitOfWork.GetRepository<AppUser>().GetAsync(x => x.Id == userId, x => x.Image);
            var map = _mapper.Map<UserProfileModelView>(getUserWithImage);

            map.Image.FileName = getUserWithImage.Image.FileName;

            return map;
        }

        private async Task<Guid>UploadImageForUser(UserProfileModelView userProfileModelView)
        {
            var userEmail = _user.GetLoggedInEmail();
            var imageUpload = await _imageHelper.Upload($"{userProfileModelView.FirstName} {userProfileModelView.LastName}", userProfileModelView.Photo, ImageType.User);
            Image image = new(imageUpload.FullName, userProfileModelView.Photo.ContentType, userEmail);
            await _unitOfWork.GetRepository<Image>().AddAsync(image);
            
            return image.Id;
        }

        public async Task<bool> UserProfileUpdateAsync(UserProfileModelView userProfileModelView)
        {
            var userId = _user.GetLoggedInUserId();

            var user = await GetAppUserByIdAsync(userId);
            var imageId = user.ImageId;

            var isVerified = await _userManager.CheckPasswordAsync(user, userProfileModelView.CurrentPassword);

            if (isVerified && userProfileModelView.NewPassword != null)
            {
                var result = await _userManager.ChangePasswordAsync(user, userProfileModelView.CurrentPassword, userProfileModelView.NewPassword);
                if (result.Succeeded)
                {
                    await _userManager.UpdateSecurityStampAsync(user);

                    await _signInManager.SignOutAsync();
                    await _signInManager.PasswordSignInAsync(user, userProfileModelView.NewPassword, true, false);

                    _mapper.Map(userProfileModelView, user);

                    if (userProfileModelView.Photo != null)
                        user.ImageId = await UploadImageForUser(userProfileModelView);
                    else
                        user.ImageId = imageId;

                    await _userManager.UpdateAsync(user);
                    await _unitOfWork.SaveAsync();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (isVerified)
            {
                await _userManager.UpdateSecurityStampAsync(user);

                _mapper.Map(userProfileModelView, user);

                if (userProfileModelView.Photo != null)
                    user.ImageId = await UploadImageForUser(userProfileModelView);
                else
                    user.ImageId = imageId;

                await _userManager.UpdateAsync(user);
                await _unitOfWork.SaveAsync();

                return true;
            }
            else
            {
                return false;
            }
        }
    }

}   
