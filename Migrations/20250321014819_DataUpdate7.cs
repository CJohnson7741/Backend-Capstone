using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalLibrary.Migrations
{
    /// <inheritdoc />
    public partial class DataUpdate7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "98588837-5163-479e-bb1d-c7629abe35e6", "AQAAAAIAAYagAAAAENqXwX1hp3Ip9HDUIXtKyXWo8Tf94jjow8rG0cGYgpUJUG/9V8cQ1n66T5yRbzu6QQ==", "c0d1776b-bdd3-47ad-88c2-ca1a389e126c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a5a20920-a563-47ef-8dd1-f325e3cd0b61", "AQAAAAIAAYagAAAAEBn0P+TXvBFshPDVga0Oa91jPdzd/qIi5QAFKDR3CLTC/fY7MXyJTpJHKSwIa09oXQ==", "317f747f-442e-4cef-bc57-30826d3bd11e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6b3ef772-a35d-4e93-a054-ee8ec4a2ed4e", "AQAAAAIAAYagAAAAEGmZG1Ddj3r4exdKUA3ev1QTQ5pwHl5HO5WDCEk6bkYbe/qJ+6CO3B8kWpTXyrPXng==", "9a8124dd-ed66-4117-b8bf-5e39666f9858" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "22fc38e2-ac2f-4b4b-9a6b-17a981fc50f4", "AQAAAAIAAYagAAAAEKvLs4uakt95jS3y2Xy1K4DLOD32bJR3C1iotOLCpYyhD5PMsCT905zJsa1pxw0ltQ==", "f5885c7b-6629-4621-a257-81adb5964cd9" });
        }
    }
}
