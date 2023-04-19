using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiGDS.Infraestructure.Migrations
{
    public partial class updatecontrato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contratos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Clase = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    ClienteName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contratos_Clientes_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_ClientId",
                table: "Contratos",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contratos");
        }
    }
}
