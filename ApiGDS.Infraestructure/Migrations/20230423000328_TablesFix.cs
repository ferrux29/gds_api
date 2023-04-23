using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiGDS.Infraestructure.Migrations
{
    public partial class TablesFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carpetas");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Contratos");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Anexos",
                newName: "ProjectName");

            migrationBuilder.AlterColumn<float>(
                name: "MontoMax",
                table: "Contratos",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "Fianza",
                table: "Contratos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Assignment",
                table: "Anexos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ContractId",
                table: "Anexos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Anexos_ContractId",
                table: "Anexos",
                column: "ContractId");

            migrationBuilder.AddForeignKey(
                name: "FK_Anexos_Contratos_ContractId",
                table: "Anexos",
                column: "ContractId",
                principalTable: "Contratos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anexos_Contratos_ContractId",
                table: "Anexos");

            migrationBuilder.DropIndex(
                name: "IX_Anexos_ContractId",
                table: "Anexos");

            migrationBuilder.DropColumn(
                name: "Fianza",
                table: "Contratos");

            migrationBuilder.DropColumn(
                name: "Assignment",
                table: "Anexos");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "Anexos");

            migrationBuilder.RenameColumn(
                name: "ProjectName",
                table: "Anexos",
                newName: "Name");

            migrationBuilder.AlterColumn<int>(
                name: "MontoMax",
                table: "Contratos",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Contratos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Carpetas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppendixId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    ContratoId = table.Column<int>(type: "int", nullable: false),
                    AppendixName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContratoName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carpetas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carpetas_Anexos_AppendixId",
                        column: x => x.AppendixId,
                        principalTable: "Anexos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carpetas_Clientes_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carpetas_Contratos_ContratoId",
                        column: x => x.ContratoId,
                        principalTable: "Contratos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
    }
}
