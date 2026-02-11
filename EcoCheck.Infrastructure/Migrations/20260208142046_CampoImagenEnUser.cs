using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoCheck.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CampoImagenEnUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Imagen",
                table: "Users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Puntuacion_ProductoId",
                table: "Puntuacion",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Puntuacion_Producto_ProductoId",
                table: "Puntuacion",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Puntuacion_Producto_ProductoId",
                table: "Puntuacion");

            migrationBuilder.DropIndex(
                name: "IX_Puntuacion_ProductoId",
                table: "Puntuacion");

            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "Users");
        }
    }
}
