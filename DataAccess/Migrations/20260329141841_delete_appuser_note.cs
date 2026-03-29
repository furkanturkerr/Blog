using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_Access_Layer.Migrations
{
    /// <inheritdoc />
    public partial class delete_appuser_note : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_AspNetUsers_AppUserId1",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_AppUserId1",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "Notes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Notes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId1",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Notes_AppUserId1",
                table: "Notes",
                column: "AppUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_AspNetUsers_AppUserId1",
                table: "Notes",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
