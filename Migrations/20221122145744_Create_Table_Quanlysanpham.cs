using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLNhom3.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableQuanlysanpham : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quanlysanpham",
                columns: table => new
                {
                    Masanpham = table.Column<string>(type: "TEXT", nullable: false),
                    Tensanpham = table.Column<string>(type: "TEXT", nullable: true),
                    size = table.Column<int>(type: "INTEGER", nullable: false),
                    soluong = table.Column<int>(type: "INTEGER", nullable: false),
                    mausac = table.Column<string>(type: "TEXT", nullable: true),
                    giatien = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quanlysanpham", x => x.Masanpham);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quanlysanpham");
        }
    }
}
