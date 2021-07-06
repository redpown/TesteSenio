using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteSenior.Data.Migrations
{
    public partial class v009 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NUMERO_QUARTOS",
                table: "spRankingCondominio",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NUMERO_QUARTOS",
                table: "spRankingCondominio");
        }
    }
}
