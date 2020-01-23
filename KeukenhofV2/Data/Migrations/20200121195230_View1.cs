using Microsoft.EntityFrameworkCore.Migrations;

namespace KeukenhofV2.Data.Migrations
{
    public partial class View1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE VIEW DingView AS newID() IdDing " +
                "SELECT Id, Type, Content, 'Home' location FROM HomeContent UNION ALL " +
                "SELECT Id, Type, Content, 'Evenementen' FROM EvenementenContent");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
