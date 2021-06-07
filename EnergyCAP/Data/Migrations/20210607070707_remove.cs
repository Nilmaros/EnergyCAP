using Microsoft.EntityFrameworkCore.Migrations;

namespace EnergyCAP.Data.Migrations
{
    public partial class remove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repos_UsernameRepos_UsernameReposId",
                table: "Repos");

            migrationBuilder.DropTable(
                name: "UsernameRepos");

            migrationBuilder.DropIndex(
                name: "IX_Repos_UsernameReposId",
                table: "Repos");

            migrationBuilder.DropColumn(
                name: "UsernameReposId",
                table: "Repos");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Repos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Repos");

            migrationBuilder.AddColumn<int>(
                name: "UsernameReposId",
                table: "Repos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UsernameRepos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsernameRepos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Repos_UsernameReposId",
                table: "Repos",
                column: "UsernameReposId");

            migrationBuilder.AddForeignKey(
                name: "FK_Repos_UsernameRepos_UsernameReposId",
                table: "Repos",
                column: "UsernameReposId",
                principalTable: "UsernameRepos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
