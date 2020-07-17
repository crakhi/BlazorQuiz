using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorQuiz.Server.Data.Migrations
{
    public partial class AddedQuestionandOptionEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Quiz");

            migrationBuilder.CreateTable(
                name: "Questions",
                schema: "Quiz",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionContent = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AreaTags",
                schema: "Quiz",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    QuestionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AreaTags_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "Quiz",
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExamTags",
                schema: "Quiz",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    QuestionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamTags_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "Quiz",
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LanguageTags",
                schema: "Quiz",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    QuestionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LanguageTags_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "Quiz",
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                schema: "Quiz",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionContent = table.Column<string>(nullable: true),
                    IsAnswer = table.Column<bool>(nullable: false),
                    QuestionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Options_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "Quiz",
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AreaTags_QuestionId",
                schema: "Quiz",
                table: "AreaTags",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamTags_QuestionId",
                schema: "Quiz",
                table: "ExamTags",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageTags_QuestionId",
                schema: "Quiz",
                table: "LanguageTags",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Options_QuestionId",
                schema: "Quiz",
                table: "Options",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AreaTags",
                schema: "Quiz");

            migrationBuilder.DropTable(
                name: "ExamTags",
                schema: "Quiz");

            migrationBuilder.DropTable(
                name: "LanguageTags",
                schema: "Quiz");

            migrationBuilder.DropTable(
                name: "Options",
                schema: "Quiz");

            migrationBuilder.DropTable(
                name: "Questions",
                schema: "Quiz");
        }
    }
}
