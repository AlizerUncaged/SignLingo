using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignLingo.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedMoreMetadata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LessonReviewer",
                table: "Lessons",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "LessonDescription", "LessonReviewer", "LessonTitle" },
                values: new object[] { 1L, "# Lesson 1: FSL Greetings\r\n\r\nGet ready to dive into the exciting world of Filipino Sign Language (FSL) greetings! 🌟✋ In this cozy lesson, you'll learn how to sign some \r\ndelightful greetings that will make your heart flutter. Whether you're saying hello, bidding farewell, or asking someone how they're doing, \r\nFSL has the perfect signs to express warmth and friendliness. 🤗💬", "", "Greetings!" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DropColumn(
                name: "LessonReviewer",
                table: "Lessons");
        }
    }
}
