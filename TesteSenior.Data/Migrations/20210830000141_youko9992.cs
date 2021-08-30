using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteSenior.Data.Migrations
{
    public partial class youko9992 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "QM_DATA",
                table: "TABELA_QUALIDADEMETRICAS",
                type: "date",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldMaxLength: 256);

            migrationBuilder.UpdateData(
                table: "TABELA_QUALIDADEMETRICAS",
                keyColumn: "QM_ID",
                keyValue: 1,
                column: "QM_DATA",
                value: new DateTime(2011, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "TABELA_QUALIDADEMETRICAS",
                columns: new[] { "QM_ID", "QM_COLETA_ID", "QM_DATA", "QM_EXAME_ID", "QM_EXAME_STATUS_ID", "QM_QUANTIDADE", "QN_TIPO", "QM_TOTAL" },
                values: new object[] { 2, 2, new DateTime(2015, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 2, 2, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TABELA_QUALIDADEMETRICAS",
                keyColumn: "QM_ID",
                keyValue: 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "QM_DATA",
                table: "TABELA_QUALIDADEMETRICAS",
                type: "datetime2",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldMaxLength: 256);

            migrationBuilder.UpdateData(
                table: "TABELA_QUALIDADEMETRICAS",
                keyColumn: "QM_ID",
                keyValue: 1,
                column: "QM_DATA",
                value: new DateTime(2021, 8, 29, 20, 38, 56, 873, DateTimeKind.Local).AddTicks(9958));
        }
    }
}
