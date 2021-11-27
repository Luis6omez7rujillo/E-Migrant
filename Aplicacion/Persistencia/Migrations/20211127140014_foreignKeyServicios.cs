using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistencia.Migrations
{
    public partial class foreignKeyServicios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicios_EntidadColaboradora_RazonSocialId",
                table: "Servicios");

            migrationBuilder.DropTable(
                name: "EntidadColaboradora");

            migrationBuilder.DropIndex(
                name: "IX_Servicios_RazonSocialId",
                table: "Servicios");

            migrationBuilder.DropColumn(
                name: "RazonSocialId",
                table: "Servicios");

            migrationBuilder.AddColumn<int>(
                name: "EntidadId",
                table: "Servicios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntidadId",
                table: "Servicios");

            migrationBuilder.AddColumn<int>(
                name: "RazonSocialId",
                table: "Servicios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EntidadColaboradora",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ciudad = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Nit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaginaWeb = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RazonSocial = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Sector = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    TipoServicios = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntidadColaboradora", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_RazonSocialId",
                table: "Servicios",
                column: "RazonSocialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicios_EntidadColaboradora_RazonSocialId",
                table: "Servicios",
                column: "RazonSocialId",
                principalTable: "EntidadColaboradora",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
