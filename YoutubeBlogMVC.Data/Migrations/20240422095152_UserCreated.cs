using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YoutubeBlogMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("01b9b6c7-d131-422e-8094-4e460d306a0e"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("fdccb7d4-c16a-4e1e-8830-01efdfb017b1"));

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("19d54016-d492-4aee-816b-818bea06e658"), new Guid("bfdeca74-b674-49fd-9a3d-be63b8266645"), "Visual Studio orem ipsum dolor sit amet, consectetur adipiscing elit. Ut arcu ante, condimentum non nibh eu, vehicula tristique eros. Praesent metus felis, rhoncus nec neque at, feugiat ultrices ligula. Integer porta, leo et tempor suscipit, mi ligula viverra lectus, nec tristique massa ante ut mi. Etiam eget tempus tortor. Duis facilisis commodo interdum. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam dui lectus, sodales in ex id, tincidunt pharetra quam.", "Admin test", new DateTime(2024, 4, 22, 12, 51, 52, 398, DateTimeKind.Local).AddTicks(7793), null, null, new Guid("12e5602d-bd51-4c8f-b0b0-d78024053735"), false, null, null, "Visual Studio Deneme Makalesi 1", 15 },
                    { new Guid("92f96bea-3fd3-4f97-9a54-31f086d74fe3"), new Guid("51c55032-6f6a-47d8-833f-144c23fb67a1"), "ASP.NET CORE Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut arcu ante, condimentum non nibh eu, vehicula tristique eros. Praesent metus felis, rhoncus nec neque at, feugiat ultrices ligula. Integer porta, leo et tempor suscipit, mi ligula viverra lectus, nec tristique massa ante ut mi. Etiam eget tempus tortor. Duis facilisis commodo interdum. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam dui lectus, sodales in ex id, tincidunt pharetra quam.", "Admin test", new DateTime(2024, 4, 22, 12, 51, 52, 398, DateTimeKind.Local).AddTicks(7786), null, null, new Guid("fe3d8ace-339d-40bd-b620-63fc51ce5f59"), false, null, null, "ASP.NET CORE Deneme Makalesi 1", 15 }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("62a7b0a8-62b4-4a0c-9a19-46c7a27929f6"), "805a03f2-15a6-46ad-8829-eee99cb9039d", "User", "USER" },
                    { new Guid("b38a0c76-1f24-45ef-912f-33b2e6671236"), "718a869f-8fa0-444d-9a95-7b52e084f7a5", "SuperAdmin", "SUPERADMIN" },
                    { new Guid("b719a268-4272-452c-987a-95b7a1d1f127"), "98d6bd4c-e007-427d-ab69-216fd5c8a7b1", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("1da06e8d-3507-4fbc-b49f-3408ac12deb2"), 0, "19bb97b2-742f-4755-bd2a-a295afe6cf48", "user@gmail.com", true, "Kerim", "Demir", false, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "AQAAAAIAAYagAAAAEDLRZd46JSyD78uzrQpFNYlhnzQTMDheoNNW4yNEvTV8FnV/2YLzvRSOSnM23l+vYg==", "+905349999999", true, "ebe67c88-aa1f-4d46-a9be-bac7aa00537e", false, "user@gmail.com" },
                    { new Guid("3d75895a-13af-4e93-8091-6cd22c173f83"), 0, "bfda98e6-785d-4102-8bc9-000427d6138a", "admin@gmail.com", true, "Mehmet", "Aslan", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEO+R2vqgk/x+KB3UPZB95RbQvwCtO1b73E5Y6v0eLgV8UqY/M/QZ2vNevKT6qF6MdQ==", "+905419999999", true, "140eab8e-7e94-4620-8cea-747f9efc3646", false, "admin@gmail.com" },
                    { new Guid("ab5ceb8f-9dc0-424a-a1c9-495bca357321"), 0, "d78e0417-fdb1-494e-991b-bb7c78bc39a2", "superadmin@gmail.com", true, "Osman", "Topuz", false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEHNdflbUSaGbLtcTYph/IPnysYrosi6A6mZHzs3hzMAdVRn46fzIKQmIRnkK0bdmKA==", "+905349999999", true, "7671baed-7177-4971-9af8-08258934a76e", false, "superadmin@gmail.com" }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("51c55032-6f6a-47d8-833f-144c23fb67a1"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 22, 12, 51, 52, 398, DateTimeKind.Local).AddTicks(9513));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bfdeca74-b674-49fd-9a3d-be63b8266645"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 22, 12, 51, 52, 398, DateTimeKind.Local).AddTicks(9518));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("12e5602d-bd51-4c8f-b0b0-d78024053735"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 22, 12, 51, 52, 399, DateTimeKind.Local).AddTicks(872));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("fe3d8ace-339d-40bd-b620-63fc51ce5f59"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 22, 12, 51, 52, 399, DateTimeKind.Local).AddTicks(869));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("62a7b0a8-62b4-4a0c-9a19-46c7a27929f6"), new Guid("1da06e8d-3507-4fbc-b49f-3408ac12deb2") },
                    { new Guid("b719a268-4272-452c-987a-95b7a1d1f127"), new Guid("3d75895a-13af-4e93-8091-6cd22c173f83") },
                    { new Guid("b38a0c76-1f24-45ef-912f-33b2e6671236"), new Guid("ab5ceb8f-9dc0-424a-a1c9-495bca357321") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("19d54016-d492-4aee-816b-818bea06e658"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("92f96bea-3fd3-4f97-9a54-31f086d74fe3"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("01b9b6c7-d131-422e-8094-4e460d306a0e"), new Guid("51c55032-6f6a-47d8-833f-144c23fb67a1"), "ASP.NET CORE Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut arcu ante, condimentum non nibh eu, vehicula tristique eros. Praesent metus felis, rhoncus nec neque at, feugiat ultrices ligula. Integer porta, leo et tempor suscipit, mi ligula viverra lectus, nec tristique massa ante ut mi. Etiam eget tempus tortor. Duis facilisis commodo interdum. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam dui lectus, sodales in ex id, tincidunt pharetra quam.", "Admin test", new DateTime(2024, 4, 19, 15, 37, 0, 136, DateTimeKind.Local).AddTicks(7731), null, null, new Guid("fe3d8ace-339d-40bd-b620-63fc51ce5f59"), false, null, null, "ASP.NET CORE Deneme Makalesi 1", 15 },
                    { new Guid("fdccb7d4-c16a-4e1e-8830-01efdfb017b1"), new Guid("bfdeca74-b674-49fd-9a3d-be63b8266645"), "Visual Studio orem ipsum dolor sit amet, consectetur adipiscing elit. Ut arcu ante, condimentum non nibh eu, vehicula tristique eros. Praesent metus felis, rhoncus nec neque at, feugiat ultrices ligula. Integer porta, leo et tempor suscipit, mi ligula viverra lectus, nec tristique massa ante ut mi. Etiam eget tempus tortor. Duis facilisis commodo interdum. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam dui lectus, sodales in ex id, tincidunt pharetra quam.", "Admin test", new DateTime(2024, 4, 19, 15, 37, 0, 136, DateTimeKind.Local).AddTicks(7737), null, null, new Guid("12e5602d-bd51-4c8f-b0b0-d78024053735"), false, null, null, "Visual Studio Deneme Makalesi 1", 15 }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("51c55032-6f6a-47d8-833f-144c23fb67a1"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 19, 15, 37, 0, 136, DateTimeKind.Local).AddTicks(9648));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bfdeca74-b674-49fd-9a3d-be63b8266645"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 19, 15, 37, 0, 136, DateTimeKind.Local).AddTicks(9652));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("12e5602d-bd51-4c8f-b0b0-d78024053735"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 19, 15, 37, 0, 137, DateTimeKind.Local).AddTicks(1051));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("fe3d8ace-339d-40bd-b620-63fc51ce5f59"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 19, 15, 37, 0, 137, DateTimeKind.Local).AddTicks(1046));
        }
    }
}
