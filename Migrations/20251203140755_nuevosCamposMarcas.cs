using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoCheck.Migrations
{
    /// <inheritdoc />
    public partial class nuevosCamposMarcas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PuntuacionAmbiental",
                table: "Marcas");

            migrationBuilder.DropColumn(
                name: "PuntuacionGobernanza",
                table: "Marcas");

            migrationBuilder.AddColumn<string>(
                name: "Controversias",
                table: "Marcas",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Marcas",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Controversias",
                table: "Marcas");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Marcas");

            migrationBuilder.AddColumn<float>(
                name: "PuntuacionAmbiental",
                table: "Marcas",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "PuntuacionGobernanza",
                table: "Marcas",
                type: "float",
                nullable: true);
        }
    }
}
