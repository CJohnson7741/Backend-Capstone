using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalLibrary.Migrations
{
    /// <inheritdoc />
    public partial class FixGenreRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a1bb97d4-ff51-45c9-a5b6-3ddb33ae63a8", "AQAAAAIAAYagAAAAEPANOG+DX/ho/3q1mviJCSXb5pK72gKAY1046zbzGQ0SI6zbFewczd95QkFGwD0r9g==", "28f676c6-8f62-4172-add4-0a5cf35bbaac" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81eb981c-0a63-46c7-81ba-9b73c5c94b4f", "AQAAAAIAAYagAAAAELRJclfUyYBTXk5msRvQP7/sKoSDp5iaqVBpaHEoA2zXt6csCLHtbbVgboJ3PA3yLQ==", "b83b82d2-5536-43a1-a280-781337171d79" });
        }
    }
}
