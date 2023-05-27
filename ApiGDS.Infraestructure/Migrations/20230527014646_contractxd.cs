using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiGDS.Infraestructure.Migrations
{
    public partial class contractxd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_ServiceId",
                table: "Contratos",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contratos_Servicios_ServiceId",
                table: "Contratos",
                column: "ServiceId",
                principalTable: "Servicios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contratos_Servicios_ServiceId",
                table: "Contratos");

            migrationBuilder.DropIndex(
                name: "IX_Contratos_ServiceId",
                table: "Contratos");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Contratos");

            migrationBuilder.DropColumn(
                name: "ServiceName",
                table: "Contratos");
        }
    }
}
