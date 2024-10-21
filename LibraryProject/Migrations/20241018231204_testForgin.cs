using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryProject.Migrations
{
    /// <inheritdoc />
    public partial class testForgin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Borrowings");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Borrowings",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Borrowings_ApplicationUserId",
                table: "Borrowings",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Borrowings_AspNetUsers_ApplicationUserId",
                table: "Borrowings",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrowings_AspNetUsers_ApplicationUserId",
                table: "Borrowings");

            migrationBuilder.DropIndex(
                name: "IX_Borrowings_ApplicationUserId",
                table: "Borrowings");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Borrowings");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Borrowings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
