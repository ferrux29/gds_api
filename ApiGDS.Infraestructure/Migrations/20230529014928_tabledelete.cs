using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiGDS.Infraestructure.Migrations
{
    public partial class tabledelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReporteActividad");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReporteActividad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    TimeReportId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReporteActividad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReporteActividad_Actividades_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Actividades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReporteActividad_Reporte_Tiempo_TimeReportId",
                        column: x => x.TimeReportId,
                        principalTable: "Reporte_Tiempo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReporteActividad_ActivityId",
                table: "ReporteActividad",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ReporteActividad_TimeReportId",
                table: "ReporteActividad",
                column: "TimeReportId");
        }
    }
}
