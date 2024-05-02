using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlogMVC.Entity.Entities;

namespace YoutubeBlogMVC.Entity.ModelViews.Users
{
    public class UserProfileModelView
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CurrentPassword { get; set; }
        public Image Image { get; set; }
        public string? NewPassword { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
