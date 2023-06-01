using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiGDS.Infraestructure.Migrations
{
    public partial class xd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actividades_Reporte_Tiempo_TimeReportId",
                table: "Actividades");

            migrationBuilder.AlterColumn<int>(
                name: "TimeReportId",
                table: "Actividades",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Actividades_Reporte_Tiempo_TimeReportId",
                table: "Actividades",
                column: "TimeReportId",
                principalTable: "Reporte_Tiempo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actividades_Reporte_Tiempo_TimeReportId",
                table: "Actividades");

            migrationBuilder.AlterColumn<int>(
                name: "TimeReportId",
                table: "Actividades",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Actividades_Reporte_Tiempo_TimeReportId",
                table: "Actividades",
                column: "TimeReportId",
                principalTable: "Reporte_Tiempo",
                principalColumn: "Id");
        }
    }
}
