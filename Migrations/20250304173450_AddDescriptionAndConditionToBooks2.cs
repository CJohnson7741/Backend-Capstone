using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionAndConditionToBooks2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "37103c1b-0d60-466c-a934-9aecbfa1bdb6", "AQAAAAIAAYagAAAAENy5H2EMuIF/8MWhZ2XNSlPZLqs57XnOJkYHvlpNdMV+eTu3aWNuDHpSmiF6LrOJxA==", "bf40202c-e04d-4ba2-bcb1-0d934d5984be" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "17c2ba88-47a8-4242-af39-8f6843723edc", "AQAAAAIAAYagAAAAEJLe22fYvOdhHI8xTdRDmErwoCj8/NCdAdl68EWlvNkAmr3tCZmS/E3ztQgTz4DrXg==", "b99bfa6c-66b5-44a1-bf6a-13fd7ff135cc" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
