using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace QuizPlatform_API.Migrations
{
    /// <inheritdoc />
    public partial class TabelleQuizQuestions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "quiz_questions",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    question = table.Column<string>(type: "character varying", nullable: false),
                    answer_true = table.Column<string>(type: "character varying", nullable: false),
                    answer_false_one = table.Column<string>(type: "character varying", nullable: false),
                    answer_false_two = table.Column<string>(type: "character varying", nullable: false),
                    answer_false_three = table.Column<string>(type: "character varying", nullable: false),
                    quiz_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("QuizQuestion_pkey", x => x.id);
                    table.ForeignKey(
                        name: "quiz_question_quiz_fkey",
                        column: x => x.quiz_id,
                        principalTable: "quiz",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_quiz_questions_quiz_id",
                table: "quiz_questions",
                column: "quiz_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "quiz_questions");
        }
    }
}
