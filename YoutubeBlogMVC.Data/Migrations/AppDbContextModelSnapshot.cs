﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YoutubeBlogMVC.Data.Context;

#nullable disable

namespace YoutubeBlogMVC.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("YoutubeBlogMVC.Entity.Entities.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("b38a0c76-1f24-45ef-912f-33b2e6671236"),
                            ConcurrencyStamp = "0ff5582c-f93d-4288-a392-3ff380306b8f",
                            Name = "SuperAdmin",
                            NormalizedName = "SUPERADMIN"
                        },
                        new
                        {
                            Id = new Guid("b719a268-4272-452c-987a-95b7a1d1f127"),
                            ConcurrencyStamp = "eca04ebb-a6eb-4141-9456-1ac249d2ee49",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("62a7b0a8-62b4-4a0c-9a19-46c7a27929f6"),
                            ConcurrencyStamp = "8042367b-647e-4b5d-97aa-24799b15f589",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("YoutubeBlogMVC.Entity.Entities.AppRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("YoutubeBlogMVC.Entity.Entities.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("ab5ceb8f-9dc0-424a-a1c9-495bca357321"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "3e927d1a-60cd-477a-a77b-60835dca9d32",
                            Email = "superadmin@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Osman",
                            ImageId = new Guid("fe3d8ace-339d-40bd-b620-63fc51ce5f59"),
                            LastName = "Topuz",
                            LockoutEnabled = false,
                            NormalizedEmail = "SUPERADMIN@GMAIL.COM",
                            NormalizedUserName = "SUPERADMIN@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAECxjvczoArTl63BNi5fc9ZbvbobRfyHVH+P14kWOfyVBYDbv3SmKPbbyKbo5A3uUEA==",
                            PhoneNumber = "+905349999999",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "b7cf810b-bd22-4859-ac7d-ffa57a0b16ea",
                            TwoFactorEnabled = false,
                            UserName = "superadmin@gmail.com"
                        },
                        new
                        {
                            Id = new Guid("3d75895a-13af-4e93-8091-6cd22c173f83"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "fc3c5998-00c0-468f-8a19-3c1ed2f7fd06",
                            Email = "admin@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Mehmet",
                            ImageId = new Guid("12e5602d-bd51-4c8f-b0b0-d78024053735"),
                            LastName = "Aslan",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@GMAIL.COM",
                            NormalizedUserName = "ADMIN@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEBzMSki6tm6ifXpKHR8xY7XaCXQ3ZhdPVbCVXmGj/PN06Y3tgwy1ETI/mJM1IKfVJA==",
                            PhoneNumber = "+905419999999",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "d06094e6-6196-4ce7-889b-db1ea3583dfa",
                            TwoFactorEnabled = false,
                            UserName = "admin@gmail.com"
                        },
                        new
                        {
                            Id = new Guid("1da06e8d-3507-4fbc-b49f-3408ac12deb2"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d1da964d-ba63-4b4f-acd7-59a74d50d6eb",
                            Email = "user@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Kerim",
                            ImageId = new Guid("12e5602d-bd51-4c8f-b0b0-d78024053735"),
                            LastName = "Demir",
                            LockoutEnabled = false,
                            NormalizedEmail = "USER@GMAIL.COM",
                            NormalizedUserName = "USER@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEA0hIX684huQxCH5EDbQeJbuNPeLxuOm0dGjVUFmvdhvMVUfGtqTJ0H9iOWu+zTuwA==",
                            PhoneNumber = "+905349999999",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "87e07fe4-987e-4f9f-a133-7d1b0749c465",
                            TwoFactorEnabled = false,
                            UserName = "user@gmail.com"
                        });
                });

            modelBuilder.Entity("YoutubeBlogMVC.Entity.Entities.AppUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("YoutubeBlogMVC.Entity.Entities.AppUserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("YoutubeBlogMVC.Entity.Entities.AppUserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = new Guid("ab5ceb8f-9dc0-424a-a1c9-495bca357321"),
                            RoleId = new Guid("b38a0c76-1f24-45ef-912f-33b2e6671236")
                        },
                        new
                        {
                            UserId = new Guid("3d75895a-13af-4e93-8091-6cd22c173f83"),
                            RoleId = new Guid("b719a268-4272-452c-987a-95b7a1d1f127")
                        },
                        new
                        {
                            UserId = new Guid("1da06e8d-3507-4fbc-b49f-3408ac12deb2"),
                            RoleId = new Guid("62a7b0a8-62b4-4a0c-9a19-46c7a27929f6")
                        });
                });

            modelBuilder.Entity("YoutubeBlogMVC.Entity.Entities.AppUserToken", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("YoutubeBlogMVC.Entity.Entities.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ViewCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ImageId");

                    b.HasIndex("UserId");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2f725895-3d2f-41aa-a548-a45e2d42d46a"),
                            CategoryId = new Guid("51c55032-6f6a-47d8-833f-144c23fb67a1"),
                            Content = "ASP.NET CORE Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut arcu ante, condimentum non nibh eu, vehicula tristique eros. Praesent metus felis, rhoncus nec neque at, feugiat ultrices ligula. Integer porta, leo et tempor suscipit, mi ligula viverra lectus, nec tristique massa ante ut mi. Etiam eget tempus tortor. Duis facilisis commodo interdum. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam dui lectus, sodales in ex id, tincidunt pharetra quam.",
                            CreatedBy = "Admin test",
                            CreatedDate = new DateTime(2024, 5, 5, 17, 55, 25, 527, DateTimeKind.Local).AddTicks(1574),
                            ImageId = new Guid("fe3d8ace-339d-40bd-b620-63fc51ce5f59"),
                            IsDeleted = false,
                            Title = "ASP.NET CORE Deneme Makalesi 1",
                            UserId = new Guid("ab5ceb8f-9dc0-424a-a1c9-495bca357321"),
                            ViewCount = 15
                        },
                        new
                        {
                            Id = new Guid("47b744ff-1a2e-4882-b051-fb6ae2f24c0e"),
                            CategoryId = new Guid("bfdeca74-b674-49fd-9a3d-be63b8266645"),
                            Content = "Visual Studio orem ipsum dolor sit amet, consectetur adipiscing elit. Ut arcu ante, condimentum non nibh eu, vehicula tristique eros. Praesent metus felis, rhoncus nec neque at, feugiat ultrices ligula. Integer porta, leo et tempor suscipit, mi ligula viverra lectus, nec tristique massa ante ut mi. Etiam eget tempus tortor. Duis facilisis commodo interdum. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam dui lectus, sodales in ex id, tincidunt pharetra quam.",
                            CreatedBy = "Admin test",
                            CreatedDate = new DateTime(2024, 5, 5, 17, 55, 25, 527, DateTimeKind.Local).AddTicks(1594),
                            ImageId = new Guid("12e5602d-bd51-4c8f-b0b0-d78024053735"),
                            IsDeleted = false,
                            Title = "Visual Studio Deneme Makalesi 1",
                            UserId = new Guid("3d75895a-13af-4e93-8091-6cd22c173f83"),
                            ViewCount = 15
                        });
                });

            modelBuilder.Entity("YoutubeBlogMVC.Entity.Entities.ArticleVisitor", b =>
                {
                    b.Property<Guid>("ArticleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("VisitorId")
                        .HasColumnType("int");

                    b.HasKey("ArticleId", "VisitorId");

                    b.HasIndex("VisitorId");

                    b.ToTable("ArticleVisitors");
                });

            modelBuilder.Entity("YoutubeBlogMVC.Entity.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("51c55032-6f6a-47d8-833f-144c23fb67a1"),
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2024, 5, 5, 17, 55, 25, 527, DateTimeKind.Local).AddTicks(9673),
                            IsDeleted = false,
                            Name = "ASP.NET CORE"
                        },
                        new
                        {
                            Id = new Guid("bfdeca74-b674-49fd-9a3d-be63b8266645"),
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2024, 5, 5, 17, 55, 25, 527, DateTimeKind.Local).AddTicks(9679),
                            IsDeleted = false,
                            Name = "Visual Studio 2022"
                        });
                });

            modelBuilder.Entity("YoutubeBlogMVC.Entity.Entities.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Images");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fe3d8ace-339d-40bd-b620-63fc51ce5f59"),
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2024, 5, 5, 17, 55, 25, 528, DateTimeKind.Local).AddTicks(1483),
                            FileName = "images/test_images",
                            FileType = "jpg",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = new Guid("12e5602d-bd51-4c8f-b0b0-d78024053735"),
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2024, 5, 5, 17, 55, 25, 528, DateTimeKind.Local).AddTicks(1490),
                            FileName = "images/vs_images",
                            FileType = "png",
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("YoutubeBlogMVC.Entity.Entities.Visitor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserAgent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Visitors");
                });

            modelBuilder.Entity("YoutubeBlogMVC.Entity.Entities.AppRoleClaim", b =>
                {
                    b.HasOne("YoutubeBlogMVC.Entity.Entities.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("YoutubeBlogMVC.Entity.Entities.AppUser", b =>
                {
                    b.HasOne("YoutubeBlogMVC.Entity.Entities.Image", "Image")
                        .WithMany("Users")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");
                });

            modelBuilder.Entity("YoutubeBlogMVC.Entity.Entities.AppUserClaim", b =>
                {
                    b.HasOne("YoutubeBlogMVC.Entity.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("YoutubeBlogMVC.Entity.Entities.AppUserLogin", b =>
                {
                    b.HasOne("YoutubeBlogMVC.Entity.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("YoutubeBlogMVC.Entity.Entities.AppUserRole", b =>
                {
                    b.HasOne("YoutubeBlogMVC.Entity.Entities.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YoutubeBlogMVC.Entity.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("YoutubeBlogMVC.Entity.Entities.AppUserToken", b =>
                {
                    b.HasOne("YoutubeBlogMVC.Entity.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("YoutubeBlogMVC.Entity.Entities.Article", b =>
                {
                    b.HasOne("YoutubeBlogMVC.Entity.Entities.Category", "Category")
                        .WithMany("Articles")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YoutubeBlogMVC.Entity.Entities.Image", "Image")
                        .WithMany("Articles")
                        .HasForeignKey("ImageId");

                    b.HasOne("YoutubeBlogMVC.Entity.Entities.AppUser", "User")
                        .WithMany("Articles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Image");

                    b.Navigation("User");
                });

            modelBuilder.Entity("YoutubeBlogMVC.Entity.Entities.ArticleVisitor", b =>
                {
                    b.HasOne("YoutubeBlogMVC.Entity.Entities.Article", "Article")
                        .WithMany("ArticleVisitors")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YoutubeBlogMVC.Entity.Entities.Visitor", "Visitor")
                        .WithMany("ArticleVisitors")
                        .HasForeignKey("VisitorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("Visitor");
                });

            modelBuilder.Entity("YoutubeBlogMVC.Entity.Entities.AppUser", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("YoutubeBlogMVC.Entity.Entities.Article", b =>
                {
                    b.Navigation("ArticleVisitors");
                });

            modelBuilder.Entity("YoutubeBlogMVC.Entity.Entities.Category", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("YoutubeBlogMVC.Entity.Entities.Image", b =>
                {
                    b.Navigation("Articles");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("YoutubeBlogMVC.Entity.Entities.Visitor", b =>
                {
                    b.Navigation("ArticleVisitors");
                });
#pragma warning restore 612, 618
        }
    }
}
