using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace QuizPlatform_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "quiz_category",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying", nullable: false),
                    createdAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("QuizCategory_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    username = table.Column<string>(type: "character varying", nullable: false),
                    password_hash = table.Column<string>(type: "character varying", nullable: false),
                    last_login = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("User_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "quiz",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying", nullable: false),
                    category_id = table.Column<long>(type: "bigint", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("Quiz_pkey", x => x.id);
                    table.ForeignKey(
                        name: "quiz_category_fkey",
                        column: x => x.category_id,
                        principalTable: "quiz_category",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "highscore",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    score = table.Column<int>(type: "integer", nullable: false),
                    number_of_questions = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    quiz_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Highscore_pkey", x => x.id);
                    table.ForeignKey(
                        name: "highscore_quiz_fkey",
                        column: x => x.quiz_id,
                        principalTable: "quiz",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "highscore_user_fkey",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_highscore_quiz_id",
                table: "highscore",
                column: "quiz_id");

            migrationBuilder.CreateIndex(
                name: "IX_highscore_user_id",
                table: "highscore",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_quiz_category_id",
                table: "quiz",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "user_username_key",
                table: "user",
                column: "username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "highscore");

            migrationBuilder.DropTable(
                name: "quiz");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "quiz_category");
        }
    }
}
