using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.db.Migrations
{
    /// <inheritdoc />
    public partial class addFullname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "full_name",
                table: "AspNetUsers",
                newName: "FullName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "AspNetUsers",
                newName: "full_name");
        }
    }
}
