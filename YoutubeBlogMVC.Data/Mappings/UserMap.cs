using Microsoft.AspNetCore.Identity;
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
    public class UserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            // Primary key
            builder.HasKey(u => u.Id);

            // Indexes for "normalized" username and email, to allow efficient lookups
            builder.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
            builder.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");

            // Maps to the AspNetUsers table
            builder.ToTable("AspNetUsers");

            // A concurrency token for use with the optimistic concurrency checking
            builder.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

            // Limit the size of columns to use efficient database types
            builder.Property(u => u.UserName).HasMaxLength(256);
            builder.Property(u => u.NormalizedUserName).HasMaxLength(256);
            builder.Property(u => u.Email).HasMaxLength(256);
            builder.Property(u => u.NormalizedEmail).HasMaxLength(256);

            // The relationships between User and other entity types
            // Note that these relationships are configured with no navigation properties

            // Each User can have many UserClaims
            builder.HasMany<AppUserLogin>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

            // Each User can have many UserLogins
            builder.HasMany<AppUserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

            // Each User can have many UserTokens
            builder.HasMany<AppUserLogin>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

            // Each User can have many entries in the UserRole join table
            builder.HasMany<AppUserLogin>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();

            var superAdmin = new AppUser
            {
                Id = Guid.Parse("AB5CEB8F-9DC0-424A-A1C9-495BCA357321"),
                UserName = "superadmin@gmail.com",
                NormalizedUserName = "SUPERADMIN@GMAIL.COM",
                Email = "superadmin@gmail.com",
                NormalizedEmail = "SUPERADMIN@GMAIL.COM",
                PhoneNumber = "+905349999999",
                FirstName = "Osman",
                LastName = "Topuz",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                ImageId = Guid.Parse("FE3D8ACE-339D-40BD-B620-63FC51CE5F59"),
            };
            superAdmin.PasswordHash = CreatePassHash(superAdmin, "123123asd");

            var admin = new AppUser
            {
                Id = Guid.Parse("3D75895A-13AF-4E93-8091-6CD22C173F83"),
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                PhoneNumber = "+905419999999",
                FirstName = "Mehmet",
                LastName = "Aslan",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                ImageId = Guid.Parse("12E5602D-BD51-4C8F-B0B0-D78024053735"),
            };
            admin.PasswordHash = CreatePassHash(admin, "123123asd");

            var user = new AppUser
            {
                Id = Guid.Parse("1DA06E8D-3507-4FBC-B49F-3408AC12DEB2"),
                UserName = "user@gmail.com",
                NormalizedUserName = "USER@GMAIL.COM",
                Email = "user@gmail.com",
                NormalizedEmail = "USER@GMAIL.COM",
                PhoneNumber = "+905349999999",
                FirstName = "Kerim",
                LastName = "Demir",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                ImageId = Guid.Parse("12E5602D-BD51-4C8F-B0B0-D78024053735"),
            };
            user.PasswordHash = CreatePassHash(user, "123123asd");

            builder.HasData(superAdmin, admin, user);
        }

        private string CreatePassHash(AppUser user, string password)
        {
            var passwordHasher = new PasswordHasher<AppUser>();

            return passwordHasher.HashPassword(user, password);
        }
    }
}
