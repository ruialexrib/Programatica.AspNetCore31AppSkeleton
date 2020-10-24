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
                        onDelete: ReferentialAction.Restrict);
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
                    { 1, null, new DateTime(2020, 10, 24, 20, 23, 59, 565, DateTimeKind.Utc).AddTicks(19), "system", "Dummy One", false, false, null, null, null, null, new Guid("a6427530-552e-4c94-b3b2-135783349a1b") },
                    { 2, null, new DateTime(2020, 10, 24, 20, 23, 59, 565, DateTimeKind.Utc).AddTicks(92), "system", "Dummy Two", false, false, null, null, null, null, new Guid("6b84b360-0b0b-42bc-83d7-c8632f995acb") }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Comments", "CreatedDate", "CreatedUser", "IsDestroyed", "IsSystem", "LastDestroyedDate", "LastDestroyedUser", "LastModifiedDate", "LastModifiedUser", "Name", "SystemId" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2020, 10, 24, 20, 23, 59, 564, DateTimeKind.Utc).AddTicks(3989), "system", false, true, null, null, new DateTime(2020, 10, 24, 20, 23, 59, 564, DateTimeKind.Utc).AddTicks(4002), "system", "Administrators", new Guid("b6792038-8051-4baa-85a1-8c4662104746") },
                    { 2, null, new DateTime(2020, 10, 24, 20, 23, 59, 564, DateTimeKind.Utc).AddTicks(4054), "system", false, true, null, null, new DateTime(2020, 10, 24, 20, 23, 59, 564, DateTimeKind.Utc).AddTicks(4056), "system", "Users", new Guid("817536d5-b9d1-4596-9b93-84fd69224c32") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "City", "Comments", "Country", "CreatedDate", "CreatedUser", "Email", "Fullname", "IsDestroyed", "IsSystem", "LastDestroyedDate", "LastDestroyedUser", "LastModifiedDate", "LastModifiedUser", "Password", "PostalCode", "SystemId", "Username" },
                values: new object[,]
                {
                    { 1, null, null, null, null, new DateTime(2020, 10, 24, 20, 23, 59, 561, DateTimeKind.Utc).AddTicks(7128), "system", "admin@server.com", "System Administrator", false, true, null, null, new DateTime(2020, 10, 24, 20, 23, 59, 561, DateTimeKind.Utc).AddTicks(9037), "system", "pass", null, new Guid("7c5b5953-30c2-4438-b53b-edc03607d4f3"), "admin" },
                    { 2, null, null, null, null, new DateTime(2020, 10, 24, 20, 23, 59, 562, DateTimeKind.Utc).AddTicks(1519), "system", "user@server.com", "Just an User", false, false, null, null, new DateTime(2020, 10, 24, 20, 23, 59, 562, DateTimeKind.Utc).AddTicks(1529), "system", "pass", null, new Guid("6b7d97ee-36a5-450d-b71f-1c581abbc230"), "user" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "Comments", "CreatedDate", "CreatedUser", "IsDestroyed", "IsSystem", "LastDestroyedDate", "LastDestroyedUser", "LastModifiedDate", "LastModifiedUser", "RoleId", "SystemId", "UserId" },
                values: new object[] { 1, null, new DateTime(2020, 10, 24, 20, 23, 59, 564, DateTimeKind.Utc).AddTicks(7508), "system", false, true, null, null, new DateTime(2020, 10, 24, 20, 23, 59, 564, DateTimeKind.Utc).AddTicks(7523), "system", 1, new Guid("2eb6046f-d29e-4cb8-b614-14abcacc9b1c"), 1 });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "Comments", "CreatedDate", "CreatedUser", "IsDestroyed", "IsSystem", "LastDestroyedDate", "LastDestroyedUser", "LastModifiedDate", "LastModifiedUser", "RoleId", "SystemId", "UserId" },
                values: new object[] { 2, null, new DateTime(2020, 10, 24, 20, 23, 59, 564, DateTimeKind.Utc).AddTicks(7603), "system", false, true, null, null, new DateTime(2020, 10, 24, 20, 23, 59, 564, DateTimeKind.Utc).AddTicks(7605), "system", 2, new Guid("2ea5761e-d266-4d6c-9ced-bee49f34b85b"), 1 });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "Comments", "CreatedDate", "CreatedUser", "IsDestroyed", "IsSystem", "LastDestroyedDate", "LastDestroyedUser", "LastModifiedDate", "LastModifiedUser", "RoleId", "SystemId", "UserId" },
                values: new object[] { 3, null, new DateTime(2020, 10, 24, 20, 23, 59, 564, DateTimeKind.Utc).AddTicks(7644), "system", false, true, null, null, new DateTime(2020, 10, 24, 20, 23, 59, 564, DateTimeKind.Utc).AddTicks(7646), "system", 2, new Guid("72beb2ac-787d-47f0-ab56-5a157dad90eb"), 2 });

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
