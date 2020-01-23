using Microsoft.EntityFrameworkCore.Migrations;

namespace KeukenhofV2.Data.Migrations
{
    public partial class SearchView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE VIEW SearchView AS " +
  "SELECT 'H' + CONVERT(VARCHAR,[Id]) as Sid, Id, Type, Content, 'Home' location FROM HomeContent UNION ALL " +
  "SELECT 'E' + CONVERT(VARCHAR,[Id]) as Sid, Id, Type, Content, 'Evenementen' FROM EvenementenContent UNION ALL " +
  "SELECT 'B' + CONVERT(VARCHAR,[Id]) as Sid, Id, Type, Content, 'Bereikbaarheid' FROM BereikbaarheidContent UNION ALL " +
  "SELECT 'P' + CONVERT(VARCHAR,[Id]) as Sid, Id, Type, Content, 'Park' FROM ParkContent UNION ALL " +
  "SELECT 'C' + CONVERT(VARCHAR,[Id]) as Sid, Id, Type, Content, 'Contact' FROM ContactContent UNION ALL " +
  "SELECT 'PR' + CONVERT(VARCHAR,[Id]) as Sid, Id, Type, Content, 'Praktisch' FROM PraktischContent UNION ALL " +
  "SELECT 'PC' + CONVERT(VARCHAR,[Id]) as Sid, Id, Type, Content, 'Privacy' FROM PrivacyContent UNION ALL " +
  "SELECT 'T' + CONVERT(VARCHAR,[Id]) as Sid, Id, Type, Content, 'Toegankelijkheid' FROM ToegankelijkheidContent UNION ALL " +
  "SELECT 'V' + CONVERT(VARCHAR,[Id]) as Sid, Id, Type, Content, 'Veelgestelde Vragen' FROM VeelgesteldeVragen");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
