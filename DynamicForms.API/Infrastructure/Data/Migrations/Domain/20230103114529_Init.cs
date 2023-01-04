using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations.Domain
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "domain");

            migrationBuilder.CreateTable(
                name: "DomainUsers",
                schema: "domain",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    UserAuthId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Forms",
                schema: "domain",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Visibility = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Forms_DomainUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "domain",
                        principalTable: "DomainUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FormSubmits",
                schema: "domain",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    FormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateSubmitted = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormSubmits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormSubmits_DomainUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "domain",
                        principalTable: "DomainUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FormSubmits_Forms_FormId",
                        column: x => x.FormId,
                        principalSchema: "domain",
                        principalTable: "Forms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PrivateFormAccessors",
                schema: "domain",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    FormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccessorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateFormAccessors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrivateFormAccessors_DomainUsers_AccessorId",
                        column: x => x.AccessorId,
                        principalSchema: "domain",
                        principalTable: "DomainUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PrivateFormAccessors_Forms_FormId",
                        column: x => x.FormId,
                        principalSchema: "domain",
                        principalTable: "Forms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Question",
                schema: "domain",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    FormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: true),
                    IsMultiple = table.Column<bool>(type: "bit", nullable: true),
                    Options = table.Column<string>(type: "nvarchar(max)", maxLength: 50000, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Question_Forms_FormId",
                        column: x => x.FormId,
                        principalSchema: "domain",
                        principalTable: "Forms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Answer",
                schema: "domain",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    FormSubmitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", maxLength: 50000, nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InputQuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SelectQuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answer_FormSubmits_FormSubmitId",
                        column: x => x.FormSubmitId,
                        principalSchema: "domain",
                        principalTable: "FormSubmits",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Answer_Question_InputQuestionId",
                        column: x => x.InputQuestionId,
                        principalSchema: "domain",
                        principalTable: "Question",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Answer_Question_SelectQuestionId",
                        column: x => x.SelectQuestionId,
                        principalSchema: "domain",
                        principalTable: "Question",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answer_FormSubmitId",
                schema: "domain",
                table: "Answer",
                column: "FormSubmitId");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_InputQuestionId",
                schema: "domain",
                table: "Answer",
                column: "InputQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_SelectQuestionId",
                schema: "domain",
                table: "Answer",
                column: "SelectQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Forms_CreatorId",
                schema: "domain",
                table: "Forms",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_FormSubmits_FormId",
                schema: "domain",
                table: "FormSubmits",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_FormSubmits_UserId",
                schema: "domain",
                table: "FormSubmits",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateFormAccessors_AccessorId",
                schema: "domain",
                table: "PrivateFormAccessors",
                column: "AccessorId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateFormAccessors_FormId",
                schema: "domain",
                table: "PrivateFormAccessors",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_FormId",
                schema: "domain",
                table: "Question",
                column: "FormId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answer",
                schema: "domain");

            migrationBuilder.DropTable(
                name: "PrivateFormAccessors",
                schema: "domain");

            migrationBuilder.DropTable(
                name: "FormSubmits",
                schema: "domain");

            migrationBuilder.DropTable(
                name: "Question",
                schema: "domain");

            migrationBuilder.DropTable(
                name: "Forms",
                schema: "domain");

            migrationBuilder.DropTable(
                name: "DomainUsers",
                schema: "domain");
        }
    }
}
