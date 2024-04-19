using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YoutubeBlogMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedCompleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("51c55032-6f6a-47d8-833f-144c23fb67a1"), "Admin Test", new DateTime(2024, 4, 19, 11, 58, 54, 199, DateTimeKind.Local).AddTicks(5006), null, null, false, null, null, "ASP.NET CORE" },
                    { new Guid("bfdeca74-b674-49fd-9a3d-be63b8266645"), "Admin Test", new DateTime(2024, 4, 19, 11, 58, 54, 199, DateTimeKind.Local).AddTicks(5010), null, null, false, null, null, "Visual Studio 2022" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FileName", "FileType", "IsDeleted", "ModifiedBy", "ModifiedDate" },
                values: new object[,]
                {
                    { new Guid("12e5602d-bd51-4c8f-b0b0-d78024053735"), "Admin Test", new DateTime(2024, 4, 19, 11, 58, 54, 199, DateTimeKind.Local).AddTicks(6116), null, null, "images/vs_images", "png", false, null, null },
                    { new Guid("fe3d8ace-339d-40bd-b620-63fc51ce5f59"), "Admin Test", new DateTime(2024, 4, 19, 11, 58, 54, 199, DateTimeKind.Local).AddTicks(6112), null, null, "images/test_images", "jpg", false, null, null }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("c70467bb-bd9e-4910-b56a-9787dcda0082"), new Guid("51c55032-6f6a-47d8-833f-144c23fb67a1"), "ASP.NET CORE Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut arcu ante, condimentum non nibh eu, vehicula tristique eros. Praesent metus felis, rhoncus nec neque at, feugiat ultrices ligula. Integer porta, leo et tempor suscipit, mi ligula viverra lectus, nec tristique massa ante ut mi. Etiam eget tempus tortor. Duis facilisis commodo interdum. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam dui lectus, sodales in ex id, tincidunt pharetra quam.", "Admin test", new DateTime(2024, 4, 19, 11, 58, 54, 199, DateTimeKind.Local).AddTicks(3581), null, null, new Guid("fe3d8ace-339d-40bd-b620-63fc51ce5f59"), false, null, null, "ASP.NET CORE Deneme Makalesi 1", 15 },
                    { new Guid("f06731fc-5784-4e63-ad32-7822d5c31be4"), new Guid("bfdeca74-b674-49fd-9a3d-be63b8266645"), "Visual Studio orem ipsum dolor sit amet, consectetur adipiscing elit. Ut arcu ante, condimentum non nibh eu, vehicula tristique eros. Praesent metus felis, rhoncus nec neque at, feugiat ultrices ligula. Integer porta, leo et tempor suscipit, mi ligula viverra lectus, nec tristique massa ante ut mi. Etiam eget tempus tortor. Duis facilisis commodo interdum. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam dui lectus, sodales in ex id, tincidunt pharetra quam.", "Admin test", new DateTime(2024, 4, 19, 11, 58, 54, 199, DateTimeKind.Local).AddTicks(3586), null, null, new Guid("12e5602d-bd51-4c8f-b0b0-d78024053735"), false, null, null, "Visual Studio Deneme Makalesi 1", 15 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("c70467bb-bd9e-4910-b56a-9787dcda0082"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("f06731fc-5784-4e63-ad32-7822d5c31be4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("51c55032-6f6a-47d8-833f-144c23fb67a1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bfdeca74-b674-49fd-9a3d-be63b8266645"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("12e5602d-bd51-4c8f-b0b0-d78024053735"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("fe3d8ace-339d-40bd-b620-63fc51ce5f59"));
        }
    }
}
