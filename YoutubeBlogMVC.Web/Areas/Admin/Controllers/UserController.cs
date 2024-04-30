using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YoutubeBlogMVC.Entity.Entities;
using YoutubeBlogMVC.Entity.ModelViews.Users;

namespace YoutubeBlogMVC.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public UserController(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
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
    }
}
