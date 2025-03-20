using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalLibrary.Migrations
{
    /// <inheritdoc />
    public partial class classUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5be47e91-19b2-43da-8da9-1e15c76440b1", "AQAAAAIAAYagAAAAEGua/rsoDpROpqFDlsNPBvRYj9Qy9HKPkUm3u67pY8A5oThwGhNBO5w+LT88hXRFJQ==", "3dd36198-d92e-4ced-a68c-670b56495d0f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "16879dc0-0914-4f18-aecb-48974ba01200", "AQAAAAIAAYagAAAAEM0UhTCFFVy3QCIP8QMWkwYDWnM3skcX18K0NM6gzgqgL2fMe8eHLgZV48Net8h24Q==", "640a0f98-4f46-4509-8544-c6da7c40a2ad" });
        }
    }
}
