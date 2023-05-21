using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignLingo.Migrations
{
    /// <inheritdoc />
    public partial class UserMetadata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserMetadataId",
                table: "Lessons",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserMetadatas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMetadatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMetadatas_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 1L,
                column: "UserMetadataId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_UserMetadataId",
                table: "Lessons",
                column: "UserMetadataId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMetadatas_UserId",
                table: "UserMetadatas",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_UserMetadatas_UserMetadataId",
                table: "Lessons",
                column: "UserMetadataId",
                principalTable: "UserMetadatas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_UserMetadatas_UserMetadataId",
                table: "Lessons");

            migrationBuilder.DropTable(
                name: "UserMetadatas");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_UserMetadataId",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "UserMetadataId",
                table: "Lessons");
        }
    }
}
