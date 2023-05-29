using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiGDS.Infraestructure.Migrations
{
    public partial class appendixContractfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anexos_Clientes_ClientId",
                table: "Anexos");

            migrationBuilder.DropForeignKey(
                name: "FK_Contratos_Servicios_ServiceId",
                table: "Contratos");

            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropIndex(
                name: "IX_Contratos_ServiceId",
                table: "Contratos");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Contratos");

            migrationBuilder.DropColumn(
                name: "ServiceName",
                table: "Contratos");

            migrationBuilder.DropColumn(
                name: "ClientName",
                table: "Anexos");

            migrationBuilder.RenameColumn(
                name: "MontoFacturado",
                table: "Anexos",
                newName: "ServiceName");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Anexos",
                newName: "ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Anexos_ClientId",
                table: "Anexos",
                newName: "IX_Anexos_ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Anexos_Servicios_ServiceId",
                table: "Anexos",
                column: "ServiceId",
                principalTable: "Servicios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anexos_Servicios_ServiceId",
                table: "Anexos");

            migrationBuilder.RenameColumn(
                name: "ServiceName",
                table: "Anexos",
                newName: "MontoFacturado");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "Anexos",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Anexos_ServiceId",
                table: "Anexos",
                newName: "IX_Anexos_ClientId");

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Contratos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ServiceName",
                table: "Contratos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClientName",
                table: "Anexos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppendixId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    ConsultantId = table.Column<int>(type: "int", nullable: false),
                    AppendixMontoFacturado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConsultantName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facturas_Anexos_AppendixId",
                        column: x => x.AppendixId,
                        principalTable: "Anexos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Facturas_Clientes_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Facturas_Consultores_ConsultantId",
                        column: x => x.ConsultantId,
                        principalTable: "Consultores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_ServiceId",
                table: "Contratos",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_AppendixId",
                table: "Facturas",
                column: "AppendixId");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_ClientId",
                table: "Facturas",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_ConsultantId",
                table: "Facturas",
                column: "ConsultantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Anexos_Clientes_ClientId",
                table: "Anexos",
                column: "ClientId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contratos_Servicios_ServiceId",
                table: "Contratos",
                column: "ServiceId",
                principalTable: "Servicios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
