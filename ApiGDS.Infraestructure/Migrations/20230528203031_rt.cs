using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiGDS.Infraestructure.Migrations
{
    public partial class rt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
