using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.db.Migrations
{
    /// <inheritdoc />
    public partial class addUserRoles2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1986e795-108a-4627-b3c9-92b180942de8",
                column: "ConcurrencyStamp",
                value: "5fcb99b8-2694-4d24-bc76-13b0edabe510");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a516631-e39e-4da6-be12-b5984c83158f",
                column: "ConcurrencyStamp",
                value: "9393933d-d8a1-4fb7-bb8c-e5e9886d54d2");
        }
    }
}
