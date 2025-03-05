using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionAndConditionToBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Condition",
                table: "Books",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Books",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0b1179f-e77b-4329-be9e-14462b122caf", "AQAAAAIAAYagAAAAEJjziK2DdB7hjg3RZ0/HvO5xysT8vA1owtXD0YfPRzK6EngRpnB51eCHX4a8BxU/Ow==", "4ba9daf4-7193-4212-9215-269014a24771" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d47162d8-b16b-4a1f-a0f2-a2f9798fbe58", "AQAAAAIAAYagAAAAECAd5zAK2vtRL2fyghtJWMGNTMaKp0feV1LcAc4Hts7KzqSX22Mn2KhArwM6Stz3NQ==", "b0cf898a-9ea0-4ab4-b0c1-d1f1d98957f1" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Condition", "Description" },
                values: new object[] { "New", "A science fiction novel about the fall of the Galactic Empire." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Condition", "Description" },
                values: new object[] { "Good", "A young wizard's journey begins at Hogwarts School of Witchcraft and Wizardry." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Condition", "Description" },
                values: new object[] { "Worn", "A detective story featuring Hercule Poirot solving a murder mystery on a train." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Condition", "Description" },
                values: new object[] { "Fair", "A fantasy novel about a hobbit's adventures in Middle-earth." });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Condition",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Books");

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
    }
}
