using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NguyenNGocLongVu33.Migrations
{
    /// <inheritdoc />
    public partial class LV : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LopHoc",
                columns: table => new
                {
                    MaLop = table.Column<string>(type: "TEXT", nullable: false),
                    TenLop = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopHoc", x => x.MaLop);
                });

            migrationBuilder.CreateTable(
                name: "SinhVien",
                columns: table => new
                {
                    MaSinhvien = table.Column<string>(type: "TEXT", nullable: false),
                    HoTen = table.Column<string>(type: "TEXT", nullable: false),
                    MaLop = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhVien", x => x.MaSinhvien);
                });

            migrationBuilder.CreateTable(
                name: "TTSV",
                columns: table => new
                {
                    MaSinhvien = table.Column<string>(type: "TEXT", nullable: false),
                    HoTen = table.Column<string>(type: "TEXT", nullable: false),
                    MaLop = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TTSV", x => x.MaSinhvien);
                    table.ForeignKey(
                        name: "FK_TTSV_LopHoc_MaLop",
                        column: x => x.MaLop,
                        principalTable: "LopHoc",
                        principalColumn: "MaLop",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TTSV_MaLop",
                table: "TTSV",
                column: "MaLop");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SinhVien");

            migrationBuilder.DropTable(
                name: "TTSV");

            migrationBuilder.DropTable(
                name: "LopHoc");
        }
    }
}
