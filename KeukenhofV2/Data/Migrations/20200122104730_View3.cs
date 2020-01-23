using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KeukenhofV2.Data.Migrations
{
    public partial class View3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_dbo.ViewTest",
                table: "dbo.ViewTest");

            migrationBuilder.RenameTable(
                name: "dbo.ViewTest",
                newName: "ViewTest");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ViewTest",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "ViewId",
                table: "ViewTest",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ViewTest",
                table: "ViewTest",
                column: "ViewId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ViewTest",
                table: "ViewTest");

            migrationBuilder.DropColumn(
                name: "ViewId",
                table: "ViewTest");

            migrationBuilder.RenameTable(
                name: "ViewTest",
                newName: "dbo.ViewTest");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "dbo.ViewTest",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbo.ViewTest",
                table: "dbo.ViewTest",
                column: "Id");
        }
    }
}
