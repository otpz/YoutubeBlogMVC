using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using System.Data;
using System.Runtime.InteropServices;
using YoutubeBlogMVC.Data.Mappings;
using YoutubeBlogMVC.Data.UnitOfWorks;
using YoutubeBlogMVC.Entity.Entities;
using YoutubeBlogMVC.Entity.Enums;
using YoutubeBlogMVC.Entity.ModelViews.Articles;
using YoutubeBlogMVC.Entity.ModelViews.Users;
using YoutubeBlogMVC.Service.Helpers.Images;
using YoutubeBlogMVC.Service.Services.Abstraction;
using YoutubeBlogMVC.Web.ResultMessages;

namespace YoutubeBlogMVC.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IValidator<AppUser> _validator;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;
        private readonly IUserService _userService;

        public UserController(IUserService userService, IValidator<AppUser> validator, IMapper mapper, IToastNotification toastNotification)
        {
            _validator = validator;
            _mapper = mapper;
            _toastNotification = toastNotification;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult>  Index()
        {
            var result = await _userService.GetAllUsersWithRoleAsync();

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var roles = await _userService.GetAllRolesAsync();
            return View(new UserAddModelView { Roles = roles });
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserAddModelView userAddModelView)
        {
            var userMap = _mapper.Map<AppUser>(userAddModelView); // add mv'den user'a map'leme işlemi yapıldı.
            var validation = await _validator.ValidateAsync(userMap);
            var roles = await _userService.GetAllRolesAsync();

            if (ModelState.IsValid) 
            {
                var result = await _userService.CreateUserAsync(userAddModelView);
                if (result.Succeeded)
                {
                    _toastNotification.AddSuccessToastMessage(Messages.User.Add(userMap.FirstName), new ToastrOptions { Title = "Başarılı" });
                    return RedirectToAction("Index", "User", new { Area = "Admin" });
                } else
                {
                    foreach (var errors in result.Errors)
                    {
                        ModelState.AddModelError("", errors.Description);
                    }
                    validation.AddToModelState(this.ModelState);
                    return View(new UserAddModelView { Roles = roles });
                }
            }

            return View(new UserAddModelView { Roles = roles });
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid userId)
        {
            var user = await _userService.GetAppUserByIdAsync(userId);
            var roles = await _userService.GetAllRolesAsync();

            var userUpdateModelViewMap = _mapper.Map<UserUpdateModelView>(user);
            userUpdateModelViewMap.Roles = roles;

            return View(userUpdateModelViewMap);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserUpdateModelView userUpdateModelView)
        {
            var user = await _userService.GetAppUserByIdAsync(userUpdateModelView.Id);

            if (user != null)
            {
                var roles = await _userService.GetAllRolesAsync();

                if (ModelState.IsValid)
                {
                    var map = _mapper.Map(userUpdateModelView, user); // update mv'dan user'a yeni gelen alanları aktardık.
                    var validation = await _validator.ValidateAsync(map);

                    if (validation.IsValid)
                    {
                        user.UserName = userUpdateModelView.Email;
                        user.SecurityStamp = Guid.NewGuid().ToString();
                        var result = await _userService.UpdateUserAsync(userUpdateModelView);

                        if (result.Succeeded)
                        {
                            _toastNotification.AddSuccessToastMessage(Messages.User.Update(userUpdateModelView.Email), new ToastrOptions { Title = "Başarılı" });
                            return RedirectToAction("Index", "User", new { Area = "Admin" });
                        }
                        else
                        {
                            foreach (var errors in result.Errors)
                            {
                                ModelState.AddModelError("", errors.Description);
                            }
                            validation.AddToModelState(this.ModelState);
                            return View(new UserUpdateModelView { Roles = roles });
                        }
                    }
                    else
                    {
                        validation.AddToModelState(this.ModelState);
                        return View(new UserUpdateModelView { Roles = roles });
                    }

                }
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Delete (Guid userId)
        {
            var result = await _userService.DeleteUserAsync(userId);

            if (result.identityResult.Succeeded)
            {
                _toastNotification.AddSuccessToastMessage(Messages.User.Delete(result.userEmail), new ToastrOptions { Title = "Başarılı" });
                return RedirectToAction("Index", "User", new { Area = "Admin" });
            }
            else
            {
                foreach (var errors in result.identityResult.Errors)
                {
                    ModelState.AddModelError("", errors.Description);
                }
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var userMap = await _userService.GetUserProfileAsync();
            return View(userMap);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(UserProfileModelView userProfileModelView)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.UserProfileUpdateAsync(userProfileModelView);
                if (result)
                {
                    _toastNotification.AddSuccessToastMessage("Profil güncelleme işlemi başarıyla tamamlandı.", new ToastrOptions { Title = "Başarılı" });
                }
                else
                {
                    var profile = await _userService.GetUserProfileAsync();
                    _toastNotification.AddErrorToastMessage("Profil güncellenirken bir hata oluştu.", new ToastrOptions { Title = "Hata!" });
                    return View(profile);
                }
                return RedirectToAction("Profile", "User", new { Area = "Admin" });
            }
            else
                return NotFound();
        }
    }
}
