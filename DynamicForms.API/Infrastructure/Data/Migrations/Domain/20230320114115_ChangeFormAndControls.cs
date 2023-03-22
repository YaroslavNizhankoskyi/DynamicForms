using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations.Domain
{
    public partial class ChangeFormAndControls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IsMultiple",
                schema: "domain",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "Text",
                schema: "domain",
                table: "Question");

            migrationBuilder.RenameColumn(
                name: "Type",
                schema: "domain",
                table: "Question",
                newName: "SelectType");

            migrationBuilder.AddColumn<Guid>(
                name: "ConfigId",
                schema: "domain",
                table: "Question",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "InputType",
                schema: "domain",
                table: "Question",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateModified",
                schema: "domain",
                table: "Forms",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "domain",
                table: "Forms",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Domain",
                schema: "domain",
                table: "Forms",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                schema: "domain",
                table: "Forms",
                columns: new[] { "Id", "CreatorId", "DateCreated", "DateModified", "Description", "Domain", "IsDeleted", "Name", "Visibility" },
                values: new object[,]
                {
                    { new Guid("4301d900-cd0b-4b17-b166-58b7d7c73c5b"), new Guid("f07f9516-94bd-4251-8756-822a582e7df6"), new DateTimeOffset(new DateTime(2023, 3, 20, 14, 41, 14, 979, DateTimeKind.Unspecified).AddTicks(9061), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 3, 20, 14, 41, 14, 979, DateTimeKind.Unspecified).AddTicks(9062), new TimeSpan(0, 3, 0, 0, 0)), null, "seed", false, "Seed seed3.df Form1", 1 },
                    { new Guid("69501010-eb7f-4e7f-85be-199ba6aaaf63"), new Guid("f07f9516-94bd-4251-8756-822a582e7df6"), new DateTimeOffset(new DateTime(2023, 3, 20, 14, 41, 14, 979, DateTimeKind.Unspecified).AddTicks(9055), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 3, 20, 14, 41, 14, 979, DateTimeKind.Unspecified).AddTicks(9057), new TimeSpan(0, 3, 0, 0, 0)), null, "seed", false, "Seed seed3.df Form1", 0 },
                    { new Guid("6973efcf-4ab5-4af1-a0d2-e7b2b21e5646"), new Guid("f07f9516-94bd-4251-8756-822a582e7df6"), new DateTimeOffset(new DateTime(2023, 3, 20, 14, 41, 14, 979, DateTimeKind.Unspecified).AddTicks(9065), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 3, 20, 14, 41, 14, 979, DateTimeKind.Unspecified).AddTicks(9067), new TimeSpan(0, 3, 0, 0, 0)), null, "seed", false, "Seed seed3.df Form1", 0 },
                    { new Guid("75c77e51-148d-414d-9100-f5e095439405"), new Guid("e4eb0b1c-3cda-4548-a5bf-7dcc79cf9a4c"), new DateTimeOffset(new DateTime(2023, 3, 20, 14, 41, 14, 979, DateTimeKind.Unspecified).AddTicks(8989), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 3, 20, 14, 41, 14, 979, DateTimeKind.Unspecified).AddTicks(8990), new TimeSpan(0, 3, 0, 0, 0)), null, "seed", false, "Seed seed2.df Form1", 1 },
                    { new Guid("99cf0f88-4351-4fec-a652-185bec7b2aad"), new Guid("e4eb0b1c-3cda-4548-a5bf-7dcc79cf9a4c"), new DateTimeOffset(new DateTime(2023, 3, 20, 14, 41, 14, 979, DateTimeKind.Unspecified).AddTicks(8985), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 3, 20, 14, 41, 14, 979, DateTimeKind.Unspecified).AddTicks(8984), new TimeSpan(0, 3, 0, 0, 0)), null, "seed", false, "Seed seed2.df Form1", 0 },
                    { new Guid("a4c4b2aa-fc71-4e03-bbb8-070a092b6cc2"), new Guid("3c177013-3086-4f27-b700-bf02c1f327dc"), new DateTimeOffset(new DateTime(2023, 3, 20, 14, 41, 14, 979, DateTimeKind.Unspecified).AddTicks(8952), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 3, 20, 14, 41, 14, 979, DateTimeKind.Unspecified).AddTicks(8954), new TimeSpan(0, 3, 0, 0, 0)), null, "seed", false, "Seed seed1.df Form2", 1 },
                    { new Guid("b58c4b9e-fb23-4aab-a533-de333ca937bd"), new Guid("3c177013-3086-4f27-b700-bf02c1f327dc"), new DateTimeOffset(new DateTime(2023, 3, 20, 14, 41, 14, 979, DateTimeKind.Unspecified).AddTicks(8889), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 3, 20, 14, 41, 14, 979, DateTimeKind.Unspecified).AddTicks(8918), new TimeSpan(0, 3, 0, 0, 0)), null, "seed", false, "Seed seed1.df Form1", 0 },
                    { new Guid("c827d496-ade7-42fa-8a89-d5bfda486311"), new Guid("3c177013-3086-4f27-b700-bf02c1f327dc"), new DateTimeOffset(new DateTime(2023, 3, 20, 14, 41, 14, 979, DateTimeKind.Unspecified).AddTicks(8959), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 3, 20, 14, 41, 14, 979, DateTimeKind.Unspecified).AddTicks(8960), new TimeSpan(0, 3, 0, 0, 0)), null, "seed", false, "Seed seed1.df Form3", 0 },
                    { new Guid("e00a859d-1fb4-45ab-b67a-6f557aa97724"), new Guid("e4eb0b1c-3cda-4548-a5bf-7dcc79cf9a4c"), new DateTimeOffset(new DateTime(2023, 3, 20, 14, 41, 14, 979, DateTimeKind.Unspecified).AddTicks(8997), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 3, 20, 14, 41, 14, 979, DateTimeKind.Unspecified).AddTicks(8999), new TimeSpan(0, 3, 0, 0, 0)), null, "seed", false, "Seed seed2.df Form1", 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "domain",
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("4301d900-cd0b-4b17-b166-58b7d7c73c5b"));

            migrationBuilder.DeleteData(
                schema: "domain",
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("69501010-eb7f-4e7f-85be-199ba6aaaf63"));

            migrationBuilder.DeleteData(
                schema: "domain",
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("6973efcf-4ab5-4af1-a0d2-e7b2b21e5646"));

            migrationBuilder.DeleteData(
                schema: "domain",
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("75c77e51-148d-414d-9100-f5e095439405"));

            migrationBuilder.DeleteData(
                schema: "domain",
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("99cf0f88-4351-4fec-a652-185bec7b2aad"));

            migrationBuilder.DeleteData(
                schema: "domain",
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("a4c4b2aa-fc71-4e03-bbb8-070a092b6cc2"));

            migrationBuilder.DeleteData(
                schema: "domain",
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("b58c4b9e-fb23-4aab-a533-de333ca937bd"));

            migrationBuilder.DeleteData(
                schema: "domain",
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("c827d496-ade7-42fa-8a89-d5bfda486311"));

            migrationBuilder.DeleteData(
                schema: "domain",
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("e00a859d-1fb4-45ab-b67a-6f557aa97724"));

            migrationBuilder.DropColumn(
                name: "ConfigId",
                schema: "domain",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "InputType",
                schema: "domain",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "DateModified",
                schema: "domain",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "domain",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "Domain",
                schema: "domain",
                table: "Forms");

            migrationBuilder.RenameColumn(
                name: "SelectType",
                schema: "domain",
                table: "Question",
                newName: "Type");

            migrationBuilder.AddColumn<bool>(
                name: "IsMultiple",
                schema: "domain",
                table: "Question",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                schema: "domain",
                table: "Question",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

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
    }
}
