using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeBlogMVC.Entity.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid ImageId { get; set; } = Guid.Parse("FE3D8ACE-339D-40BD-B620-63FC51CE5F59");
        public Image Image { get; set; }
        public ICollection<Article> Articles { get; set; }

    }
}
