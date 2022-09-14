using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace finalproject.Migrations
{
    public partial class M2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Series_Personajes_PersonajeId",
                table: "Series");

            migrationBuilder.DropIndex(
                name: "IX_Series_PersonajeId",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "PersonajeId",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Personajes");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Personajes");

            migrationBuilder.DropColumn(
                name: "Serie",
                table: "Personajes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonajeId",
                table: "Series",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Personajes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Personajes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Serie",
                table: "Personajes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Series_PersonajeId",
                table: "Series",
                column: "PersonajeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Series_Personajes_PersonajeId",
                table: "Series",
                column: "PersonajeId",
                principalTable: "Personajes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
