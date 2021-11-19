using Microsoft.EntityFrameworkCore.Migrations;

namespace Work_Intergrated_Learning.Migrations
{
    public partial class SecondCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
             name: "Jobs",
             columns: table => new
             {
                 Id = table.Column<int>(type: "int", nullable: false)
                     .Annotation("SqlServer:Identity", "1, 1"),
                 Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                 JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 JobDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                 JobRoleNResponsibilities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                 Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                 Sorting = table.Column<int>(type: "int", nullable: false)
             },
             constraints: table =>
             {
                 table.PrimaryKey("PK_Jobs", x => x.Id);
             });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
              name: "Jobs");

        }
    }
}
