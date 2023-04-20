using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiGDS.Infraestructure.Migrations
{
    public partial class billUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConsultantId = table.Column<int>(type: "int", nullable: false),
                    ConsultantName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppendixId = table.Column<int>(type: "int", nullable: false),
                    AppendixMontoFacturado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facturas_Anexos_AppendixId",
                        column: x => x.AppendixId,
                        principalTable: "Anexos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Facturas_Clientes_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Facturas_Consultores_ConsultantId",
                        column: x => x.ConsultantId,
                        principalTable: "Consultores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Facturas");
        }
    }
}
