using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce.db.Migrations
{
    /// <inheritdoc />
    public partial class addUserRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1986e795-108a-4627-b3c9-92b180942de8", "5fcb99b8-2694-4d24-bc76-13b0edabe510", "Admin", "ADMIN" },
                    { "5a516631-e39e-4da6-be12-b5984c83158f", "9393933d-d8a1-4fb7-bb8c-e5e9886d54d2", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1986e795-108a-4627-b3c9-92b180942de8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a516631-e39e-4da6-be12-b5984c83158f");
        }
    }
}
