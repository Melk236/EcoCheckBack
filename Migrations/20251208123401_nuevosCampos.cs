using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoCheck.Migrations
{
    /// <inheritdoc />
    public partial class nuevosCampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Certificaciones",
                table: "Marcas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Certificaciones",
                table: "Marcas",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
