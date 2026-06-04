using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.db.Migrations
{
    /// <inheritdoc />
    public partial class addactivity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "RefreshTokens",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1986e795-108a-4627-b3c9-92b180942de8",
                column: "ConcurrencyStamp",
                value: "25bff0bb-4251-4a1f-80ff-6e21207c47c7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a516631-e39e-4da6-be12-b5984c83158f",
                column: "ConcurrencyStamp",
                value: "c4462062-f810-47b5-9230-f9d2deae7445");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "RefreshTokens");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1986e795-108a-4627-b3c9-92b180942de8",
                column: "ConcurrencyStamp",
                value: "788952a4-77c6-403f-b6a3-b5a8249cb7b1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a516631-e39e-4da6-be12-b5984c83158f",
                column: "ConcurrencyStamp",
                value: "e608792e-5c3c-4996-90a3-804842dde881");
        }
    }
}
