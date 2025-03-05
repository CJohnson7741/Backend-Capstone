using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalLibrary.Migrations
{
    /// <inheritdoc />
    public partial class DataTestUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a1bb97d4-ff51-45c9-a5b6-3ddb33ae63a8", "AQAAAAIAAYagAAAAEPANOG+DX/ho/3q1mviJCSXb5pK72gKAY1046zbzGQ0SI6zbFewczd95QkFGwD0r9g==", "28f676c6-8f62-4172-add4-0a5cf35bbaac" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81eb981c-0a63-46c7-81ba-9b73c5c94b4f", "AQAAAAIAAYagAAAAELRJclfUyYBTXk5msRvQP7/sKoSDp5iaqVBpaHEoA2zXt6csCLHtbbVgboJ3PA3yLQ==", "b83b82d2-5536-43a1-a280-781337171d79" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
