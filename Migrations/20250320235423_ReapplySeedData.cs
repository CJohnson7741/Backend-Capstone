using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalLibrary.Migrations
{
    /// <inheritdoc />
    public partial class ReapplySeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8d5d620-2341-48d9-b06e-24056d21e741", "AQAAAAIAAYagAAAAEIu/djgHtgl0BGg82w6t2T8awho2F5kr5EN2pz6OtLCa7TQXUGXcKeIOrcMcqBtw8w==", "d119f699-d1dc-49ca-92fc-c9e96e58aba8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c3e657a9-50b2-46ee-b33a-eef62c76c68d", "AQAAAAIAAYagAAAAEGggxl7SBzUlob48ZyrJh9v+FZBlGXgQJu4JfAhxGySH9lTaM4Jypc4nkUprI+ySAQ==", "a03c8b4a-eb79-40c6-a6ca-1be9d607ae39" });
        }
    }
}
