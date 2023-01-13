using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations.Identity
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "auth",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("407f9516-94bd-4251-8756-822a582e7df6"), 0, "57e94da1-045a-4c10-ad67-825139a53f35", "seed3.df@gmail.com", false, false, null, null, null, null, null, false, null, false, "seed3.df@gmail.com" });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("44eb0b1c-3cda-4548-a5bf-7dcc79cf9a4c"), 0, "4ca1b4f3-0972-4535-b72a-52ac43974986", "seed2.df@gmail.com", false, false, null, null, null, null, null, false, null, false, "seed2.df@gmail.com" });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("4c177013-3086-4f27-b700-bf02c1f327dc"), 0, "543d76b4-513a-4ca1-86cd-86c1ca87bc43", "seed1.df@gmail.com", false, false, null, null, null, null, null, false, null, false, "seed1.df@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "auth",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("407f9516-94bd-4251-8756-822a582e7df6"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("44eb0b1c-3cda-4548-a5bf-7dcc79cf9a4c"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4c177013-3086-4f27-b700-bf02c1f327dc"));
        }
    }
}
