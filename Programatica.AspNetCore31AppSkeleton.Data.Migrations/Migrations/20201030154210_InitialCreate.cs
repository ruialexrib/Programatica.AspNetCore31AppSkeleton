using System;
using Microsoft.EntityFrameworkCore.Metadata;
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
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Dummies",
                columns: new[] { "Id", "Comments", "CreatedDate", "CreatedUser", "Description", "IsDestroyed", "IsSystem", "LastDestroyedDate", "LastDestroyedUser", "LastModifiedDate", "LastModifiedUser", "SystemId" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2020, 10, 30, 15, 42, 9, 219, DateTimeKind.Utc).AddTicks(6111), "system", "Dummy One", false, false, null, null, null, null, new Guid("4a067272-268d-4516-9932-55bc082c4b6b") },
                    { 2, null, new DateTime(2020, 10, 30, 15, 42, 9, 219, DateTimeKind.Utc).AddTicks(6223), "system", "Dummy Two", false, false, null, null, null, null, new Guid("189a4c34-520d-45e8-83d1-34b27c6b2493") }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Comments", "CreatedDate", "CreatedUser", "IsDestroyed", "IsSystem", "LastDestroyedDate", "LastDestroyedUser", "LastModifiedDate", "LastModifiedUser", "Name", "SystemId" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2020, 10, 30, 15, 42, 9, 218, DateTimeKind.Utc).AddTicks(7570), "system", false, true, null, null, new DateTime(2020, 10, 30, 15, 42, 9, 218, DateTimeKind.Utc).AddTicks(7614), "system", "Administrators", new Guid("24daa007-fd94-4c96-be8d-91b2b851b1f1") },
                    { 2, null, new DateTime(2020, 10, 30, 15, 42, 9, 218, DateTimeKind.Utc).AddTicks(7733), "system", false, true, null, null, new DateTime(2020, 10, 30, 15, 42, 9, 218, DateTimeKind.Utc).AddTicks(7739), "system", "Users", new Guid("5cdca36c-ae8b-4a26-8604-b7feb9904c89") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "City", "Comments", "Country", "CreatedDate", "CreatedUser", "Email", "Fullname", "IsDestroyed", "IsSystem", "LastDestroyedDate", "LastDestroyedUser", "LastModifiedDate", "LastModifiedUser", "Password", "PostalCode", "SystemId", "Username" },
                values: new object[,]
                {
                    { 1, null, null, null, null, new DateTime(2020, 10, 30, 15, 42, 9, 214, DateTimeKind.Utc).AddTicks(4131), "system", "admin@server.com", "System Administrator", false, true, null, null, new DateTime(2020, 10, 30, 15, 42, 9, 214, DateTimeKind.Utc).AddTicks(6924), "system", "pass", null, new Guid("93bcdfe9-12d0-4935-bb77-25d9c6b87727"), "admin" },
                    { 2, null, null, null, null, new DateTime(2020, 10, 30, 15, 42, 9, 215, DateTimeKind.Utc).AddTicks(583), "system", "user@server.com", "Just an User", false, false, null, null, new DateTime(2020, 10, 30, 15, 42, 9, 215, DateTimeKind.Utc).AddTicks(596), "system", "pass", null, new Guid("299fd20e-b34b-4a2a-82dd-821319c16458"), "user" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "Comments", "CreatedDate", "CreatedUser", "IsDestroyed", "IsSystem", "LastDestroyedDate", "LastDestroyedUser", "LastModifiedDate", "LastModifiedUser", "RoleId", "SystemId", "UserId" },
                values: new object[] { 1, null, new DateTime(2020, 10, 30, 15, 42, 9, 219, DateTimeKind.Utc).AddTicks(2493), "system", false, true, null, null, new DateTime(2020, 10, 30, 15, 42, 9, 219, DateTimeKind.Utc).AddTicks(2509), "system", 1, new Guid("80154792-1e60-41d8-ba67-ef2cf4ac18c0"), 1 });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "Comments", "CreatedDate", "CreatedUser", "IsDestroyed", "IsSystem", "LastDestroyedDate", "LastDestroyedUser", "LastModifiedDate", "LastModifiedUser", "RoleId", "SystemId", "UserId" },
                values: new object[] { 2, null, new DateTime(2020, 10, 30, 15, 42, 9, 219, DateTimeKind.Utc).AddTicks(2639), "system", false, true, null, null, new DateTime(2020, 10, 30, 15, 42, 9, 219, DateTimeKind.Utc).AddTicks(2643), "system", 2, new Guid("3c10461f-e02c-424c-8bd7-320e9ecbad40"), 1 });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "Comments", "CreatedDate", "CreatedUser", "IsDestroyed", "IsSystem", "LastDestroyedDate", "LastDestroyedUser", "LastModifiedDate", "LastModifiedUser", "RoleId", "SystemId", "UserId" },
                values: new object[] { 3, null, new DateTime(2020, 10, 30, 15, 42, 9, 219, DateTimeKind.Utc).AddTicks(2651), "system", false, true, null, null, new DateTime(2020, 10, 30, 15, 42, 9, 219, DateTimeKind.Utc).AddTicks(2654), "system", 2, new Guid("7ae0fcf9-20ba-445f-9e4d-dcbfe6b5e842"), 2 });

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
