using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _College.Migrations
{
    /// <inheritdoc />
    public partial class addyearprop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Year",
                table: "Batchs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "Batchs");
        }
    }
}
