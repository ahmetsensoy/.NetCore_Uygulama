using Microsoft.EntityFrameworkCore.Migrations;

namespace EmlakOfisi.DataAccess.Migrations
{
    public partial class created2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AgentId",
                table: "Advertisements",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_AgentId",
                table: "Advertisements",
                column: "AgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_Agents_AgentId",
                table: "Advertisements",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_Agents_AgentId",
                table: "Advertisements");

            migrationBuilder.DropIndex(
                name: "IX_Advertisements_AgentId",
                table: "Advertisements");

            migrationBuilder.AlterColumn<int>(
                name: "AgentId",
                table: "Advertisements",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
