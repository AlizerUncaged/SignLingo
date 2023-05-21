using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignLingo.Migrations
{
    /// <inheritdoc />
    public partial class SeedUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 1L,
                column: "LessonDescription",
                value: "");

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "LessonDescription", "LessonImage", "LessonReviewer", "LessonTitle", "UserMetadataId" },
                values: new object[] { 2L, "", "https://cdn.dribbble.com/users/648922/screenshots/15895262/media/dcd459092738c1ce081fa6948bdf0ff1.png", "", "FSL Numbers", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 1L,
                column: "LessonDescription",
                value: "# Lesson 1: FSL Greetings\r\n\r\nGet ready to dive into the exciting world of Filipino Sign Language (FSL) greetings! 🌟✋ In this cozy lesson, you'll learn how to sign some \r\ndelightful greetings that will make your heart flutter. Whether you're saying hello, bidding farewell, or asking someone how they're doing, \r\nFSL has the perfect signs to express warmth and friendliness. 🤗💬");
        }
    }
}
