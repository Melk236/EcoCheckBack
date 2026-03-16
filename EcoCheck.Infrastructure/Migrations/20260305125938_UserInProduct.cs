using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoCheck.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserInProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Producto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Producto_UsuarioId",
                table: "Producto",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Users_UsuarioId",
                table: "Producto",
                column: "UsuarioId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Users_UsuarioId",
                table: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_Producto_UsuarioId",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Producto");
        }
    }
}
