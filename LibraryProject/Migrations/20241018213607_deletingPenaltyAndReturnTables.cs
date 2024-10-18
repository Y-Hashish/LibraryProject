using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryProject.Migrations
{
    /// <inheritdoc />
    public partial class deletingPenaltyAndReturnTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Penalities");

            migrationBuilder.DropTable(
                name: "Returns");

            migrationBuilder.AddColumn<DateTime>(
                name: "ActualReturnDate",
                table: "Borrowings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PenalityAmount",
                table: "Borrowings",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActualReturnDate",
                table: "Borrowings");

            migrationBuilder.DropColumn(
                name: "PenalityAmount",
                table: "Borrowings");

            migrationBuilder.CreateTable(
                name: "Returns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BorrowingId = table.Column<int>(type: "int", nullable: false),
                    ActualReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Returns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Returns_Borrowings_BorrowingId",
                        column: x => x.BorrowingId,
                        principalTable: "Borrowings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Penalities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReturnId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Penalities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Penalities_Returns_ReturnId",
                        column: x => x.ReturnId,
                        principalTable: "Returns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Penalities_ReturnId",
                table: "Penalities",
                column: "ReturnId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Returns_BorrowingId",
                table: "Returns",
                column: "BorrowingId",
                unique: true);
        }
    }
}
