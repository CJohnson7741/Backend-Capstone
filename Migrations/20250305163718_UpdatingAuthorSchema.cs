using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalLibrary.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingAuthorSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "43b7d3c5-2a9a-4010-b2a8-9d2a55e5fbdb", "AQAAAAIAAYagAAAAEDNe0WO+eshBX6wLg/o8j48cZrJCv0L6cWLwuNtqNU2yNqS2NrmhoN7dZv5pHUKIkw==", "7d342d5e-8c37-4ed4-bc0c-8a194cc5480f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db5bc37e-f64f-4bde-abde-cc68dcfb974c", "AQAAAAIAAYagAAAAEJHfZxelkqIWlMCuw17qTVtaRbWk//i9VzK1uo11VVyrUMU6y7MkN5MYnaZ5AZaYVA==", "2c898529-a0a6-44b5-ac94-32a430bdeece" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce6848f6-a781-4529-87a0-1cd03293d8e5", "AQAAAAIAAYagAAAAEM+9GLWSeD/MafQLKsJPViaoqkLRy28OwB2aD51asmHsjSeL0uqfH2jLAyeLsOSvnQ==", "98ed28d8-e1ca-412d-ac34-a05c935afde6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "efd2d662-ab41-4251-8e81-81dde144d30e", "AQAAAAIAAYagAAAAEGKdLk/NVnx+xuQ3IjSQxIomi9r6vqnqe9uo7rTsHqezOHo5mt+1rrfW0gvrUuquOQ==", "a2823fea-1aba-4474-9035-7347cd06d1f3" });
        }
    }
}
