using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalLibrary.Migrations
{
    /// <inheritdoc />
    public partial class DataUpdate5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "df8dfce8-26a3-4deb-b120-83b343a6e4e9", "AQAAAAIAAYagAAAAEOQbUraie5iw5NtFyoMtDlNXo9LCikuJrtp3WNEM1AR7xuGOoJ+CWjED+nntHzguhg==", "12842f7b-60e0-4825-96e9-bee79e4573c8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81a48475-c99a-4061-8cb3-0d0a7ac1401f", "AQAAAAIAAYagAAAAEA3Xm5hrLwe1cyb4R4T0zKWaPBpyMtTI03kAjOIPrBmUYvUTHxrZw0Mf0WJbEd4jLA==", "920b0292-193f-45a9-9ec6-ed5029ab6180" });
        }
    }
}
