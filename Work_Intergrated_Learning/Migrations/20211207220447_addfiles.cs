using Microsoft.EntityFrameworkCore.Migrations;

namespace Work_Intergrated_Learning.Migrations
{
    public partial class addfiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "AcademicRecord",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CV",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
              name: "AcademicRecord",
              table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CV",
                table: "AspNetUsers");
        }
    }
}
