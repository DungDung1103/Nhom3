using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLNhom3.Migrations
{
    /// <inheritdoc />
    public partial class CreateForeignkeyAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Makhachhang",
                table: "Admin",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admin_Makhachhang",
                table: "Admin",
                column: "Makhachhang");

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_Quanlykhachhang_Makhachhang",
                table: "Admin",
                column: "Makhachhang",
                principalTable: "Quanlykhachhang",
                principalColumn: "Makhachhang");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admin_Quanlykhachhang_Makhachhang",
                table: "Admin");

            migrationBuilder.DropIndex(
                name: "IX_Admin_Makhachhang",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "Makhachhang",
                table: "Admin");
        }
    }
}
