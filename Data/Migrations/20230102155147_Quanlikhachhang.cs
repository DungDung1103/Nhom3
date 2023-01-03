using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLNhom3.Data.Migrations
{
    /// <inheritdoc />
    public partial class Quanlikhachhang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quanlikhachhang",
                columns: table => new
                {
                    Makhachhang = table.Column<string>(type: "TEXT", nullable: false),
                    Tenkhachhang = table.Column<string>(type: "TEXT", nullable: false),
                    Diachi = table.Column<string>(type: "TEXT", nullable: true),
                    Sodienthoai = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quanlikhachhang", x => x.Makhachhang);
                });

            migrationBuilder.CreateTable(
                name: "QuanliNCC",
                columns: table => new
                {
                    MaNCC = table.Column<string>(type: "TEXT", nullable: false),
                    TenNCC = table.Column<string>(type: "TEXT", nullable: false),
                    Sodienthoai = table.Column<int>(type: "INTEGER", nullable: false),
                    Diachi = table.Column<string>(type: "TEXT", nullable: true),
                    Emai = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuanliNCC", x => x.MaNCC);
                });

            migrationBuilder.CreateTable(
                name: "Quanlisanpham",
                columns: table => new
                {
                    Masanpham = table.Column<string>(type: "TEXT", nullable: false),
                    Tensanpham = table.Column<string>(type: "TEXT", nullable: false),
                    size = table.Column<int>(type: "INTEGER", nullable: false),
                    soluong = table.Column<int>(type: "INTEGER", nullable: false),
                    mausac = table.Column<string>(type: "TEXT", nullable: false),
                    giatien = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quanlisanpham", x => x.Masanpham);
                });

            migrationBuilder.CreateTable(
                name: "Quanlidonhang",
                columns: table => new
                {
                    Madonhang = table.Column<string>(type: "TEXT", nullable: false),
                    ngay = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Masanpham = table.Column<string>(type: "TEXT", nullable: false),
                    Makhachhang = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quanlidonhang", x => x.Madonhang);
                    table.ForeignKey(
                        name: "FK_Quanlidonhang_Quanlikhachhang_Makhachhang",
                        column: x => x.Makhachhang,
                        principalTable: "Quanlikhachhang",
                        principalColumn: "Makhachhang");
                    table.ForeignKey(
                        name: "FK_Quanlidonhang_Quanlisanpham_Masanpham",
                        column: x => x.Masanpham,
                        principalTable: "Quanlisanpham",
                        principalColumn: "Masanpham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quanlidonhang_Makhachhang",
                table: "Quanlidonhang",
                column: "Makhachhang");

            migrationBuilder.CreateIndex(
                name: "IX_Quanlidonhang_Masanpham",
                table: "Quanlidonhang",
                column: "Masanpham");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quanlidonhang");

            migrationBuilder.DropTable(
                name: "QuanliNCC");

            migrationBuilder.DropTable(
                name: "Quanlikhachhang");

            migrationBuilder.DropTable(
                name: "Quanlisanpham");
        }
    }
}
