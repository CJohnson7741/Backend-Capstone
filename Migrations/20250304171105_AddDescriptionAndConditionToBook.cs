using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionAndConditionToBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6813f658-a063-4807-a432-a764e68ad04f", "AQAAAAIAAYagAAAAEJQstOD4C2nGULgua3RsWlnAs0reqWVVVoEf58OnDPOGOCWRzfKyuI5IdHPvGznR0A==", "13437ca9-a251-47e7-8131-6f62d41852f1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "902969db-54ea-424c-b405-b89f6e8bcc9d", "AQAAAAIAAYagAAAAED42ZI1GwZFdLe12Uojyy2fKqvVUik6WXQECHbS8/4lx2vbj9OKG/WM2iK9XPcGV5A==", "576cb768-c52f-4184-95dd-cddbb0a56fe5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5d660d38-f437-48f3-99e0-9ee88ecde3c2", "AQAAAAIAAYagAAAAEJDqElZ2Ni2Ibpm+rh5xhPbE4y3ALMaobzZ1bTTlJ7ccJDvR7H8vh/b3/6qYCY2d0A==", "dede39a5-2bc1-4db6-8f49-7d9d8443beda" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6b38b0aa-e45d-4298-b468-69bd13bfe443", "AQAAAAIAAYagAAAAEIztfb/b2qChgOPTUADon6PpiZ8g3GWKdv71ES+iJv+23FB1AHsb0MUBf1i0xPURmg==", "fb5f9150-0c80-440b-bfb5-a259977d7903" });
        }
    }
}
