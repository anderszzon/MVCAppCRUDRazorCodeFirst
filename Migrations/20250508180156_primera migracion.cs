using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCAppCRUDRazorCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class primeramigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atletlas",
                columns: table => new
                {
                    IdAtleta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AtletaName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AtletaType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaContrato = table.Column<DateOnly>(type: "date", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atletlas", x => x.IdAtleta);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atletlas");
        }
    }
}
