using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLNhom3.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableQuanlyncc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quanlyncc_Quanlysanpham_Masanpham",
                table: "Quanlyncc");

            migrationBuilder.DropIndex(
                name: "IX_Quanlyncc_Masanpham",
                table: "Quanlyncc");

            migrationBuilder.DropColumn(
                name: "Masanpham",
                table: "Quanlyncc");

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    IdUser = table.Column<string>(type: "TEXT", nullable: false),
                    HoTen = table.Column<string>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.IdUser);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.AddColumn<string>(
                name: "Masanpham",
                table: "Quanlyncc",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quanlyncc_Masanpham",
                table: "Quanlyncc",
                column: "Masanpham");

            migrationBuilder.AddForeignKey(
                name: "FK_Quanlyncc_Quanlysanpham_Masanpham",
                table: "Quanlyncc",
                column: "Masanpham",
                principalTable: "Quanlysanpham",
                principalColumn: "Masanpham");
        }
    }
}
