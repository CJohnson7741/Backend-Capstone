using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalLibrary.Migrations
{
    /// <inheritdoc />
    public partial class DataUpdate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0141a4fb-48fa-4dda-a5a7-515184e5e1dc", "AQAAAAIAAYagAAAAEJDVd3ShTDPAS3eqbqUq1USVVpDiDfSXptO1btZtd/8I0m1xVZWxF+zpr7N7JKO7zA==", "27de8e0f-d772-461c-a3b6-edd4a1f64fb5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "51df719f-b567-4ac2-994e-cfe7553c5468", "AQAAAAIAAYagAAAAEMr/xW2GOPfmIjnTbhy/qjwQ7qVbCwJkv1nWm7Yf3KSMWDa+ae0kN8zJOsM+gVUh/Q==", "d05a63a5-fa05-4d5b-9727-f70c5df511a3" });
        }
    }
}
