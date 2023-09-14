using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto.Data.Migrations
{
    public partial class Migracion1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id_Cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DNI = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    FiguraPublica = table.Column<bool>(type: "bit", nullable: false),
                    Reputacion = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id_Cliente);
                });

            migrationBuilder.CreateTable(
                name: "ClienteFinanza",
                columns: table => new
                {
                    Id_Cliente_Finanza = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    INFOCORP = table.Column<bool>(type: "bit", nullable: false),
                    ActividadDeCuenta = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TrabajoFijo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IngresoMensual = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Fk_Cliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteFinanza", x => x.Id_Cliente_Finanza);
                });

            migrationBuilder.CreateTable(
                name: "Transaccion",
                columns: table => new
                {
                    Id_Transaccion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaMonto = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MontoTransaccion = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    OrigenDeFondos = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    AgenciaZona = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    LavadoDeActivo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Fk_Cliente_Finanza = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaccion", x => x.Id_Transaccion);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "ClienteFinanza");

            migrationBuilder.DropTable(
                name: "Transaccion");
        }
    }
}
