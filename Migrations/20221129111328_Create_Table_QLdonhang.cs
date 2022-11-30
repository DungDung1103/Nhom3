using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLNhom3.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableQLdonhang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quanlydonhang",
                columns: table => new
                {
                    Madonhang = table.Column<string>(type: "TEXT", nullable: false),
                    ngaylamnv = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Masanpham = table.Column<string>(type: "TEXT", nullable: true),
                    Makhachhang = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quanlydonhang", x => x.Madonhang);
                    table.ForeignKey(
                        name: "FK_Quanlydonhang_Quanlykhachhang_Makhachhang",
                        column: x => x.Makhachhang,
                        principalTable: "Quanlykhachhang",
                        principalColumn: "Makhachhang");
                    table.ForeignKey(
                        name: "FK_Quanlydonhang_Quanlysanpham_Masanpham",
                        column: x => x.Masanpham,
                        principalTable: "Quanlysanpham",
                        principalColumn: "Masanpham");
                });

            migrationBuilder.CreateTable(
                name: "Quanlyncc",
                columns: table => new
                {
                    Masanncc = table.Column<string>(type: "TEXT", nullable: false),
                    Tenncc = table.Column<string>(type: "TEXT", nullable: true),
                    sodienthoai = table.Column<int>(type: "INTEGER", nullable: false),
                    diachi = table.Column<string>(type: "TEXT", nullable: true),
                    email = table.Column<string>(type: "TEXT", nullable: true),
                    Masanpham = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quanlyncc", x => x.Masanncc);
                    table.ForeignKey(
                        name: "FK_Quanlyncc_Quanlysanpham_Masanpham",
                        column: x => x.Masanpham,
                        principalTable: "Quanlysanpham",
                        principalColumn: "Masanpham");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quanlydonhang_Makhachhang",
                table: "Quanlydonhang",
                column: "Makhachhang");

            migrationBuilder.CreateIndex(
                name: "IX_Quanlydonhang_Masanpham",
                table: "Quanlydonhang",
                column: "Masanpham");

            migrationBuilder.CreateIndex(
                name: "IX_Quanlyncc_Masanpham",
                table: "Quanlyncc",
                column: "Masanpham");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quanlydonhang");

            migrationBuilder.DropTable(
                name: "Quanlyncc");
        }
    }
}
