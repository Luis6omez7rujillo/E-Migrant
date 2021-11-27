using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistencia.Migrations
{
    public partial class dependenciaServicios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Servicios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
                    RazonSocial = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Nit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    PaginaWeb = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Servicios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
