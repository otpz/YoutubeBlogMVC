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
using YoutubeBlogMVC.Web.ResultMessages;

namespace YoutubeBlogMVC.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IValidator<AppUser> _validator;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IImageHelper _imageHelper;
        private readonly IUnitOfWork _unitOfWork;

        public UserController(UserManager<AppUser> userManager,RoleManager<AppRole> roleManager, IValidator<AppUser> validator, IMapper mapper, IToastNotification toastNotification, SignInManager<AppUser> signInManager, IImageHelper imageHelper, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _validator = validator;
            _mapper = mapper;
            _toastNotification = toastNotification;
            _signInManager = signInManager;
            _imageHelper = imageHelper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult>  Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var userModelViewMap = _mapper.Map<List<UserModelView>>(users);

            foreach (var user in userModelViewMap)
            {
                var findUser = await _userManager.FindByIdAsync(user.Id.ToString());
                var role = await _userManager.GetRolesAsync(findUser);

                user.Role = role[0];
            }

            return View(userModelViewMap);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(new UserAddModelView { Roles = roles });
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserAddModelView userAddModelView)
        {
            var userMap = _mapper.Map<AppUser>(userAddModelView); // add mv'den user'a map'leme işlemi yapıldı.
            var validation = await _validator.ValidateAsync(userMap);
            var roles = await _roleManager.Roles.ToListAsync();

            if (ModelState.IsValid) 
            {
                userMap.UserName = userAddModelView.Email;
                var result = await _userManager.CreateAsync(userMap, string.IsNullOrEmpty(userAddModelView.Password) ? "" : userAddModelView.Password);
                if (result.Succeeded)
                {
                    var findRole = await _roleManager.FindByIdAsync(userAddModelView.RoleId.ToString());
                    await _userManager.AddToRoleAsync(userMap, findRole.ToString());
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
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var roles = await _roleManager.Roles.ToListAsync();

            var userUpdateModelViewMap = _mapper.Map<UserUpdateModelView>(user);
            userUpdateModelViewMap.Roles = roles;

            return View(userUpdateModelViewMap);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserUpdateModelView userUpdateModelView)
        {
            var user = await _userManager.FindByIdAsync(userUpdateModelView.Id.ToString());

            if (user != null)
            {
                var userRole = string.Join("", await _userManager.GetRolesAsync(user));
                var roles = await _roleManager.Roles.ToListAsync();
                if (ModelState.IsValid)
                {
                    var map = _mapper.Map(userUpdateModelView, user); // update mv'dan user'a yeni gelen alanları aktardık.
                    var validation = await _validator.ValidateAsync(map);

                    if (validation.IsValid)
                    {
                        user.UserName = userUpdateModelView.Email;
                        user.SecurityStamp = Guid.NewGuid().ToString();
                        var result = await _userManager.UpdateAsync(user);

                        if (result.Succeeded)
                        {
                            await _userManager.RemoveFromRoleAsync(user, userRole);
                            var findRole = await _roleManager.FindByIdAsync(userUpdateModelView.RoleId.ToString());
                            await _userManager.AddToRoleAsync(user, findRole.Name);
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
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                _toastNotification.AddSuccessToastMessage(Messages.User.Delete(user.Email), new ToastrOptions { Title = "Başarılı" });
                return RedirectToAction("Index", "User", new { Area = "Admin" });
            }
            else
            {
                foreach (var errors in result.Errors)
                {
                    ModelState.AddModelError("", errors.Description);
                }
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var userImage = await _unitOfWork.GetRepository<AppUser>().GetAsync(x => x.Id == user.Id, x => x.Image);
            var map = _mapper.Map<UserProfileModelView>(user);

            map.Image.FileName = userImage.Image.FileName;
            
            return View(map);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(UserProfileModelView userProfileModelView)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (ModelState.IsValid)
            {
                var isVerified = await _userManager.CheckPasswordAsync(user, userProfileModelView.CurrentPassword);
                if (isVerified && userProfileModelView.NewPassword != null && userProfileModelView.Photo != null)
                {
                    var result = await _userManager.ChangePasswordAsync(user, userProfileModelView.CurrentPassword, userProfileModelView.NewPassword);
                    if (result.Succeeded)
                    {
                        await _userManager.UpdateSecurityStampAsync(user);
                        await _signInManager.SignOutAsync();
                        await _signInManager.PasswordSignInAsync(user, userProfileModelView.NewPassword, true, false);

                        user.FirstName = userProfileModelView.FirstName;
                        user.LastName = userProfileModelView.LastName;
                        user.PhoneNumber = userProfileModelView.PhoneNumber;

                        var imageUpload = await _imageHelper.Upload($"{userProfileModelView.FirstName} {userProfileModelView.LastName}", userProfileModelView.Photo, ImageType.User);
                        Image image = new(imageUpload.FullName, userProfileModelView.Photo.ContentType, user.Email);
                        
                        await _unitOfWork.GetRepository<Image>().AddAsync(image);

                        user.ImageId = image.Id;
                        await _userManager.UpdateAsync(user);

                        await _unitOfWork.SaveAsync();


                        _toastNotification.AddSuccessToastMessage("Şifreniz ve bilgileriniz başarıyla değiştirilmiştir.");
                        return RedirectToAction("Profile", "User", new { Area = "Admin" });
                    }
                    else
                    {
                       return RedirectToAction("Profile", "User", new { Area = "Admin" });
                    }
                }
                else if (isVerified && userProfileModelView.Photo != null)
                {
                    await _userManager.UpdateSecurityStampAsync(user);
                    user.FirstName = userProfileModelView.FirstName;
                    user.LastName = userProfileModelView.LastName;
                    user.PhoneNumber = userProfileModelView.PhoneNumber;

                    var imageUpload = await _imageHelper.Upload($"{userProfileModelView.FirstName} {userProfileModelView.LastName}", userProfileModelView.Photo, ImageType.User);
                    Image image = new(imageUpload.FullName, userProfileModelView.Photo.ContentType, user.Email);

                    await _unitOfWork.GetRepository<Image>().AddAsync(image);

                    user.ImageId = image.Id;
                    await _userManager.UpdateAsync(user);
                    await _unitOfWork.SaveAsync();
                    _toastNotification.AddSuccessToastMessage("Bilgileriniz başarıyla değiştirilmiştir.");
                   return RedirectToAction("Profile", "User", new { Area = "Admin" });
                } else
                {
                    _toastNotification.AddErrorToastMessage("Bilgileriniz güncellenirken bir hata oluştu");
                   return RedirectToAction("Profile", "User", new { Area = "Admin" });
                }
            }
           return RedirectToAction("Profile", "User", new { Area = "Admin" });
        }

    }
}
