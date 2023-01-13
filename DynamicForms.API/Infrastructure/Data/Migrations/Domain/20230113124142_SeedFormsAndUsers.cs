using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations.Domain
{
    public partial class SeedFormsAndUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "domain",
                table: "DomainUsers",
                columns: new[] { "Id", "Email", "IsDeleted", "UserAuthId", "UserName" },
                values: new object[] { new Guid("3c177013-3086-4f27-b700-bf02c1f327dc"), "seed1.df@gmail.com", false, new Guid("4c177013-3086-4f27-b700-bf02c1f327dc"), "seed1.df@gmail.com" });

            migrationBuilder.InsertData(
                schema: "domain",
                table: "DomainUsers",
                columns: new[] { "Id", "Email", "IsDeleted", "UserAuthId", "UserName" },
                values: new object[] { new Guid("e4eb0b1c-3cda-4548-a5bf-7dcc79cf9a4c"), "seed2.df@gmail.com", false, new Guid("44eb0b1c-3cda-4548-a5bf-7dcc79cf9a4c"), "seed2.df@gmail.com" });

            migrationBuilder.InsertData(
                schema: "domain",
                table: "DomainUsers",
                columns: new[] { "Id", "Email", "IsDeleted", "UserAuthId", "UserName" },
                values: new object[] { new Guid("f07f9516-94bd-4251-8756-822a582e7df6"), "seed3.df@gmail.com", false, new Guid("407f9516-94bd-4251-8756-822a582e7df6"), "seed3.df@gmail.com" });

            migrationBuilder.InsertData(
                schema: "domain",
                table: "Forms",
                columns: new[] { "Id", "CreatorId", "DateCreated", "IsDeleted", "Name", "Visibility" },
                values: new object[,]
                {
                    { new Guid("0c087839-80fd-4511-a356-511d749d783b"), new Guid("e4eb0b1c-3cda-4548-a5bf-7dcc79cf9a4c"), new DateTimeOffset(new DateTime(2023, 1, 13, 15, 41, 42, 495, DateTimeKind.Unspecified).AddTicks(864), new TimeSpan(0, 3, 0, 0, 0)), false, "Seed seed2.df Form1", 1 },
                    { new Guid("12147df3-0241-419a-8985-53f9ceb2aecd"), new Guid("3c177013-3086-4f27-b700-bf02c1f327dc"), new DateTimeOffset(new DateTime(2023, 1, 13, 15, 41, 42, 495, DateTimeKind.Unspecified).AddTicks(855), new TimeSpan(0, 3, 0, 0, 0)), false, "Seed seed1.df Form3", 0 },
                    { new Guid("57310ddc-32d8-4b37-9024-289206aa23ed"), new Guid("f07f9516-94bd-4251-8756-822a582e7df6"), new DateTimeOffset(new DateTime(2023, 1, 13, 15, 41, 42, 495, DateTimeKind.Unspecified).AddTicks(877), new TimeSpan(0, 3, 0, 0, 0)), false, "Seed seed3.df Form1", 1 },
                    { new Guid("778ec6b7-14f0-4e15-8488-c241155c8289"), new Guid("3c177013-3086-4f27-b700-bf02c1f327dc"), new DateTimeOffset(new DateTime(2023, 1, 13, 15, 41, 42, 495, DateTimeKind.Unspecified).AddTicks(787), new TimeSpan(0, 3, 0, 0, 0)), false, "Seed seed1.df Form1", 0 },
                    { new Guid("79944443-890f-4acf-a541-faf2e5c8ee98"), new Guid("f07f9516-94bd-4251-8756-822a582e7df6"), new DateTimeOffset(new DateTime(2023, 1, 13, 15, 41, 42, 495, DateTimeKind.Unspecified).AddTicks(899), new TimeSpan(0, 3, 0, 0, 0)), false, "Seed seed3.df Form1", 0 },
                    { new Guid("849244b4-c480-4d25-a831-4df7b6e138ef"), new Guid("3c177013-3086-4f27-b700-bf02c1f327dc"), new DateTimeOffset(new DateTime(2023, 1, 13, 15, 41, 42, 495, DateTimeKind.Unspecified).AddTicks(849), new TimeSpan(0, 3, 0, 0, 0)), false, "Seed seed1.df Form2", 1 },
                    { new Guid("854db5e4-3c90-4c53-8217-3b9327dd968f"), new Guid("f07f9516-94bd-4251-8756-822a582e7df6"), new DateTimeOffset(new DateTime(2023, 1, 13, 15, 41, 42, 495, DateTimeKind.Unspecified).AddTicks(874), new TimeSpan(0, 3, 0, 0, 0)), false, "Seed seed3.df Form1", 0 },
                    { new Guid("87573e3d-061c-485d-9110-3b25dce3d62e"), new Guid("e4eb0b1c-3cda-4548-a5bf-7dcc79cf9a4c"), new DateTimeOffset(new DateTime(2023, 1, 13, 15, 41, 42, 495, DateTimeKind.Unspecified).AddTicks(870), new TimeSpan(0, 3, 0, 0, 0)), false, "Seed seed2.df Form1", 0 },
                    { new Guid("a62b4d3a-ce6d-4284-98a9-ccf05481635d"), new Guid("e4eb0b1c-3cda-4548-a5bf-7dcc79cf9a4c"), new DateTimeOffset(new DateTime(2023, 1, 13, 15, 41, 42, 495, DateTimeKind.Unspecified).AddTicks(859), new TimeSpan(0, 3, 0, 0, 0)), false, "Seed seed2.df Form1", 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "domain",
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("0c087839-80fd-4511-a356-511d749d783b"));

            migrationBuilder.DeleteData(
                schema: "domain",
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("12147df3-0241-419a-8985-53f9ceb2aecd"));

            migrationBuilder.DeleteData(
                schema: "domain",
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("57310ddc-32d8-4b37-9024-289206aa23ed"));

            migrationBuilder.DeleteData(
                schema: "domain",
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("778ec6b7-14f0-4e15-8488-c241155c8289"));

            migrationBuilder.DeleteData(
                schema: "domain",
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("79944443-890f-4acf-a541-faf2e5c8ee98"));

            migrationBuilder.DeleteData(
                schema: "domain",
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("849244b4-c480-4d25-a831-4df7b6e138ef"));

            migrationBuilder.DeleteData(
                schema: "domain",
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("854db5e4-3c90-4c53-8217-3b9327dd968f"));

            migrationBuilder.DeleteData(
                schema: "domain",
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("87573e3d-061c-485d-9110-3b25dce3d62e"));

            migrationBuilder.DeleteData(
                schema: "domain",
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("a62b4d3a-ce6d-4284-98a9-ccf05481635d"));

            migrationBuilder.DeleteData(
                schema: "domain",
                table: "DomainUsers",
                keyColumn: "Id",
                keyValue: new Guid("3c177013-3086-4f27-b700-bf02c1f327dc"));

            migrationBuilder.DeleteData(
                schema: "domain",
                table: "DomainUsers",
                keyColumn: "Id",
                keyValue: new Guid("e4eb0b1c-3cda-4548-a5bf-7dcc79cf9a4c"));

            migrationBuilder.DeleteData(
                schema: "domain",
                table: "DomainUsers",
                keyColumn: "Id",
                keyValue: new Guid("f07f9516-94bd-4251-8756-822a582e7df6"));
        }
    }
}
