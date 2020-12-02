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
                name: "RoleActions",
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
                    RoleId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleActions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
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
                    { 1, null, new DateTime(2020, 12, 2, 9, 35, 43, 203, DateTimeKind.Utc).AddTicks(8692), "system", "Dummy One", false, false, null, null, null, null, new Guid("b4111440-a5f1-45f3-8f7e-286ba32ebaf2") },
                    { 2, null, new DateTime(2020, 12, 2, 9, 35, 43, 203, DateTimeKind.Utc).AddTicks(8791), "system", "Dummy Two", false, false, null, null, null, null, new Guid("8fcdab4f-ea60-491a-bf9a-7a49507992d9") }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Comments", "CreatedDate", "CreatedUser", "IsDestroyed", "IsSystem", "LastDestroyedDate", "LastDestroyedUser", "LastModifiedDate", "LastModifiedUser", "Name", "SystemId" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2020, 12, 2, 9, 35, 43, 203, DateTimeKind.Utc).AddTicks(1126), "system", false, true, null, null, new DateTime(2020, 12, 2, 9, 35, 43, 203, DateTimeKind.Utc).AddTicks(1177), "system", "Administrators", new Guid("10c3e833-2cae-46fb-a07b-ebaf9e314166") },
                    { 2, null, new DateTime(2020, 12, 2, 9, 35, 43, 203, DateTimeKind.Utc).AddTicks(1266), "system", false, true, null, null, new DateTime(2020, 12, 2, 9, 35, 43, 203, DateTimeKind.Utc).AddTicks(1271), "system", "Users", new Guid("70eb6d7c-d229-4be6-a69e-2978119bb5e9") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "City", "Comments", "Country", "CreatedDate", "CreatedUser", "Email", "Fullname", "IsDestroyed", "IsSystem", "LastDestroyedDate", "LastDestroyedUser", "LastModifiedDate", "LastModifiedUser", "Password", "PostalCode", "SystemId", "Username" },
                values: new object[,]
                {
                    { 1, null, null, null, null, new DateTime(2020, 12, 2, 9, 35, 43, 198, DateTimeKind.Utc).AddTicks(8946), "system", "admin@server.com", "System Administrator", false, true, null, null, new DateTime(2020, 12, 2, 9, 35, 43, 199, DateTimeKind.Utc).AddTicks(1726), "system", "pass", null, new Guid("3881761b-f08c-4a8b-821c-61fbab480d7f"), "admin" },
                    { 2, null, null, null, null, new DateTime(2020, 12, 2, 9, 35, 43, 199, DateTimeKind.Utc).AddTicks(5027), "system", "user@server.com", "Just an User", false, false, null, null, new DateTime(2020, 12, 2, 9, 35, 43, 199, DateTimeKind.Utc).AddTicks(5044), "system", "pass", null, new Guid("6e7cc687-c636-4c36-9c52-7e60d6cc2683"), "user" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "Comments", "CreatedDate", "CreatedUser", "IsDestroyed", "IsSystem", "LastDestroyedDate", "LastDestroyedUser", "LastModifiedDate", "LastModifiedUser", "RoleId", "SystemId", "UserId" },
                values: new object[] { 1, null, new DateTime(2020, 12, 2, 9, 35, 43, 203, DateTimeKind.Utc).AddTicks(5453), "system", false, true, null, null, new DateTime(2020, 12, 2, 9, 35, 43, 203, DateTimeKind.Utc).AddTicks(5474), "system", 1, new Guid("d05994ec-9304-4e14-bf7e-3c9fd64a0dc2"), 1 });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "Comments", "CreatedDate", "CreatedUser", "IsDestroyed", "IsSystem", "LastDestroyedDate", "LastDestroyedUser", "LastModifiedDate", "LastModifiedUser", "RoleId", "SystemId", "UserId" },
                values: new object[] { 2, null, new DateTime(2020, 12, 2, 9, 35, 43, 203, DateTimeKind.Utc).AddTicks(5599), "system", false, true, null, null, new DateTime(2020, 12, 2, 9, 35, 43, 203, DateTimeKind.Utc).AddTicks(5604), "system", 2, new Guid("e04fcf04-5ec8-4c2c-8931-1eb1d2b550b0"), 1 });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "Comments", "CreatedDate", "CreatedUser", "IsDestroyed", "IsSystem", "LastDestroyedDate", "LastDestroyedUser", "LastModifiedDate", "LastModifiedUser", "RoleId", "SystemId", "UserId" },
                values: new object[] { 3, null, new DateTime(2020, 12, 2, 9, 35, 43, 203, DateTimeKind.Utc).AddTicks(5651), "system", false, true, null, null, new DateTime(2020, 12, 2, 9, 35, 43, 203, DateTimeKind.Utc).AddTicks(5654), "system", 2, new Guid("220687cc-a26e-4977-bd5e-ce87f4dda93f"), 2 });

            migrationBuilder.CreateIndex(
                name: "IX_RoleActions_RoleId",
                table: "RoleActions",
                column: "RoleId");

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
                name: "RoleActions");

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
