using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLNhom3.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quanlykhachhang",
                columns: table => new
                {
                    Makhachhang = table.Column<string>(type: "TEXT", nullable: false),
                    Tenkhachhang = table.Column<string>(type: "TEXT", nullable: true),
                    Diachi = table.Column<string>(type: "TEXT", nullable: true),
                    Sodienthoai = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quanlykhachhang", x => x.Makhachhang);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quanlykhachhang");
        }
    }
}
