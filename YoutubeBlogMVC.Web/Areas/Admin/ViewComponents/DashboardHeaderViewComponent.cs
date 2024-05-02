using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YoutubeBlogMVC.Entity.Entities;
using YoutubeBlogMVC.Entity.ModelViews.Users;

namespace YoutubeBlogMVC.Web.Areas.Admin.ViewComponents
{
    public class DashboardHeaderViewComponent: ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public DashboardHeaderViewComponent(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loggedInUser = await _userManager.GetUserAsync(HttpContext.User);
            var userMap = _mapper.Map<UserModelView>(loggedInUser);
            var role = string.Join("", await _userManager.GetRolesAsync(loggedInUser));
            userMap.Role = role;

            return View(userMap);
        }
    }
}
