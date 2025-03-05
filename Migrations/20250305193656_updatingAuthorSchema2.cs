using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalLibrary.Migrations
{
    /// <inheritdoc />
    public partial class updatingAuthorSchema2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bio",
                table: "Authors");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "Authors",
                type: "text",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Bio",
                value: "Author of science fiction and popular science.");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Bio",
                value: "Famous for writing the Harry Potter series.");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "Bio",
                value: "Known for her detective novels, particularly those featuring Hercule Poirot.");
        }
    }
}
