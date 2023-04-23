using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiGDS.Infraestructure.Migrations
{
    public partial class RTCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reporte_Tiempo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConsultantId = table.Column<int>(type: "int", nullable: false),
                    ConsultantName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppendixId = table.Column<int>(type: "int", nullable: false),
                    AppendixName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Week = table.Column<int>(type: "int", nullable: false),
                    HorasNormalesFacturables = table.Column<int>(type: "int", nullable: false),
                    HorasNormalesNoFacturables = table.Column<int>(type: "int", nullable: false),
                    HorasNormalesOficina = table.Column<int>(type: "int", nullable: false),
                    HorasEntrenamiento = table.Column<int>(type: "int", nullable: false),
                    HorasPermisoEnfermedad = table.Column<int>(type: "int", nullable: false),
                    HorasVacaciones = table.Column<int>(type: "int", nullable: false),
                    HorasFeriadoFacturable = table.Column<int>(type: "int", nullable: false),
                    HorasFeriadoNoFacturable = table.Column<int>(type: "int", nullable: false),
                    HorasFeriadoOficina = table.Column<int>(type: "int", nullable: false),
                    HorasViajeFacturable = table.Column<int>(type: "int", nullable: false),
                    HorasViajeNoFacturable = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    Obersavciones = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reporte_Tiempo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reporte_Tiempo_Anexos_AppendixId",
                        column: x => x.AppendixId,
                        principalTable: "Anexos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Reporte_Tiempo_Clientes_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Reporte_Tiempo_Consultores_ConsultantId",
                        column: x => x.ConsultantId,
                        principalTable: "Consultores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reporte_Tiempo_AppendixId",
                table: "Reporte_Tiempo",
                column: "AppendixId");

            migrationBuilder.CreateIndex(
                name: "IX_Reporte_Tiempo_ClientId",
                table: "Reporte_Tiempo",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Reporte_Tiempo_ConsultantId",
                table: "Reporte_Tiempo",
                column: "ConsultantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reporte_Tiempo");
        }
    }
}
