using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteSenior.Data.Migrations
{
    public partial class v008 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "spRankingCondominio",
                columns: table => new
                {
                    CODIGO_APARTAMENTO = table.Column<int>(type: "int", nullable: false),
                    CODIGO_EDIFICIO = table.Column<int>(type: "int", nullable: false),
                    NOME_EDIFICIO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    METRAGEM = table.Column<int>(type: "int", nullable: false),
                    ANDAR = table.Column<int>(type: "int", nullable: false),
                    NOME_CIDADE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ESTADO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VALOR_PAGAMENTO = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "TABELA_CIDADE",
                columns: table => new
                {
                    CODIGO_CIDADE = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME_CIDADE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ESTADO = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TABELA_CIDADE", x => x.CODIGO_CIDADE);
                });

            migrationBuilder.CreateTable(
                name: "TABELA_EDIFICIO",
                columns: table => new
                {
                    CODIGO_EDIFICIO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODIGO_CIDADE = table.Column<int>(type: "int", nullable: false),
                    NOME_EDIFICIO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ANDARES = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    NUMERO__APTO_ANDAR = table.Column<int>(type: "int", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TABELA_EDIFICIO", x => x.CODIGO_EDIFICIO);
                    table.ForeignKey(
                        name: "FK_TABELA_EDIFICIO_TABELA_CIDADE_CODIGO_CIDADE",
                        column: x => x.CODIGO_CIDADE,
                        principalTable: "TABELA_CIDADE",
                        principalColumn: "CODIGO_CIDADE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TABELA_APARTAMENTO",
                columns: table => new
                {
                    CODIGO_APARTAMENTO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODIGO_EDIFICIO = table.Column<int>(type: "int", nullable: true),
                    METRAGEM = table.Column<int>(type: "int", maxLength: 400, nullable: false),
                    ANDAR = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    NUMERO_QUARTOS = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TABELA_APARTAMENTO", x => x.CODIGO_APARTAMENTO);
                    table.ForeignKey(
                        name: "FK_TABELA_APARTAMENTO_TABELA_EDIFICIO_CODIGO_EDIFICIO",
                        column: x => x.CODIGO_EDIFICIO,
                        principalTable: "TABELA_EDIFICIO",
                        principalColumn: "CODIGO_EDIFICIO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TABELA_PAGAMENTOS_CONDOMINIO",
                columns: table => new
                {
                    CODIGO_PAGAMENTOS_CONDOMINIO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODIGO_APARTAMENTO = table.Column<int>(type: "int", nullable: false),
                    DATA_PAGAMENTO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VALOR_PAGAMENTO = table.Column<double>(type: "float", maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TABELA_PAGAMENTOS_CONDOMINIO", x => x.CODIGO_PAGAMENTOS_CONDOMINIO);
                    table.ForeignKey(
                        name: "FK_TABELA_PAGAMENTOS_CONDOMINIO_TABELA_APARTAMENTO_CODIGO_APARTAMENTO",
                        column: x => x.CODIGO_APARTAMENTO,
                        principalTable: "TABELA_APARTAMENTO",
                        principalColumn: "CODIGO_APARTAMENTO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TABELA_APARTAMENTO_CODIGO_EDIFICIO",
                table: "TABELA_APARTAMENTO",
                column: "CODIGO_EDIFICIO");

            migrationBuilder.CreateIndex(
                name: "IX_TABELA_EDIFICIO_CODIGO_CIDADE",
                table: "TABELA_EDIFICIO",
                column: "CODIGO_CIDADE");

            migrationBuilder.CreateIndex(
                name: "IX_TABELA_PAGAMENTOS_CONDOMINIO_CODIGO_APARTAMENTO",
                table: "TABELA_PAGAMENTOS_CONDOMINIO",
                column: "CODIGO_APARTAMENTO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "spRankingCondominio");

            migrationBuilder.DropTable(
                name: "TABELA_PAGAMENTOS_CONDOMINIO");

            migrationBuilder.DropTable(
                name: "TABELA_APARTAMENTO");

            migrationBuilder.DropTable(
                name: "TABELA_EDIFICIO");

            migrationBuilder.DropTable(
                name: "TABELA_CIDADE");
        }
    }
}
