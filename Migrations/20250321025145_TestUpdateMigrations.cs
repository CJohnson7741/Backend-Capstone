using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalLibrary.Migrations
{
    /// <inheritdoc />
    public partial class TestUpdateMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "07e0f550-d4f0-446f-a35f-5161358a1d95", "AQAAAAIAAYagAAAAELdpgfR3eoKasBzOzgUkPtpV+XXh/4WcFgwf8HSCJ/WOyM8wq5Z3pdm62qxz6aK+pg==", "fda41f99-59c2-4740-844d-12db5555fc6f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e28903a7-ec1c-451c-92b3-baedab8ff7ca", "AQAAAAIAAYagAAAAECPgeNQK8qD+c+EzdbUMUs1CZV99QQr9ICLrJlXswwFB7QM/2u7lnjXChi4mP+pllQ==", "7c7f7ab8-f3fc-429e-a69e-fdf617bc49b1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "578510d4-c81e-4eaf-b88b-32a2d7f650d0", "AQAAAAIAAYagAAAAEFmLvYXrQk8cQO3pH3DP5/2KdeW7hmu0L/7lc0UFCE8+/4i5vCEsa5fEZm+EkxOc3A==", "ad227474-d5d4-42c2-b603-2cd3ae9473c6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4cf095ef-af9f-4cd7-b8e9-9cc9cf3da1ad", "AQAAAAIAAYagAAAAEOrhbMCNojtyri2H5RFlfj+auRaUFBWszKVqBN5DdbksAalIw0QbwoWGJyMd1p+myg==", "35b0d018-e7e2-4964-89c8-95266a5351b7" });
        }
    }
}
