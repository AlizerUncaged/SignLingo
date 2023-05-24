using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SignLingo.Migrations
{
    /// <inheritdoc />
    public partial class DbUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Item = table.Column<string>(type: "TEXT", nullable: false),
                    LessonId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_LessonId",
                table: "Items",
                column: "LessonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "LessonDescription", "LessonImage", "LessonReviewer", "LessonTitle", "UserMetadataId" },
                values: new object[,]
                {
                    { 1L, "", "https://cdn.dribbble.com/userupload/5212512/file/original-8f810bbb60971a8d674ceb8b0150ccbc.jpg?compress=1&resize=1024x1280", "", "Greetings!", null },
                    { 2L, "", "https://cdn.dribbble.com/users/648922/screenshots/15895262/media/dcd459092738c1ce081fa6948bdf0ff1.png", "", "FSL Numbers", null }
                });
        }
    }
}
