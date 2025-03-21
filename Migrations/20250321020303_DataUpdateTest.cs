using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalLibrary.Migrations
{
    /// <inheritdoc />
    public partial class DataUpdateTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ee32b86-c447-46f5-8422-50de9784be4d", "AQAAAAIAAYagAAAAEMigrkUfkjdhRyRcCdWlEay0SbJ7iJHzKm1wEbxbAPjVeB6bMXiKJd5Y13J5NnHdAg==", "216e2725-c7d6-49d4-850a-5248af595312" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "67e5abcc-fedb-4159-b388-8e94e83a3143", "AQAAAAIAAYagAAAAEA87ddMaanJK3b++eo+QzJYb6ROAcd8SRI5Ap1455OnLaVsU5QT8qk3Q2V23WtlWqQ==", "28142a32-3934-4d4a-a2fd-95abc63dd820" });
        }
    }
}
