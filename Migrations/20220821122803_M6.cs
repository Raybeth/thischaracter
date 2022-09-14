using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace finalproject.Migrations
{
    public partial class M6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Serie",
                table: "Personajes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Serie",
                table: "Personajes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
