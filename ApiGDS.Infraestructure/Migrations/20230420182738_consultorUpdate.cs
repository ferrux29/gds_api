using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiGDS.Infraestructure.Migrations
{
    public partial class consultorUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contratos_Clientes_ClientId",
                table: "Contratos");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Contratos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Consultores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultores", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Contratos_Clientes_ClientId",
                table: "Contratos",
                column: "ClientId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contratos_Clientes_ClientId",
                table: "Contratos");

            migrationBuilder.DropTable(
                name: "Consultores");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Contratos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Contratos_Clientes_ClientId",
                table: "Contratos",
                column: "ClientId",
                principalTable: "Clientes",
                principalColumn: "Id");
        }
    }
}
