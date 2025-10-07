using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_Access_Layer.Migrations
{
    /// <inheritdoc />
    public partial class blog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abouts",
                columns: table => new
                {
                    AboutId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AboutContent = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abouts", x => x.AboutId);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    BlogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogAuthor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.BlogId);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactMap = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "ExperiencePages",
                columns: table => new
                {
                    ExperiencePageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExperiencePageContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperiencePageContentlow = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperiencePageTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperiencePageText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperiencePages", x => x.ExperiencePageId);
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    ExperienceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExperiencImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.ExperienceId);
                });

            migrationBuilder.CreateTable(
                name: "NavbarLefts",
                columns: table => new
                {
                    NavbarLeftId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NavbarLeftImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NavbarLefName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NavbarLeftText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NavbarLeftEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NavbarLeftPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NavbarLeftAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NavbarLeftLinkGithub = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NavbarLeftLinkLinkedin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NavbarLeftLinkInstagram = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NavbarLefts", x => x.NavbarLeftId);
                });

            migrationBuilder.CreateTable(
                name: "Projes",
                columns: table => new
                {
                    ProjeSId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjeImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjeLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjeText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projes", x => x.ProjeSId);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceIcon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceId);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillsContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkillsNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillsId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abouts");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "ExperiencePages");

            migrationBuilder.DropTable(
                name: "Experiences");

            migrationBuilder.DropTable(
                name: "NavbarLefts");

            migrationBuilder.DropTable(
                name: "Projes");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Skills");
        }
    }
}
