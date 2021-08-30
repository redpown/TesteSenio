using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteSenior.Data.Migrations
{
    public partial class youko9993 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TABELA_EXAMES_STATUS",
                keyColumn: "EXAMES_STATUS_ID",
                keyValue: 1,
                column: "EXAMES_STATUS_DESCRICAO",
                value: "Aguaradando Liberação");

            migrationBuilder.InsertData(
                table: "TABELA_QUALIDADEMETRICAS",
                columns: new[] { "QM_ID", "QM_COLETA_ID", "QM_DATA", "QM_EXAME_ID", "QM_EXAME_STATUS_ID", "QM_QUANTIDADE", "QN_TIPO", "QM_TOTAL" },
                values: new object[] { 1, 1, new DateTime(2021, 8, 29, 20, 38, 56, 873, DateTimeKind.Local).AddTicks(9958), 1, 1, 1, 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TABELA_QUALIDADEMETRICAS",
                keyColumn: "QM_ID",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "TABELA_EXAMES_STATUS",
                keyColumn: "EXAMES_STATUS_ID",
                keyValue: 1,
                column: "EXAMES_STATUS_DESCRICAO",
                value: "Aguaradando liberação");
        }
    }
}
