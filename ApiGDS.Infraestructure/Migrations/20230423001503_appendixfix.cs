using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiGDS.Infraestructure.Migrations
{
    public partial class appendixfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anexos_Contratos_ContractId",
                table: "Anexos");

            migrationBuilder.AlterColumn<int>(
                name: "ContractId",
                table: "Anexos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Anexos_Contratos_ContractId",
                table: "Anexos",
                column: "ContractId",
                principalTable: "Contratos",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anexos_Contratos_ContractId",
                table: "Anexos");

            migrationBuilder.AlterColumn<int>(
                name: "ContractId",
                table: "Anexos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Anexos_Contratos_ContractId",
                table: "Anexos",
                column: "ContractId",
                principalTable: "Contratos",
                principalColumn: "Id");
        }
    }
}
