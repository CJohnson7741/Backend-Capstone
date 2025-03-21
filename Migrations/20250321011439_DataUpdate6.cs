using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalLibrary.Migrations
{
    /// <inheritdoc />
    public partial class DataUpdate6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6b3ef772-a35d-4e93-a054-ee8ec4a2ed4e", "AQAAAAIAAYagAAAAEGmZG1Ddj3r4exdKUA3ev1QTQ5pwHl5HO5WDCEk6bkYbe/qJ+6CO3B8kWpTXyrPXng==", "9a8124dd-ed66-4117-b8bf-5e39666f9858" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "22fc38e2-ac2f-4b4b-9a6b-17a981fc50f4", "AQAAAAIAAYagAAAAEKvLs4uakt95jS3y2Xy1K4DLOD32bJR3C1iotOLCpYyhD5PMsCT905zJsa1pxw0ltQ==", "f5885c7b-6629-4621-a257-81adb5964cd9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8148475e-084a-4852-8c3f-521127987e91", "AQAAAAIAAYagAAAAECx299BWSsQAhqJCXMKQoavzyLlSTjq1Y9YFkfMx7Dkw2K2+E7jhBpYEirHn5XwqIg==", "ea1748b7-ba7f-429b-b33c-c241c94f7939" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "615902aa-691d-412f-ae7e-21f64e2e3b31", "AQAAAAIAAYagAAAAELfRrSqZT4XSqFIvN1SeLVL0GFs3aTZY0EHuiC6NB7+SJHbWlKQDWLLDKIFr9badkw==", "98ef927d-20b6-4b54-a770-1696fdb85e98" });
        }
    }
}
