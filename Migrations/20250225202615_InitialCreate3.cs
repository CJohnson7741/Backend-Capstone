using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalLibrary.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5d660d38-f437-48f3-99e0-9ee88ecde3c2", "AQAAAAIAAYagAAAAEJDqElZ2Ni2Ibpm+rh5xhPbE4y3ALMaobzZ1bTTlJ7ccJDvR7H8vh/b3/6qYCY2d0A==", "dede39a5-2bc1-4db6-8f49-7d9d8443beda" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2", 0, "6b38b0aa-e45d-4298-b468-69bd13bfe443", "user2@library.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEIztfb/b2qChgOPTUADon6PpiZ8g3GWKdv71ES+iJv+23FB1AHsb0MUBf1i0xPURmg==", null, false, "fb5f9150-0c80-440b-bfb5-a259977d7903", false, "user2" });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "Email", "IdentityUserId", "UserName" },
                values: new object[] { 2, "user2@library.com", "2", "user2" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "GenreId", "ISBN", "Title", "UserProfileId" },
                values: new object[] { 4, 2, "978-0-618-00221-3", "The Hobbit", 2 });

            migrationBuilder.InsertData(
                table: "BookAuthors",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[] { 2, 4 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a3a7656-a470-474c-afa0-0175cffef482", "AQAAAAIAAYagAAAAEJPwABP3EHKnZg8OvQQb+17eTQUvbdMXu4z0l6w5cstxoTeDBvaG1+XVT5RSuo4FZw==", "f50ffca2-8f48-44ed-a994-df34c38fac2f" });
        }
    }
}
