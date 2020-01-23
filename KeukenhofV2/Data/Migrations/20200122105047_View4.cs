using Microsoft.EntityFrameworkCore.Migrations;

namespace KeukenhofV2.Data.Migrations
{
    public partial class View4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE VIEW LolView AS " +
               "SELECT Id, Type, Content, 'Home' location FROM HomeContent UNION ALL " +
               "SELECT Id, Type, Content, 'Evenementen' FROM EvenementenContent");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
