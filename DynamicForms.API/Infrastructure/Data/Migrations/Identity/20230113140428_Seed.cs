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
                values: new object[] { new Guid("407f9516-94bd-4251-8756-822a582e7df6"), 0, "e0738ccb-6721-49e6-b2a9-f2f58eec097f", "seed3.df@gmail.com", false, false, null, "SEED3.DF@GMAIL.COM", "SEED3.DF@GMAIL.COM", "AQAAAAEAACcQAAAAEL8XKOs2WjuwN7zlj8H2twGwwZjjMvmkZIHvkCgjgJt9ZolUUTIsgGItPsGjcrvC0w==", null, false, "0ee6e47e-bf3f-4633-8108-1ec958a67315", false, "seed3.df@gmail.com" });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("44eb0b1c-3cda-4548-a5bf-7dcc79cf9a4c"), 0, "b9b19f31-2da3-4205-850c-0c37666a3c17", "seed2.df@gmail.com", false, false, null, "SEED2.DF@GMAIL.COM", "SEED2.DF@GMAIL.COM", "AQAAAAEAACcQAAAAECqBggVIFMON+LeUVv0uSB/Bx5mLtodMeY9uTfF7U1I6OhjbjgMokscgjf3yqQrfsw==", null, false, "6b915cac-d7a7-4d79-8ec5-6c59f9eee11d", false, "seed2.df@gmail.com" });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("4c177013-3086-4f27-b700-bf02c1f327dc"), 0, "9cc502ec-d4b7-422c-84a4-cad5557462b2", "seed1.df@gmail.com", false, false, null, "SEED1.DF@GMAIL.COM", "SEED1.DF@GMAIL.COM", "AQAAAAEAACcQAAAAEFkXxeDedDvEAopQkqHy1dQPUozlZuprB9fCUCEn7Z46tocKz1gtelgt7jlWTnN7tA==", null, false, "a49afc19-8448-42e7-8290-2a3daf456247", false, "seed1.df@gmail.com" });
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
