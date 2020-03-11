using Microsoft.EntityFrameworkCore.Migrations;

namespace Parcial2_PA2.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Llamadas",
                columns: table => new
                {
                    LlamadaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Llamadas", x => x.LlamadaId);
                });

            migrationBuilder.CreateTable(
                name: "LlamadaDetalles",
                columns: table => new
                {
                    LlamadaDetalleId = table.Column<int>(nullable: false),
                    Problemas = table.Column<string>(nullable: true),
                    Solucion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LlamadaDetalles", x => x.LlamadaDetalleId);
                    table.ForeignKey(
                        name: "FK_LlamadaDetalles_Llamadas_LlamadaDetalleId",
                        column: x => x.LlamadaDetalleId,
                        principalTable: "Llamadas",
                        principalColumn: "LlamadaId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LlamadaDetalles");

            migrationBuilder.DropTable(
                name: "Llamadas");
        }
    }
}
