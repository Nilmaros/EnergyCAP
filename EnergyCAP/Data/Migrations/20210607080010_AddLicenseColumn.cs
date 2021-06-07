using Microsoft.EntityFrameworkCore.Migrations;

namespace EnergyCAP.Data.Migrations
{
    public partial class AddLicenseColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "License",
                table: "Repos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "License",
                table: "Repos");
        }
    }
}
