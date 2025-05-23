using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebBanDoThoiTrang.Migrations
{
    /// <inheritdoc />
    public partial class AddGiaCuAndChiTietDonHang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDonHangs_SanPhams_SanPhamMaSanPham",
                table: "ChiTietDonHangs");

            migrationBuilder.DropTable(
                name: "ChiTietDonHangDonHang");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietDonHangs_SanPhamMaSanPham",
                table: "ChiTietDonHangs");

            migrationBuilder.DropColumn(
                name: "DiaChi",
                table: "ChiTietDonHangs");

            migrationBuilder.DropColumn(
                name: "DienThoai",
                table: "ChiTietDonHangs");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "ChiTietDonHangs");

            migrationBuilder.DropColumn(
                name: "HoTen",
                table: "ChiTietDonHangs");

            migrationBuilder.DropColumn(
                name: "SanPhamMaSanPham",
                table: "ChiTietDonHangs");

            migrationBuilder.RenameColumn(
                name: "MaKhachHang",
                table: "ChiTietDonHangs",
                newName: "Id");

            

            migrationBuilder.AddColumn<decimal>(
                name: "DonGia",
                table: "ChiTietDonHangs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "DonHangId",
                table: "ChiTietDonHangs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SanPhamId",
                table: "ChiTietDonHangs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SoLuong",
                table: "ChiTietDonHangs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonHangs_DonHangId",
                table: "ChiTietDonHangs",
                column: "DonHangId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonHangs_SanPhamId",
                table: "ChiTietDonHangs",
                column: "SanPhamId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDonHangs_DonHangs_DonHangId",
                table: "ChiTietDonHangs",
                column: "DonHangId",
                principalTable: "DonHangs",
                principalColumn: "MaDonHang",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDonHangs_SanPhams_SanPhamId",
                table: "ChiTietDonHangs",
                column: "SanPhamId",
                principalTable: "SanPhams",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDonHangs_DonHangs_DonHangId",
                table: "ChiTietDonHangs");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDonHangs_SanPhams_SanPhamId",
                table: "ChiTietDonHangs");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietDonHangs_DonHangId",
                table: "ChiTietDonHangs");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietDonHangs_SanPhamId",
                table: "ChiTietDonHangs");

           
            migrationBuilder.DropColumn(
                name: "DonGia",
                table: "ChiTietDonHangs");

            migrationBuilder.DropColumn(
                name: "DonHangId",
                table: "ChiTietDonHangs");

            migrationBuilder.DropColumn(
                name: "SanPhamId",
                table: "ChiTietDonHangs");

            migrationBuilder.DropColumn(
                name: "SoLuong",
                table: "ChiTietDonHangs");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ChiTietDonHangs",
                newName: "MaKhachHang");

            migrationBuilder.AddColumn<string>(
                name: "DiaChi",
                table: "ChiTietDonHangs",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DienThoai",
                table: "ChiTietDonHangs",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ChiTietDonHangs",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HoTen",
                table: "ChiTietDonHangs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SanPhamMaSanPham",
                table: "ChiTietDonHangs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ChiTietDonHangDonHang",
                columns: table => new
                {
                    ChiTietDonHangsMaKhachHang = table.Column<int>(type: "int", nullable: false),
                    DonHangsMaDonHang = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDonHangDonHang", x => new { x.ChiTietDonHangsMaKhachHang, x.DonHangsMaDonHang });
                    table.ForeignKey(
                        name: "FK_ChiTietDonHangDonHang_ChiTietDonHangs_ChiTietDonHangsMaKhachHang",
                        column: x => x.ChiTietDonHangsMaKhachHang,
                        principalTable: "ChiTietDonHangs",
                        principalColumn: "MaKhachHang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietDonHangDonHang_DonHangs_DonHangsMaDonHang",
                        column: x => x.DonHangsMaDonHang,
                        principalTable: "DonHangs",
                        principalColumn: "MaDonHang",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonHangs_SanPhamMaSanPham",
                table: "ChiTietDonHangs",
                column: "SanPhamMaSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonHangDonHang_DonHangsMaDonHang",
                table: "ChiTietDonHangDonHang",
                column: "DonHangsMaDonHang");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDonHangs_SanPhams_SanPhamMaSanPham",
                table: "ChiTietDonHangs",
                column: "SanPhamMaSanPham",
                principalTable: "SanPhams",
                principalColumn: "MaSanPham");
        }
    }
}
