using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalLibrary.Migrations
{
    /// <inheritdoc />
    public partial class DataUpdate4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5611971c-04f2-497f-8136-a15ab049d91b", "AQAAAAIAAYagAAAAEPpLvNAQeDBaSaqJOgc/6pczMMNd5BOfnCofy9GE1QwOJ2F0wvze/WKgh0XaJQIpGA==", "e67c271d-c2cc-4cc8-ac35-f33a5dcd2445" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a92c259-f835-45ec-9e8c-258a18dd960e", "AQAAAAIAAYagAAAAEBNACFWAXFHZey5PUm69Zs9fx7O7U44TueUDGvZk940xIsheVM7cZ3Jh9nhbwurLEw==", "ef9d0558-f30a-48c1-847c-61eb25aa3d7e" });
        }
    }
}
