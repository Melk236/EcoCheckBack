using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoCheck.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CampoImagenEnUserNuevoNombre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Imagen",
                table: "Users",
                newName: "UrlImagen");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UrlImagen",
                table: "Users",
                newName: "Imagen");
        }
    }
}
