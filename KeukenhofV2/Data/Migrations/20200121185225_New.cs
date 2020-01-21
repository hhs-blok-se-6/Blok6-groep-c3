using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KeukenhofV2.Data.Migrations
{
    public partial class New : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "vraag",
                table: "FAQ",
                newName: "Vraag");

            migrationBuilder.RenameColumn(
                name: "antwoord",
                table: "FAQ",
                newName: "Antwoord");

            migrationBuilder.RenameColumn(
                name: "Button2",
                table: "CardContent",
                newName: "Link");

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "FeaturedContent",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Page",
                table: "FAQ",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BereikbaarheidContent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BereikbaarheidContent", x => x.Id);
                });
            /*
            migrationBuilder.CreateTable(
                name: "ContactContent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactContent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CTAButtons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Page = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Theme = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTAButtons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EditPagesModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Controller = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditPagesModel", x => x.Id);
                });
*/
            migrationBuilder.CreateTable(
                name: "ParkContent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkContent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrivacyContent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivacyContent", x => x.Id);
                });
            /*
            migrationBuilder.CreateTable(
                name: "ToegankelijkheidContent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToegankelijkheidContent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VeelgesteldeVragen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VeelgesteldeVragen", x => x.Id);
                });*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BereikbaarheidContent");

            migrationBuilder.DropTable(
                name: "ContactContent");

            migrationBuilder.DropTable(
                name: "CTAButtons");

            migrationBuilder.DropTable(
                name: "EditPagesModel");

            migrationBuilder.DropTable(
                name: "ParkContent");

            migrationBuilder.DropTable(
                name: "PrivacyContent");

            migrationBuilder.DropTable(
                name: "ToegankelijkheidContent");

            migrationBuilder.DropTable(
                name: "VeelgesteldeVragen");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "FeaturedContent");

            migrationBuilder.DropColumn(
                name: "Page",
                table: "FAQ");

            migrationBuilder.RenameColumn(
                name: "Vraag",
                table: "FAQ",
                newName: "vraag");

            migrationBuilder.RenameColumn(
                name: "Antwoord",
                table: "FAQ",
                newName: "antwoord");

            migrationBuilder.RenameColumn(
                name: "Link",
                table: "CardContent",
                newName: "Button2");
        }
    }
}
