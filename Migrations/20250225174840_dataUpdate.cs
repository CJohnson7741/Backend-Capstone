using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PersonalLibrary.Migrations
{
    /// <inheritdoc />
    public partial class dataUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "6f50737e-e859-4e8a-ac9a-2db7cb6ba745", "johndoe@example.com", true, false, null, "JOHNDOE@EXAMPLE.COM", "JOHN_DOE", "hashed_password_here", null, false, "06a37dc3-8a91-4555-bf59-85295f9d7dd9", false, "john_doe" },
                    { "2", 0, "3a79c44c-b244-4667-ba21-47bea3740e73", "janesmith@example.com", true, false, null, "JANESMITH@EXAMPLE.COM", "JANE_SMITH", "hashed_password_here", null, false, "ab7e3fbf-1a92-4e3a-8655-8b5e54694a83", false, "jane_smith" }
                });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "Bio", "Name" },
                values: new object[,]
                {
                    { 1, "Isaac Asimov was a Russian-born American author and professor of biochemistry.", "Isaac Asimov" },
                    { 2, "J.K. Rowling is a British author best known for the Harry Potter series.", "J.K. Rowling" },
                    { 3, "Malcolm Gladwell is a Canadian journalist, author, and speaker.", "Malcolm Gladwell" }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Science Fiction" },
                    { 2, "Fantasy" },
                    { 3, "Non-Fiction" }
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "Email", "IdentityUserId", "UserName" },
                values: new object[,]
                {
                    { 1, "johndoe@example.com", "1", "john_doe" },
                    { 2, "janesmith@example.com", "2", "jane_smith" }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "GenreId", "ISBN", "Title", "UserProfileId" },
                values: new object[,]
                {
                    { 1, 1, "978-0-553-80371-0", "Foundation", 1 },
                    { 2, 2, "978-0-7432-4475-1", "Harry Potter and the Sorcerer's Stone", 2 },
                    { 3, 3, "978-0-316-01792-3", "Outliers", 1 }
                });

            migrationBuilder.InsertData(
                table: "BookAuthor",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookAuthor",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "BookAuthor",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "BookAuthor",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");
        }
    }
}
