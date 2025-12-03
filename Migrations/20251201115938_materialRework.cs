using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoCheck.Migrations
{
    /// <inheritdoc />
    public partial class materialRework : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Origen",
                table: "Material");

            migrationBuilder.DropColumn(
                name: "Porcentaje",
                table: "Material");

            migrationBuilder.AddColumn<bool>(
                name: "Reciclable",
                table: "Material",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reciclable",
                table: "Material");

            migrationBuilder.AddColumn<string>(
                name: "Origen",
                table: "Material",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<float>(
                name: "Porcentaje",
                table: "Material",
                type: "float",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
