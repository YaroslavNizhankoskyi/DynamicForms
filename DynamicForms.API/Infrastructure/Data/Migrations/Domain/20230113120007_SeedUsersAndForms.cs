using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations.Domain
{
    public partial class SeedUsersAndForms : Migration
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
                    { new Guid("2254932b-6fc8-45b4-82ea-cf7565c3fbe5"), new Guid("f07f9516-94bd-4251-8756-822a582e7df6"), new DateTimeOffset(new DateTime(2023, 1, 13, 15, 0, 7, 265, DateTimeKind.Unspecified).AddTicks(5977), new TimeSpan(0, 3, 0, 0, 0)), false, "Seed seed3.df Form1", 0 },
                    { new Guid("283c6c24-a935-4207-b298-dbcaaa96b99b"), new Guid("3c177013-3086-4f27-b700-bf02c1f327dc"), new DateTimeOffset(new DateTime(2023, 1, 13, 15, 0, 7, 265, DateTimeKind.Unspecified).AddTicks(5939), new TimeSpan(0, 3, 0, 0, 0)), false, "Seed seed1.df Form2", 1 },
                    { new Guid("33b311c4-a113-42d2-a6d4-99370b17dd4b"), new Guid("f07f9516-94bd-4251-8756-822a582e7df6"), new DateTimeOffset(new DateTime(2023, 1, 13, 15, 0, 7, 265, DateTimeKind.Unspecified).AddTicks(6007), new TimeSpan(0, 3, 0, 0, 0)), false, "Seed seed3.df Form1", 0 },
                    { new Guid("8e044c96-30ea-4505-af55-b8bd14b68718"), new Guid("3c177013-3086-4f27-b700-bf02c1f327dc"), new DateTimeOffset(new DateTime(2023, 1, 13, 15, 0, 7, 265, DateTimeKind.Unspecified).AddTicks(5957), new TimeSpan(0, 3, 0, 0, 0)), false, "Seed seed1.df Form3", 0 },
                    { new Guid("9e6215d6-27f5-4502-9f1d-df535e265a65"), new Guid("f07f9516-94bd-4251-8756-822a582e7df6"), new DateTimeOffset(new DateTime(2023, 1, 13, 15, 0, 7, 265, DateTimeKind.Unspecified).AddTicks(5981), new TimeSpan(0, 3, 0, 0, 0)), false, "Seed seed3.df Form1", 1 },
                    { new Guid("c7dd3259-575a-42bb-bf1f-6b4e223541ce"), new Guid("e4eb0b1c-3cda-4548-a5bf-7dcc79cf9a4c"), new DateTimeOffset(new DateTime(2023, 1, 13, 15, 0, 7, 265, DateTimeKind.Unspecified).AddTicks(5965), new TimeSpan(0, 3, 0, 0, 0)), false, "Seed seed2.df Form1", 1 },
                    { new Guid("d1eb82bd-0ee7-476b-8e42-0dc13f7901b4"), new Guid("e4eb0b1c-3cda-4548-a5bf-7dcc79cf9a4c"), new DateTimeOffset(new DateTime(2023, 1, 13, 15, 0, 7, 265, DateTimeKind.Unspecified).AddTicks(5961), new TimeSpan(0, 3, 0, 0, 0)), false, "Seed seed2.df Form1", 0 },
                    { new Guid("e704ffd1-f7e6-457a-893d-249a4f16d9d7"), new Guid("e4eb0b1c-3cda-4548-a5bf-7dcc79cf9a4c"), new DateTimeOffset(new DateTime(2023, 1, 13, 15, 0, 7, 265, DateTimeKind.Unspecified).AddTicks(5973), new TimeSpan(0, 3, 0, 0, 0)), false, "Seed seed2.df Form1", 0 },
                    { new Guid("f58bde8f-1dca-415a-b7b7-51b42b661425"), new Guid("3c177013-3086-4f27-b700-bf02c1f327dc"), new DateTimeOffset(new DateTime(2023, 1, 13, 15, 0, 7, 265, DateTimeKind.Unspecified).AddTicks(5880), new TimeSpan(0, 3, 0, 0, 0)), false, "Seed seed1.df Form1", 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "domain",
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("2254932b-6fc8-45b4-82ea-cf7565c3fbe5"));

            migrationBuilder.DeleteData(
                schema: "domain",
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("283c6c24-a935-4207-b298-dbcaaa96b99b"));

            migrationBuilder.DeleteData(
                schema: "domain",
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("33b311c4-a113-42d2-a6d4-99370b17dd4b"));

            migrationBuilder.DeleteData(
                schema: "domain",
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("8e044c96-30ea-4505-af55-b8bd14b68718"));

            migrationBuilder.DeleteData(
                schema: "domain",
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("9e6215d6-27f5-4502-9f1d-df535e265a65"));

            migrationBuilder.DeleteData(
                schema: "domain",
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("c7dd3259-575a-42bb-bf1f-6b4e223541ce"));

            migrationBuilder.DeleteData(
                schema: "domain",
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("d1eb82bd-0ee7-476b-8e42-0dc13f7901b4"));

            migrationBuilder.DeleteData(
                schema: "domain",
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("e704ffd1-f7e6-457a-893d-249a4f16d9d7"));

            migrationBuilder.DeleteData(
                schema: "domain",
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("f58bde8f-1dca-415a-b7b7-51b42b661425"));

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
