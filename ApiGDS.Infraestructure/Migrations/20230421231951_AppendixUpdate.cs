using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiGDS.Infraestructure.Migrations
{
    public partial class AppendixUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Anexos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ClientName",
                table: "Anexos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Anexos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Anexos_ClientId",
                table: "Anexos",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Anexos_Clientes_ClientId",
                table: "Anexos",
                column: "ClientId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anexos_Clientes_ClientId",
                table: "Anexos");

            migrationBuilder.DropIndex(
                name: "IX_Anexos_ClientId",
                table: "Anexos");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Anexos");

            migrationBuilder.DropColumn(
                name: "ClientName",
                table: "Anexos");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Anexos");
        }
    }
}
