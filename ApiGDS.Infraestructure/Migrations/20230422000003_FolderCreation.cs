using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiGDS.Infraestructure.Migrations
{
    public partial class FolderCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carpetas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContratoId = table.Column<int>(type: "int", nullable: false),
                    ContratoName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppendixId = table.Column<int>(type: "int", nullable: false),
                    AppendixName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carpetas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carpetas_Anexos_AppendixId",
                        column: x => x.AppendixId,
                        principalTable: "Anexos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Carpetas_Clientes_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Carpetas_Contratos_ContratoId",
                        column: x => x.ContratoId,
                        principalTable: "Contratos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carpetas_AppendixId",
                table: "Carpetas",
                column: "AppendixId");

            migrationBuilder.CreateIndex(
                name: "IX_Carpetas_ClientId",
                table: "Carpetas",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Carpetas_ContratoId",
                table: "Carpetas",
                column: "ContratoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carpetas");
        }
    }
}
