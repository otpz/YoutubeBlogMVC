using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YoutubeBlogMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class Visitor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("1e6af603-478a-47b6-87e2-de9a5c9b1fe9"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("f7e6a36b-c41b-4373-bc58-870e2b0c1595"));

            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleVisitors",
                columns: table => new
                {
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleVisitors", x => new { x.ArticleId, x.VisitorId });
                    table.ForeignKey(
                        name: "FK_ArticleVisitors_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleVisitors_Visitors_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "Visitors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("2f725895-3d2f-41aa-a548-a45e2d42d46a"), new Guid("51c55032-6f6a-47d8-833f-144c23fb67a1"), "ASP.NET CORE Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut arcu ante, condimentum non nibh eu, vehicula tristique eros. Praesent metus felis, rhoncus nec neque at, feugiat ultrices ligula. Integer porta, leo et tempor suscipit, mi ligula viverra lectus, nec tristique massa ante ut mi. Etiam eget tempus tortor. Duis facilisis commodo interdum. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam dui lectus, sodales in ex id, tincidunt pharetra quam.", "Admin test", new DateTime(2024, 5, 5, 17, 55, 25, 527, DateTimeKind.Local).AddTicks(1574), null, null, new Guid("fe3d8ace-339d-40bd-b620-63fc51ce5f59"), false, null, null, "ASP.NET CORE Deneme Makalesi 1", new Guid("ab5ceb8f-9dc0-424a-a1c9-495bca357321"), 15 },
                    { new Guid("47b744ff-1a2e-4882-b051-fb6ae2f24c0e"), new Guid("bfdeca74-b674-49fd-9a3d-be63b8266645"), "Visual Studio orem ipsum dolor sit amet, consectetur adipiscing elit. Ut arcu ante, condimentum non nibh eu, vehicula tristique eros. Praesent metus felis, rhoncus nec neque at, feugiat ultrices ligula. Integer porta, leo et tempor suscipit, mi ligula viverra lectus, nec tristique massa ante ut mi. Etiam eget tempus tortor. Duis facilisis commodo interdum. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam dui lectus, sodales in ex id, tincidunt pharetra quam.", "Admin test", new DateTime(2024, 5, 5, 17, 55, 25, 527, DateTimeKind.Local).AddTicks(1594), null, null, new Guid("12e5602d-bd51-4c8f-b0b0-d78024053735"), false, null, null, "Visual Studio Deneme Makalesi 1", new Guid("3d75895a-13af-4e93-8091-6cd22c173f83"), 15 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("62a7b0a8-62b4-4a0c-9a19-46c7a27929f6"),
                column: "ConcurrencyStamp",
                value: "8042367b-647e-4b5d-97aa-24799b15f589");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b38a0c76-1f24-45ef-912f-33b2e6671236"),
                column: "ConcurrencyStamp",
                value: "0ff5582c-f93d-4288-a392-3ff380306b8f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b719a268-4272-452c-987a-95b7a1d1f127"),
                column: "ConcurrencyStamp",
                value: "eca04ebb-a6eb-4141-9456-1ac249d2ee49");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1da06e8d-3507-4fbc-b49f-3408ac12deb2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d1da964d-ba63-4b4f-acd7-59a74d50d6eb", "AQAAAAIAAYagAAAAEA0hIX684huQxCH5EDbQeJbuNPeLxuOm0dGjVUFmvdhvMVUfGtqTJ0H9iOWu+zTuwA==", "87e07fe4-987e-4f9f-a133-7d1b0749c465" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3d75895a-13af-4e93-8091-6cd22c173f83"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fc3c5998-00c0-468f-8a19-3c1ed2f7fd06", "AQAAAAIAAYagAAAAEBzMSki6tm6ifXpKHR8xY7XaCXQ3ZhdPVbCVXmGj/PN06Y3tgwy1ETI/mJM1IKfVJA==", "d06094e6-6196-4ce7-889b-db1ea3583dfa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ab5ceb8f-9dc0-424a-a1c9-495bca357321"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e927d1a-60cd-477a-a77b-60835dca9d32", "AQAAAAIAAYagAAAAECxjvczoArTl63BNi5fc9ZbvbobRfyHVH+P14kWOfyVBYDbv3SmKPbbyKbo5A3uUEA==", "b7cf810b-bd22-4859-ac7d-ffa57a0b16ea" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("51c55032-6f6a-47d8-833f-144c23fb67a1"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 5, 17, 55, 25, 527, DateTimeKind.Local).AddTicks(9673));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bfdeca74-b674-49fd-9a3d-be63b8266645"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 5, 17, 55, 25, 527, DateTimeKind.Local).AddTicks(9679));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("12e5602d-bd51-4c8f-b0b0-d78024053735"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 5, 17, 55, 25, 528, DateTimeKind.Local).AddTicks(1490));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("fe3d8ace-339d-40bd-b620-63fc51ce5f59"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 5, 17, 55, 25, 528, DateTimeKind.Local).AddTicks(1483));

            migrationBuilder.CreateIndex(
                name: "IX_ArticleVisitors_VisitorId",
                table: "ArticleVisitors",
                column: "VisitorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleVisitors");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("2f725895-3d2f-41aa-a548-a45e2d42d46a"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("47b744ff-1a2e-4882-b051-fb6ae2f24c0e"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("1e6af603-478a-47b6-87e2-de9a5c9b1fe9"), new Guid("51c55032-6f6a-47d8-833f-144c23fb67a1"), "ASP.NET CORE Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut arcu ante, condimentum non nibh eu, vehicula tristique eros. Praesent metus felis, rhoncus nec neque at, feugiat ultrices ligula. Integer porta, leo et tempor suscipit, mi ligula viverra lectus, nec tristique massa ante ut mi. Etiam eget tempus tortor. Duis facilisis commodo interdum. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam dui lectus, sodales in ex id, tincidunt pharetra quam.", "Admin test", new DateTime(2024, 4, 22, 14, 5, 44, 73, DateTimeKind.Local).AddTicks(9951), null, null, new Guid("fe3d8ace-339d-40bd-b620-63fc51ce5f59"), false, null, null, "ASP.NET CORE Deneme Makalesi 1", new Guid("ab5ceb8f-9dc0-424a-a1c9-495bca357321"), 15 },
                    { new Guid("f7e6a36b-c41b-4373-bc58-870e2b0c1595"), new Guid("bfdeca74-b674-49fd-9a3d-be63b8266645"), "Visual Studio orem ipsum dolor sit amet, consectetur adipiscing elit. Ut arcu ante, condimentum non nibh eu, vehicula tristique eros. Praesent metus felis, rhoncus nec neque at, feugiat ultrices ligula. Integer porta, leo et tempor suscipit, mi ligula viverra lectus, nec tristique massa ante ut mi. Etiam eget tempus tortor. Duis facilisis commodo interdum. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam dui lectus, sodales in ex id, tincidunt pharetra quam.", "Admin test", new DateTime(2024, 4, 22, 14, 5, 44, 73, DateTimeKind.Local).AddTicks(9957), null, null, new Guid("12e5602d-bd51-4c8f-b0b0-d78024053735"), false, null, null, "Visual Studio Deneme Makalesi 1", new Guid("3d75895a-13af-4e93-8091-6cd22c173f83"), 15 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("62a7b0a8-62b4-4a0c-9a19-46c7a27929f6"),
                column: "ConcurrencyStamp",
                value: "9e697f0b-3e54-4451-830f-433db632f7cb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b38a0c76-1f24-45ef-912f-33b2e6671236"),
                column: "ConcurrencyStamp",
                value: "946c66f9-076e-4744-b321-42503f4ace4a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b719a268-4272-452c-987a-95b7a1d1f127"),
                column: "ConcurrencyStamp",
                value: "6a381403-42c2-4a2a-bef8-b48a55bff4e2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1da06e8d-3507-4fbc-b49f-3408ac12deb2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc99e16b-064b-4b18-a107-c7dbf5eeed53", "AQAAAAIAAYagAAAAELbBfUaW2c+nlzW2Mvhym64LB6DQIYs2rfxVvr4a6IMxydJANbVHYKuAukc+JrqLKg==", "b2188c54-df4b-4c68-a214-7b0b563321cd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3d75895a-13af-4e93-8091-6cd22c173f83"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c6c1b50-7f42-4c22-bd95-10c345891105", "AQAAAAIAAYagAAAAEDhJnX0yTLOzVzf/13dwjAvsTfpVmpNSpCpmIJ1Q9Ayc+5OZFuIhACV0FA5CfG+6Ag==", "a2471c88-471a-40eb-abb3-8b83ea4c520d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ab5ceb8f-9dc0-424a-a1c9-495bca357321"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f1c39c6f-2703-4118-98c0-d80d7fc11cfc", "AQAAAAIAAYagAAAAEHzS2t3IMJry24eVU1sx3bv7EOOv9uukew7FcJWwPrUM/xZTeX1YnSBkBizyTpxaEg==", "815e3760-c4d6-4389-b7f0-87b35c3ee5a7" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("51c55032-6f6a-47d8-833f-144c23fb67a1"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 22, 14, 5, 44, 74, DateTimeKind.Local).AddTicks(1340));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bfdeca74-b674-49fd-9a3d-be63b8266645"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 22, 14, 5, 44, 74, DateTimeKind.Local).AddTicks(1344));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("12e5602d-bd51-4c8f-b0b0-d78024053735"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 22, 14, 5, 44, 74, DateTimeKind.Local).AddTicks(2661));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("fe3d8ace-339d-40bd-b620-63fc51ce5f59"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 22, 14, 5, 44, 74, DateTimeKind.Local).AddTicks(2656));
        }
    }
}
