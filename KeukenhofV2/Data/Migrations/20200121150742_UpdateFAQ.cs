using Microsoft.EntityFrameworkCore.Migrations;

namespace KeukenhofV2.Data.Migrations
{
    public partial class UpdateFAQ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Page",
                table: "FAQ",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Page",
                table: "FAQ");
        }
    }
}
