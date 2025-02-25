using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalLibrary.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a3a7656-a470-474c-afa0-0175cffef482", "AQAAAAIAAYagAAAAEJPwABP3EHKnZg8OvQQb+17eTQUvbdMXu4z0l6w5cstxoTeDBvaG1+XVT5RSuo4FZw==", "f50ffca2-8f48-44ed-a994-df34c38fac2f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1da73644-8513-4ce1-9e09-4bbf3e6d21a7", "AQAAAAIAAYagAAAAEKnbWIczA6BXnxIQfV2RoNKVfT3w/kmM4B6txhb4JZMp6kOc9EUB04HCCTDjDEslbA==", "cf38df67-47d2-46b7-8b42-f62c11a4d989" });
        }
    }
}
