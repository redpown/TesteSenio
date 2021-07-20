using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteSenior.Data.Migrations
{
    public partial class v001 : Migration
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
                    VALOR_PAGAMENTO = table.Column<double>(type: "float", nullable: false),
                    NUMERO_QUARTOS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "TABELA_CIDADE",
                columns: table => new
                {
                    CODIGO_CIDADE = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME_CIDADE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ESTADO = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CODIGO_CIDADE", x => x.CODIGO_CIDADE);
                });

            migrationBuilder.CreateTable(
                name: "TABELA_EDIFICIO",
                columns: table => new
                {
                    CODIGO_EDIFICIO = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODIGO_CIDADE = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    NOME_EDIFICIO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ANDARES = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    NUMERO__APTO_ANDAR = table.Column<int>(type: "int", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CODIGO_EDIFICIO", x => x.CODIGO_EDIFICIO);
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
                    CODIGO_APARTAMENTO = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODIGO_EDIFICIO = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    METRAGEM = table.Column<int>(type: "int", maxLength: 400, nullable: false),
                    ANDAR = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    NUMERO_QUARTOS = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CODIGO_APARTAMENTO", x => x.CODIGO_APARTAMENTO);
                    table.ForeignKey(
                        name: "FK_TABELA_APARTAMENTO_TABELA_EDIFICIO_CODIGO_EDIFICIO",
                        column: x => x.CODIGO_EDIFICIO,
                        principalTable: "TABELA_EDIFICIO",
                        principalColumn: "CODIGO_EDIFICIO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TABELA_PAGAMENTOS_CONDOMINIO",
                columns: table => new
                {
                    CODIGO_PAGAMENTOS_CONDOMINIO = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODIGO_APARTAMENTO = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    DATA_PAGAMENTO = table.Column<DateTime>(type: "date", nullable: false),
                    VALOR_PAGAMENTO = table.Column<double>(type: "float", maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CODIGO_PAGAMENTOS_CONDOMINIO_ID", x => x.CODIGO_PAGAMENTOS_CONDOMINIO);
                    table.ForeignKey(
                        name: "FK_TABELA_PAGAMENTOS_CONDOMINIO_TABELA_APARTAMENTO_CODIGO_APARTAMENTO",
                        column: x => x.CODIGO_APARTAMENTO,
                        principalTable: "TABELA_APARTAMENTO",
                        principalColumn: "CODIGO_APARTAMENTO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TABELA_CIDADE",
                columns: new[] { "CODIGO_CIDADE", "ESTADO", "NOME_CIDADE" },
                values: new object[,]
                {
                    { 1, "SP", "Campinas" },
                    { 2, "RJ", "Rio de Janeiro" },
                    { 3, "SP", "São Paulo" },
                    { 4, "SP", "Sorocaba" },
                    { 5, "SP", "Jundiaí" },
                    { 6, "SP", "Hortolândia" }
                });

            migrationBuilder.InsertData(
                table: "TABELA_EDIFICIO",
                columns: new[] { "CODIGO_EDIFICIO", "ANDARES", "NOME_EDIFICIO", "NUMERO__APTO_ANDAR", "CODIGO_CIDADE" },
                values: new object[,]
                {
                    { 1, 5, "Edifício Esplanada", 4, 1 },
                    { 3, 5, "Edifício Sônia", 4, 1 },
                    { 6, 14, "Edifício Tiago", 4, 1 },
                    { 7, 15, "Edifício Sol", 2, 1 },
                    { 2, 10, "Edifício Vera", 3, 2 },
                    { 4, 7, "Edifício Tavares", 4, 3 },
                    { 5, 12, "Edifício Renata", 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "TABELA_APARTAMENTO",
                columns: new[] { "CODIGO_APARTAMENTO", "ANDAR", "METRAGEM", "NUMERO_QUARTOS", "CODIGO_EDIFICIO" },
                values: new object[,]
                {
                    { 1, 1, 100, 2, 1 },
                    { 2, 3, 98, 3, 1 },
                    { 3, 2, 120, 4, 1 },
                    { 4, 4, 120, 4, 1 },
                    { 5, 1, 100, 3, 1 },
                    { 6, 3, 90, 2, 1 },
                    { 7, 5, 150, 4, 1 },
                    { 8, 14, 200, 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "TABELA_PAGAMENTOS_CONDOMINIO",
                columns: new[] { "CODIGO_PAGAMENTOS_CONDOMINIO", "DATA_PAGAMENTO", "CODIGO_APARTAMENTO", "VALOR_PAGAMENTO" },
                values: new object[,]
                {
                    { 1, new DateTime(2011, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 450.0 },
                    { 2, new DateTime(2011, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 330.0 },
                    { 3, new DateTime(2011, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 250.0 },
                    { 7, new DateTime(2011, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 450.0 },
                    { 4, new DateTime(2011, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 110.0 },
                    { 8, new DateTime(2011, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 340.0 },
                    { 5, new DateTime(2011, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 220.0 },
                    { 9, new DateTime(2011, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 220.0 },
                    { 6, new DateTime(2011, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 540.0 }
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
