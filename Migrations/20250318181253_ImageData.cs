using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalLibrary.Migrations
{
    /// <inheritdoc />
    public partial class ImageData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Books",
                type: "text",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Books");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c86aa4f4-8ef1-4d54-9f05-4334db0606bf", "AQAAAAIAAYagAAAAELbjcx9NisBG4AkJzCVSvAswjb5UjMVYxg/SJ2yLqzVVcdBT+KwN/AdpNsQ7uAgpUw==", "9dd943d7-8c4c-4758-941f-288f8800d7f9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8bd8d174-7262-4d67-85d8-c930fb7b37ac", "AQAAAAIAAYagAAAAEE1FalKRZqzLk9MTcfkQbM1hQEC8foHUSipov2fIBY4cbPtTMuWawjoDioLQE3eRQw==", "5fccbe5b-1589-41f8-a8dd-445b8784b99a" });
        }
    }
}
