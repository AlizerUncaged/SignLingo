using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignLingo.Migrations
{
    /// <inheritdoc />
    public partial class AddedMoreMetadata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LessonDescription",
                table: "Lessons",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LessonTitle",
                table: "Lessons",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ActivityDescription",
                table: "Activities",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LessonDescription",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "LessonTitle",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "ActivityDescription",
                table: "Activities");
        }
    }
}
