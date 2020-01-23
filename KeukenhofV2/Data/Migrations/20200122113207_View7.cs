using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KeukenhofV2.Data.Migrations
{
    public partial class View7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*
            migrationBuilder.DropPrimaryKey(
                name: "PK_ViewTest",
                table: "ViewTest");

            migrationBuilder.DropColumn(
                name: "ViewId",
                table: "ViewTest");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ViewTest",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ViewTest",
                table: "ViewTest",
                column: "Id");
                */
            migrationBuilder.Sql("CREATE VIEW ProView AS " +
       "SELECT 'C' + CONVERT(VARCHAR,[Id]) as Nid, Id, Type, Content, 'Home' location FROM HomeContent UNION ALL " +
       "SELECT 'E' + CONVERT(VARCHAR,[Id]) as Nid, Id, Type, Content, 'Evenementen' FROM EvenementenContent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            /*
            migrationBuilder.DropPrimaryKey(
                name: "PK_ViewTest",
                table: "ViewTest");

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
                */
        }
    }
}
