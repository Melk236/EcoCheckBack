using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoCheck.Migrations
{
    /// <inheritdoc />
    public partial class EmpresaCertificacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmpresaCertificacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MarcaId = table.Column<int>(type: "int", nullable: false),
                    CertificacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaCertificacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpresaCertificacion_Certificaciones_CertificacionId",
                        column: x => x.CertificacionId,
                        principalTable: "Certificaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpresaCertificacion_Marcas_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaCertificacion_CertificacionId",
                table: "EmpresaCertificacion",
                column: "CertificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaCertificacion_MarcaId",
                table: "EmpresaCertificacion",
                column: "MarcaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpresaCertificacion");
        }
    }
}
