using Microsoft.EntityFrameworkCore.Migrations;

namespace KeukenhofV2.Data.Migrations
{
    public partial class View6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE VIEW ProView AS " +
            "SELECT 'C' + CONVERT(VARCHAR,[Id]) as Nid, Id, Type, Content, 'Home' location FROM HomeContent UNION ALL " +
            "SELECT 'C' + CONVERT(VARCHAR,[Id]) as Nid, Id, Type, Content, 'Evenementen' FROM EvenementenContent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
