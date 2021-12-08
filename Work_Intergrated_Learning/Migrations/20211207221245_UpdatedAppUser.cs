using Microsoft.EntityFrameworkCore.Migrations;

namespace Work_Intergrated_Learning.Migrations
{
    public partial class UpdatedAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
              name: "Department",
              table: "AspNetUsers",
              type: "nvarchar(max)",
              nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YearOfStudy",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "YearOfStudy",
                table: "AspNetUsers");


        }
    }
}
