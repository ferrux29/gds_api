using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiGDS.Infraestructure.Migrations
{
    public partial class rtlist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reporte_Tiempo_Actividades_ActivityId",
                table: "Reporte_Tiempo");

            migrationBuilder.DropIndex(
                name: "IX_Reporte_Tiempo_ActivityId",
                table: "Reporte_Tiempo");

            migrationBuilder.DropColumn(
                name: "ActivityCode",
                table: "Reporte_Tiempo");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "Reporte_Tiempo");

            migrationBuilder.AddColumn<int>(
                name: "TimeReportId",
                table: "Actividades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_TimeReportId",
                table: "Actividades",
                column: "TimeReportId");

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

            migrationBuilder.DropIndex(
                name: "IX_Actividades_TimeReportId",
                table: "Actividades");

            migrationBuilder.DropColumn(
                name: "TimeReportId",
                table: "Actividades");

            migrationBuilder.AddColumn<int>(
                name: "ActivityCode",
                table: "Reporte_Tiempo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ActivityId",
                table: "Reporte_Tiempo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reporte_Tiempo_ActivityId",
                table: "Reporte_Tiempo",
                column: "ActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reporte_Tiempo_Actividades_ActivityId",
                table: "Reporte_Tiempo",
                column: "ActivityId",
                principalTable: "Actividades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
