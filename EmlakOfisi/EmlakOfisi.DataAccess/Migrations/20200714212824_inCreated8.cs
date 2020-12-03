using Microsoft.EntityFrameworkCore.Migrations;

namespace EmlakOfisi.DataAccess.Migrations
{
    public partial class inCreated8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "Agents",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "Agents");
        }
    }
}
