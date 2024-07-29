using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcouzVilla_API.Migrations
{
    /// <inheritdoc />
    public partial class _َAddPropertyToVillaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 29, 22, 29, 16, 183, DateTimeKind.Local).AddTicks(1645));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 29, 22, 29, 16, 183, DateTimeKind.Local).AddTicks(1658));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 29, 22, 29, 16, 183, DateTimeKind.Local).AddTicks(1660));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 29, 22, 29, 16, 183, DateTimeKind.Local).AddTicks(1662));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 29, 22, 29, 16, 183, DateTimeKind.Local).AddTicks(1663));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 29, 18, 40, 9, 739, DateTimeKind.Local).AddTicks(9030));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 29, 18, 40, 9, 739, DateTimeKind.Local).AddTicks(9041));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 29, 18, 40, 9, 739, DateTimeKind.Local).AddTicks(9042));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 29, 18, 40, 9, 739, DateTimeKind.Local).AddTicks(9044));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 29, 18, 40, 9, 739, DateTimeKind.Local).AddTicks(9045));
        }
    }
}
