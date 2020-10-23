using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Programatica.AspNetCore31AppSkeleton.Data.Migrations.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Audit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemId = table.Column<Guid>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedUser = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    LastModifiedUser = table.Column<string>(nullable: true),
                    LastDestroyedDate = table.Column<DateTime>(nullable: true),
                    LastDestroyedUser = table.Column<string>(nullable: true),
                    IsSystem = table.Column<bool>(nullable: false),
                    IsDestroyed = table.Column<bool>(nullable: false),
                    ContentSystemId = table.Column<Guid>(nullable: false),
                    ContentId = table.Column<int>(nullable: false),
                    ContentType = table.Column<string>(nullable: true),
                    ContentFunction = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dummies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemId = table.Column<Guid>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedUser = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    LastModifiedUser = table.Column<string>(nullable: true),
                    LastDestroyedDate = table.Column<DateTime>(nullable: true),
                    LastDestroyedUser = table.Column<string>(nullable: true),
                    IsSystem = table.Column<bool>(nullable: false),
                    IsDestroyed = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dummies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemId = table.Column<Guid>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedUser = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    LastModifiedUser = table.Column<string>(nullable: true),
                    LastDestroyedDate = table.Column<DateTime>(nullable: true),
                    LastDestroyedUser = table.Column<string>(nullable: true),
                    IsSystem = table.Column<bool>(nullable: false),
                    IsDestroyed = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemId = table.Column<Guid>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedUser = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    LastModifiedUser = table.Column<string>(nullable: true),
                    LastDestroyedDate = table.Column<DateTime>(nullable: true),
                    LastDestroyedUser = table.Column<string>(nullable: true),
                    IsSystem = table.Column<bool>(nullable: false),
                    IsDestroyed = table.Column<bool>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Fullname = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrackChanges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemId = table.Column<Guid>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedUser = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    LastModifiedUser = table.Column<string>(nullable: true),
                    LastDestroyedDate = table.Column<DateTime>(nullable: true),
                    LastDestroyedUser = table.Column<string>(nullable: true),
                    IsSystem = table.Column<bool>(nullable: false),
                    IsDestroyed = table.Column<bool>(nullable: false),
                    AuditId = table.Column<int>(nullable: false),
                    FieldName = table.Column<string>(nullable: true),
                    OldValue = table.Column<string>(nullable: true),
                    NewValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrackChanges_Audit_AuditId",
                        column: x => x.AuditId,
                        principalTable: "Audit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemId = table.Column<Guid>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedUser = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    LastModifiedUser = table.Column<string>(nullable: true),
                    LastDestroyedDate = table.Column<DateTime>(nullable: true),
                    LastDestroyedUser = table.Column<string>(nullable: true),
                    IsSystem = table.Column<bool>(nullable: false),
                    IsDestroyed = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Dummies",
                columns: new[] { "Id", "Comments", "CreatedDate", "CreatedUser", "Description", "IsDestroyed", "IsSystem", "LastDestroyedDate", "LastDestroyedUser", "LastModifiedDate", "LastModifiedUser", "SystemId" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2020, 10, 23, 18, 52, 22, 67, DateTimeKind.Utc).AddTicks(9175), "system", "Dummy One", false, false, null, null, null, null, new Guid("9b1d2103-15a5-439d-9951-7b535503033a") },
                    { 2, null, new DateTime(2020, 10, 23, 18, 52, 22, 67, DateTimeKind.Utc).AddTicks(9279), "system", "Dummy Two", false, false, null, null, null, null, new Guid("fab62bdf-b7f6-445e-b594-880dd21bd7ae") }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Comments", "CreatedDate", "CreatedUser", "IsDestroyed", "IsSystem", "LastDestroyedDate", "LastDestroyedUser", "LastModifiedDate", "LastModifiedUser", "Name", "SystemId" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2020, 10, 23, 18, 52, 22, 67, DateTimeKind.Utc).AddTicks(452), "system", false, true, null, null, new DateTime(2020, 10, 23, 18, 52, 22, 67, DateTimeKind.Utc).AddTicks(513), "system", "Administrators", new Guid("e67e981a-1a4a-4f74-b2b7-37cf1435903c") },
                    { 2, null, new DateTime(2020, 10, 23, 18, 52, 22, 67, DateTimeKind.Utc).AddTicks(609), "system", false, true, null, null, new DateTime(2020, 10, 23, 18, 52, 22, 67, DateTimeKind.Utc).AddTicks(613), "system", "Users", new Guid("58cf4e21-bfb2-4c11-b4b6-2246a2579bda") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "City", "Comments", "Country", "CreatedDate", "CreatedUser", "Email", "Fullname", "IsDestroyed", "IsSystem", "LastDestroyedDate", "LastDestroyedUser", "LastModifiedDate", "LastModifiedUser", "Password", "PostalCode", "SystemId", "Username" },
                values: new object[,]
                {
                    { 1, null, null, null, null, new DateTime(2020, 10, 23, 18, 52, 22, 62, DateTimeKind.Utc).AddTicks(3901), "system", "admin@server.com", "System Administrator", false, true, null, null, new DateTime(2020, 10, 23, 18, 52, 22, 62, DateTimeKind.Utc).AddTicks(6888), "system", "pass", null, new Guid("33c46243-cef2-4126-9364-bce89f5ad46e"), "admin" },
                    { 2, null, null, null, null, new DateTime(2020, 10, 23, 18, 52, 22, 63, DateTimeKind.Utc).AddTicks(549), "system", "user@server.com", "Just an User", false, false, null, null, new DateTime(2020, 10, 23, 18, 52, 22, 63, DateTimeKind.Utc).AddTicks(566), "system", "pass", null, new Guid("eb1cf9fe-7a11-4c3b-bcf3-aea230055f34"), "user" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "Comments", "CreatedDate", "CreatedUser", "IsDestroyed", "IsSystem", "LastDestroyedDate", "LastDestroyedUser", "LastModifiedDate", "LastModifiedUser", "RoleId", "SystemId", "UserId" },
                values: new object[] { 1, null, new DateTime(2020, 10, 23, 18, 52, 22, 67, DateTimeKind.Utc).AddTicks(5518), "system", false, true, null, null, new DateTime(2020, 10, 23, 18, 52, 22, 67, DateTimeKind.Utc).AddTicks(5539), "system", 1, new Guid("bb5ff4c3-de6d-405d-9edb-b54f08b66664"), 1 });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "Comments", "CreatedDate", "CreatedUser", "IsDestroyed", "IsSystem", "LastDestroyedDate", "LastDestroyedUser", "LastModifiedDate", "LastModifiedUser", "RoleId", "SystemId", "UserId" },
                values: new object[] { 2, null, new DateTime(2020, 10, 23, 18, 52, 22, 67, DateTimeKind.Utc).AddTicks(5676), "system", false, true, null, null, new DateTime(2020, 10, 23, 18, 52, 22, 67, DateTimeKind.Utc).AddTicks(5680), "system", 2, new Guid("73d85165-c40f-4a49-b874-47723e36c9d1"), 1 });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "Comments", "CreatedDate", "CreatedUser", "IsDestroyed", "IsSystem", "LastDestroyedDate", "LastDestroyedUser", "LastModifiedDate", "LastModifiedUser", "RoleId", "SystemId", "UserId" },
                values: new object[] { 3, null, new DateTime(2020, 10, 23, 18, 52, 22, 67, DateTimeKind.Utc).AddTicks(5732), "system", false, true, null, null, new DateTime(2020, 10, 23, 18, 52, 22, 67, DateTimeKind.Utc).AddTicks(5737), "system", 2, new Guid("744862fc-3d59-4e87-99e2-33494fb21c16"), 2 });

            migrationBuilder.CreateIndex(
                name: "IX_TrackChanges_AuditId",
                table: "TrackChanges",
                column: "AuditId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dummies");

            migrationBuilder.DropTable(
                name: "TrackChanges");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Audit");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
