using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Samuel_Duran_Ap1_PF.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Almacenes",
                columns: table => new
                {
                    AlmacenId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreCentro = table.Column<string>(type: "TEXT", nullable: false),
                    DenominacionCentro = table.Column<string>(type: "TEXT", nullable: false),
                    NombreAlmacen = table.Column<string>(type: "TEXT", nullable: false),
                    DenominacionAlmacen = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Almacenes", x => x.AlmacenId);
                });

            migrationBuilder.CreateTable(
                name: "Materiales",
                columns: table => new
                {
                    MaterialId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", maxLength: 35, nullable: false),
                    UnidadesMedida = table.Column<string>(type: "TEXT", nullable: false),
                    Cantidad = table.Column<decimal>(type: "TEXT", nullable: false),
                    Costo = table.Column<decimal>(type: "TEXT", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materiales", x => x.MaterialId);
                });

            migrationBuilder.CreateTable(
                name: "Transportistas",
                columns: table => new
                {
                    TransportistaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    Apellidos = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    NumeroCarnet = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportistas", x => x.TransportistaId);
                });

            migrationBuilder.CreateTable(
                name: "EntradasAlmacenes",
                columns: table => new
                {
                    EntradaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FechaEntrada = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Operario = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    TransportistaId = table.Column<int>(type: "INTEGER", nullable: false),
                    AlmacenOrigenAlmacenId = table.Column<int>(type: "INTEGER", nullable: false),
                    PrecioTotal = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntradasAlmacenes", x => x.EntradaId);
                    table.ForeignKey(
                        name: "FK_EntradasAlmacenes_Almacenes_AlmacenOrigenAlmacenId",
                        column: x => x.AlmacenOrigenAlmacenId,
                        principalTable: "Almacenes",
                        principalColumn: "AlmacenId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntradasAlmacenes_Transportistas_TransportistaId",
                        column: x => x.TransportistaId,
                        principalTable: "Transportistas",
                        principalColumn: "TransportistaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaterialesRecibidos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cantidad = table.Column<decimal>(type: "TEXT", nullable: false),
                    EntradaId = table.Column<int>(type: "INTEGER", nullable: false),
                    MaterialId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialesRecibidos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MaterialesRecibidos_EntradasAlmacenes_EntradaId",
                        column: x => x.EntradaId,
                        principalTable: "EntradasAlmacenes",
                        principalColumn: "EntradaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialesRecibidos_Materiales_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materiales",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Almacenes",
                columns: new[] { "AlmacenId", "DenominacionAlmacen", "DenominacionCentro", "NombreAlmacen", "NombreCentro" },
                values: new object[] { 1, "San Francisco", "San Francisco - Edenorte", "N301", "N300" });

            migrationBuilder.InsertData(
                table: "Almacenes",
                columns: new[] { "AlmacenId", "DenominacionAlmacen", "DenominacionCentro", "NombreAlmacen", "NombreCentro" },
                values: new object[] { 2, "Santiago", "Santiago - Edenorte", "N101", "N100" });

            migrationBuilder.InsertData(
                table: "Almacenes",
                columns: new[] { "AlmacenId", "DenominacionAlmacen", "DenominacionCentro", "NombreAlmacen", "NombreCentro" },
                values: new object[] { 3, "Puerto plata", "Puerto Plata - Edenorte", "N401", "N400" });

            migrationBuilder.InsertData(
                table: "Almacenes",
                columns: new[] { "AlmacenId", "DenominacionAlmacen", "DenominacionCentro", "NombreAlmacen", "NombreCentro" },
                values: new object[] { 4, "Mao", "Mao- Edenorte", "N501", "N500" });

            migrationBuilder.InsertData(
                table: "Almacenes",
                columns: new[] { "AlmacenId", "DenominacionAlmacen", "DenominacionCentro", "NombreAlmacen", "NombreCentro" },
                values: new object[] { 5, "La vega", "La vega - Edenorte", "N601", "N600" });

            migrationBuilder.CreateIndex(
                name: "IX_EntradasAlmacenes_AlmacenOrigenAlmacenId",
                table: "EntradasAlmacenes",
                column: "AlmacenOrigenAlmacenId");

            migrationBuilder.CreateIndex(
                name: "IX_EntradasAlmacenes_TransportistaId",
                table: "EntradasAlmacenes",
                column: "TransportistaId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialesRecibidos_EntradaId",
                table: "MaterialesRecibidos",
                column: "EntradaId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialesRecibidos_MaterialId",
                table: "MaterialesRecibidos",
                column: "MaterialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialesRecibidos");

            migrationBuilder.DropTable(
                name: "EntradasAlmacenes");

            migrationBuilder.DropTable(
                name: "Materiales");

            migrationBuilder.DropTable(
                name: "Almacenes");

            migrationBuilder.DropTable(
                name: "Transportistas");
        }
    }
}
