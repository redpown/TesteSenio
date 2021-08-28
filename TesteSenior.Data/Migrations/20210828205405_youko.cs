using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteSenior.Data.Migrations
{
    public partial class youko : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TABELA_USUARIOS",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USUARIO_SENHA = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    USUARIO_EMAIL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    USUARIO_NOME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("USUARIO_ID", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "TABELA_USUARIOS",
                columns: new[] { "id", "USUARIO_SENHA", "USUARIO_EMAIL", "USUARIO_NOME" },
                values: new object[] { 1, null, "teste@teste.com", "andre" });

            migrationBuilder.InsertData(
                table: "TABELA_USUARIOS",
                columns: new[] { "id", "USUARIO_SENHA", "USUARIO_EMAIL", "USUARIO_NOME" },
                values: new object[] { 2, null, "teste@teste.com", "youko" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TABELA_USUARIOS");
        }
    }
}
