using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoCheck.Migrations
{
    /// <inheritdoc />
    public partial class quitarGobernanza : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gobernanza",
                table: "Puntuacion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Gobernanza",
                table: "Puntuacion",
                type: "float",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
