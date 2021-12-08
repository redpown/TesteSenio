using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteSenior.Data.Migrations
{
    public partial class youko : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    table.PrimaryKey("CODIGO_CIDADE_ID", x => x.CODIGO_CIDADE);
                });

            migrationBuilder.CreateTable(
                name: "TABELA_COLETA",
                columns: table => new
                {
                    COLETAS_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COLETA_DESCRICAO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("COLETA_IDS", x => x.COLETAS_ID);
                });

            migrationBuilder.CreateTable(
                name: "TABELA_EXAMES",
                columns: table => new
                {
                    EXAMES_ID = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EXAME_DESCRICAO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("EXAMES_IDS", x => x.EXAMES_ID);
                });

            migrationBuilder.CreateTable(
                name: "TABELA_EXAMES_STATUS",
                columns: table => new
                {
                    EXAMES_STATUS_ID = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EXAMES_STATUS_DESCRICAO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("EXAMES_STATUS_IDS", x => x.EXAMES_STATUS_ID);
                });

            migrationBuilder.CreateTable(
                name: "TABELA_TIPO_EXAME",
                columns: table => new
                {
                    TIPO_EXAMES_ID = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TIPO_EXAME_DESCRICAO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("TIPO_EXAME_IDS", x => x.TIPO_EXAMES_ID);
                });

            migrationBuilder.CreateTable(
                name: "TABELA_USUARIOS",
                columns: table => new
                {
                    USUARIO_ID = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USUARIO_NOME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    USUARIO_EMAIL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    USUARIO_SENHA = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    USUARIO_PERFIL = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("USUARIO_IDS", x => x.USUARIO_ID);
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
                    table.PrimaryKey("CODIGO_EDIFICIO_ID", x => x.CODIGO_EDIFICIO);
                    table.ForeignKey(
                        name: "FK_TABELA_EDIFICIO_TABELA_CIDADE_CODIGO_CIDADE",
                        column: x => x.CODIGO_CIDADE,
                        principalTable: "TABELA_CIDADE",
                        principalColumn: "CODIGO_CIDADE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TABELA_QUALIDADEMETRICAS",
                columns: table => new
                {
                    QM_ID = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QM_TOTAL = table.Column<int>(type: "int", maxLength: 256, nullable: false),
                    QM_EXAME_ID = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    QM_QUANTIDADE = table.Column<int>(type: "int", maxLength: 256, nullable: false),
                    QM_COLETA_ID = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    QM_TIPO = table.Column<int>(type: "int", maxLength: 256, nullable: false),
                    QM_EXAME_STATUS_ID = table.Column<int>(type: "int", maxLength: 256, nullable: false),
                    QM_DATA = table.Column<DateTime>(type: "date", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("QUALIDADEMETRICAS_IDS", x => x.QM_ID);
                    table.ForeignKey(
                        name: "FK_TABELA_QUALIDADEMETRICAS_TABELA_COLETA_QM_COLETA_ID",
                        column: x => x.QM_COLETA_ID,
                        principalTable: "TABELA_COLETA",
                        principalColumn: "COLETAS_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TABELA_QUALIDADEMETRICAS_TABELA_EXAMES_QM_EXAME_ID",
                        column: x => x.QM_EXAME_ID,
                        principalTable: "TABELA_EXAMES",
                        principalColumn: "EXAMES_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TABELA_QUALIDADEMETRICAS_TABELA_EXAMES_STATUS_QM_EXAME_STATUS_ID",
                        column: x => x.QM_EXAME_STATUS_ID,
                        principalTable: "TABELA_EXAMES_STATUS",
                        principalColumn: "EXAMES_STATUS_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TABELA_QUALIDADEMETRICAS_TABELA_TIPO_EXAME_QM_TIPO",
                        column: x => x.QM_TIPO,
                        principalTable: "TABELA_TIPO_EXAME",
                        principalColumn: "TIPO_EXAMES_ID",
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
                    table.PrimaryKey("CODIGO_APARTAMENTO_ID", x => x.CODIGO_APARTAMENTO);
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
                    { 6, "SP", "Hortolândia" },
                    { 4, "SP", "Sorocaba" },
                    { 3, "SP", "São Paulo" },
                    { 2, "RJ", "Rio de Janeiro" },
                    { 1, "SP", "Campinas" },
                    { 5, "SP", "Jundiaí" }
                });

            migrationBuilder.InsertData(
                table: "TABELA_COLETA",
                columns: new[] { "COLETAS_ID", "COLETA_DESCRICAO" },
                values: new object[,]
                {
                    { 1, "Recebido" },
                    { 2, "Recoleta" },
                    { 3, "Não Coletado" }
                });

            migrationBuilder.InsertData(
                table: "TABELA_EXAMES",
                columns: new[] { "EXAMES_ID", "EXAME_DESCRICAO" },
                values: new object[,]
                {
                    { 2, "Creatinina" },
                    { 1, "Ureia" },
                    { 8, "HBSAG" },
                    { 6, "Ácido Úrico" },
                    { 5, "LDH" },
                    { 4, "Hemograma" },
                    { 3, "Urina 1" },
                    { 7, "HIV" }
                });

            migrationBuilder.InsertData(
                table: "TABELA_EXAMES_STATUS",
                columns: new[] { "EXAMES_STATUS_ID", "EXAMES_STATUS_DESCRICAO" },
                values: new object[,]
                {
                    { 3, "Enviado" },
                    { 2, "Liberado" },
                    { 1, "Aguaradando Liberação" }
                });

            migrationBuilder.InsertData(
                table: "TABELA_TIPO_EXAME",
                columns: new[] { "TIPO_EXAMES_ID", "TIPO_EXAME_DESCRICAO" },
                values: new object[,]
                {
                    { 1, "Interno" },
                    { 2, "Externo" }
                });

            migrationBuilder.InsertData(
                table: "TABELA_USUARIOS",
                columns: new[] { "USUARIO_ID", "USUARIO_EMAIL", "USUARIO_NOME", "USUARIO_PERFIL", "USUARIO_SENHA" },
                values: new object[,]
                {
                    { 1, "teste@teste.com", "andre", "1", "1234" },
                    { 2, "teste@teste.com", "youko", "2", "1234" }
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
                table: "TABELA_QUALIDADEMETRICAS",
                columns: new[] { "QM_ID", "QM_COLETA_ID", "QM_DATA", "QM_EXAME_ID", "QM_EXAME_STATUS_ID", "QM_QUANTIDADE", "QM_TIPO", "QM_TOTAL" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2011, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1, 1, 1 },
                    { 2, 2, new DateTime(2015, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 2, 2, 2 }
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

            migrationBuilder.CreateIndex(
                name: "IX_TABELA_QUALIDADEMETRICAS_QM_COLETA_ID",
                table: "TABELA_QUALIDADEMETRICAS",
                column: "QM_COLETA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TABELA_QUALIDADEMETRICAS_QM_EXAME_ID",
                table: "TABELA_QUALIDADEMETRICAS",
                column: "QM_EXAME_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TABELA_QUALIDADEMETRICAS_QM_EXAME_STATUS_ID",
                table: "TABELA_QUALIDADEMETRICAS",
                column: "QM_EXAME_STATUS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TABELA_QUALIDADEMETRICAS_QM_TIPO",
                table: "TABELA_QUALIDADEMETRICAS",
                column: "QM_TIPO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TABELA_PAGAMENTOS_CONDOMINIO");

            migrationBuilder.DropTable(
                name: "TABELA_QUALIDADEMETRICAS");

            migrationBuilder.DropTable(
                name: "TABELA_USUARIOS");

            migrationBuilder.DropTable(
                name: "TABELA_APARTAMENTO");

            migrationBuilder.DropTable(
                name: "TABELA_COLETA");

            migrationBuilder.DropTable(
                name: "TABELA_EXAMES");

            migrationBuilder.DropTable(
                name: "TABELA_EXAMES_STATUS");

            migrationBuilder.DropTable(
                name: "TABELA_TIPO_EXAME");

            migrationBuilder.DropTable(
                name: "TABELA_EDIFICIO");

            migrationBuilder.DropTable(
                name: "TABELA_CIDADE");
        }
    }
}
