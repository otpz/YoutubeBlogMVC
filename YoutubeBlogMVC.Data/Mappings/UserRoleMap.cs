using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlogMVC.Entity.Entities;

namespace YoutubeBlogMVC.Data.Mappings
{
    public class UserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("AspNetUserRoles");

            builder.HasData(
            new AppUserRole
            {
                UserId = Guid.Parse("AB5CEB8F-9DC0-424A-A1C9-495BCA357321"),
                RoleId = Guid.Parse("B38A0C76-1F24-45EF-912F-33B2E6671236")
            },
            new AppUserRole
            {
                UserId = Guid.Parse("3D75895A-13AF-4E93-8091-6CD22C173F83"),
                RoleId = Guid.Parse("B719A268-4272-452C-987A-95B7A1D1F127")
            },
            new AppUserRole
            {
                UserId = Guid.Parse("1DA06E8D-3507-4FBC-B49F-3408AC12DEB2"),
                RoleId = Guid.Parse("62A7B0A8-62B4-4A0C-9A19-46C7A27929F6")
            });
        }
    }
}
