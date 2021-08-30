using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteSenior.Data.Migrations
{
    public partial class youko9994 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { 1, "Ureia" },
                    { 2, "Creatinina" },
                    { 3, "Urina 1" },
                    { 4, "Hemograma" },
                    { 5, "LDH" },
                    { 6, "Ácido Úrico" },
                    { 7, "HIV" },
                    { 8, "HBSAG" }
                });

            migrationBuilder.InsertData(
                table: "TABELA_EXAMES_STATUS",
                columns: new[] { "EXAMES_STATUS_ID", "EXAMES_STATUS_DESCRICAO" },
                values: new object[,]
                {
                    { 1, "Aguaradando liberação" },
                    { 2, "Liberado" },
                    { 3, "Enviado" }
                });

            migrationBuilder.InsertData(
                table: "TABELA_TIPO_EXAME",
                columns: new[] { "TIPO_EXAMES_ID", "TIPO_EXAME_DESCRICAO" },
                values: new object[,]
                {
                    { 1, "Interno" },
                    { 2, "Externo" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TABELA_COLETA",
                keyColumn: "COLETAS_ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TABELA_COLETA",
                keyColumn: "COLETAS_ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TABELA_COLETA",
                keyColumn: "COLETAS_ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TABELA_EXAMES",
                keyColumn: "EXAMES_ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TABELA_EXAMES",
                keyColumn: "EXAMES_ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TABELA_EXAMES",
                keyColumn: "EXAMES_ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TABELA_EXAMES",
                keyColumn: "EXAMES_ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TABELA_EXAMES",
                keyColumn: "EXAMES_ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TABELA_EXAMES",
                keyColumn: "EXAMES_ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TABELA_EXAMES",
                keyColumn: "EXAMES_ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TABELA_EXAMES",
                keyColumn: "EXAMES_ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TABELA_EXAMES_STATUS",
                keyColumn: "EXAMES_STATUS_ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TABELA_EXAMES_STATUS",
                keyColumn: "EXAMES_STATUS_ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TABELA_EXAMES_STATUS",
                keyColumn: "EXAMES_STATUS_ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TABELA_TIPO_EXAME",
                keyColumn: "TIPO_EXAMES_ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TABELA_TIPO_EXAME",
                keyColumn: "TIPO_EXAMES_ID",
                keyValue: 2);
        }
    }
}
