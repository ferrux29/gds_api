using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiGDS.Infraestructure.Migrations
{
    public partial class ReportUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HorasEntrenamiento",
                table: "Reporte_Tiempo");

            migrationBuilder.DropColumn(
                name: "HorasFeriadoFacturable",
                table: "Reporte_Tiempo");

            migrationBuilder.DropColumn(
                name: "HorasFeriadoNoFacturable",
                table: "Reporte_Tiempo");

            migrationBuilder.DropColumn(
                name: "HorasFeriadoOficina",
                table: "Reporte_Tiempo");

            migrationBuilder.DropColumn(
                name: "HorasNormalesFacturables",
                table: "Reporte_Tiempo");

            migrationBuilder.DropColumn(
                name: "HorasNormalesNoFacturables",
                table: "Reporte_Tiempo");

            migrationBuilder.DropColumn(
                name: "HorasNormalesOficina",
                table: "Reporte_Tiempo");

            migrationBuilder.DropColumn(
                name: "HorasPermisoEnfermedad",
                table: "Reporte_Tiempo");

            migrationBuilder.DropColumn(
                name: "HorasVacaciones",
                table: "Reporte_Tiempo");

            migrationBuilder.RenameColumn(
                name: "Week",
                table: "Reporte_Tiempo",
                newName: "Serial");

            migrationBuilder.RenameColumn(
                name: "Total",
                table: "Reporte_Tiempo",
                newName: "Horas");

            migrationBuilder.RenameColumn(
                name: "HorasViajeNoFacturable",
                table: "Reporte_Tiempo",
                newName: "ActivityId");

            migrationBuilder.RenameColumn(
                name: "HorasViajeFacturable",
                table: "Reporte_Tiempo",
                newName: "ActivityCode");

            migrationBuilder.AddColumn<string>(
                name: "FirmaCliente",
                table: "Reporte_Tiempo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirmaEmpleado",
                table: "Reporte_Tiempo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reporte_Tiempo_Actividades_ActivityId",
                table: "Reporte_Tiempo");

            migrationBuilder.DropIndex(
                name: "IX_Reporte_Tiempo_ActivityId",
                table: "Reporte_Tiempo");

            migrationBuilder.DropColumn(
                name: "FirmaCliente",
                table: "Reporte_Tiempo");

            migrationBuilder.DropColumn(
                name: "FirmaEmpleado",
                table: "Reporte_Tiempo");

            migrationBuilder.RenameColumn(
                name: "Serial",
                table: "Reporte_Tiempo",
                newName: "Week");

            migrationBuilder.RenameColumn(
                name: "Horas",
                table: "Reporte_Tiempo",
                newName: "Total");

            migrationBuilder.RenameColumn(
                name: "ActivityId",
                table: "Reporte_Tiempo",
                newName: "HorasViajeNoFacturable");

            migrationBuilder.RenameColumn(
                name: "ActivityCode",
                table: "Reporte_Tiempo",
                newName: "HorasViajeFacturable");

            migrationBuilder.AddColumn<int>(
                name: "HorasEntrenamiento",
                table: "Reporte_Tiempo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HorasFeriadoFacturable",
                table: "Reporte_Tiempo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HorasFeriadoNoFacturable",
                table: "Reporte_Tiempo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HorasFeriadoOficina",
                table: "Reporte_Tiempo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HorasNormalesFacturables",
                table: "Reporte_Tiempo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HorasNormalesNoFacturables",
                table: "Reporte_Tiempo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HorasNormalesOficina",
                table: "Reporte_Tiempo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HorasPermisoEnfermedad",
                table: "Reporte_Tiempo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HorasVacaciones",
                table: "Reporte_Tiempo",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
