using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalLibrary.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1da73644-8513-4ce1-9e09-4bbf3e6d21a7", "AQAAAAIAAYagAAAAEKnbWIczA6BXnxIQfV2RoNKVfT3w/kmM4B6txhb4JZMp6kOc9EUB04HCCTDjDEslbA==", "cf38df67-47d2-46b7-8b42-f62c11a4d989" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "72fc5a8d-6665-4084-a54a-8c9ec1f98c8e", "AQAAAAIAAYagAAAAEKDpmlvtGPGTsnOlx17pFtLDykk6Ry6MMp0VO4Z4dd/ZPaOQT64HGAf5+VPyPI1pBg==", "a5499c4c-0d8b-41ef-aa14-2ffcd9a7102d" });
        }
    }
}
