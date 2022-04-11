using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Samuel_Duran_Ap1_PF.Migrations
{
    public partial class inicial : Migration
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
                    DenominacionCentro = table.Column<string>(type: "TEXT", nullable: false)
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
                    ValorInventario = table.Column<decimal>(type: "TEXT", nullable: false),
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
                name: "SalidasAlmacen",
                columns: table => new
                {
                    SalidaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FechaSalida = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TransportistaId = table.Column<int>(type: "INTEGER", nullable: false),
                    CostoTotal = table.Column<decimal>(type: "TEXT", nullable: false),
                    AlmacenDestinoAlmacenId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalidasAlmacen", x => x.SalidaId);
                    table.ForeignKey(
                        name: "FK_SalidasAlmacen_Almacenes_AlmacenDestinoAlmacenId",
                        column: x => x.AlmacenDestinoAlmacenId,
                        principalTable: "Almacenes",
                        principalColumn: "AlmacenId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalidasAlmacen_Transportistas_TransportistaId",
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

            migrationBuilder.CreateTable(
                name: "MaterialesDespachados",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cantidad = table.Column<decimal>(type: "TEXT", nullable: false),
                    SalidaId = table.Column<int>(type: "INTEGER", nullable: false),
                    MaterialId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialesDespachados", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MaterialesDespachados_Materiales_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materiales",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialesDespachados_SalidasAlmacen_SalidaId",
                        column: x => x.SalidaId,
                        principalTable: "SalidasAlmacen",
                        principalColumn: "SalidaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Almacenes",
                columns: new[] { "AlmacenId", "DenominacionCentro", "NombreCentro" },
                values: new object[] { 1, "Santiago - Edenorte", "N100" });

            migrationBuilder.InsertData(
                table: "Almacenes",
                columns: new[] { "AlmacenId", "DenominacionCentro", "NombreCentro" },
                values: new object[] { 2, "Samaná - Edenorte", "N200" });

            migrationBuilder.InsertData(
                table: "Almacenes",
                columns: new[] { "AlmacenId", "DenominacionCentro", "NombreCentro" },
                values: new object[] { 3, "San Francisco - Edenorte", "N300" });

            migrationBuilder.InsertData(
                table: "Almacenes",
                columns: new[] { "AlmacenId", "DenominacionCentro", "NombreCentro" },
                values: new object[] { 4, "Puerto Plata - Edenorte", "N400" });

            migrationBuilder.InsertData(
                table: "Almacenes",
                columns: new[] { "AlmacenId", "DenominacionCentro", "NombreCentro" },
                values: new object[] { 5, "Mao- Edenorte", "N500" });

            migrationBuilder.InsertData(
                table: "Almacenes",
                columns: new[] { "AlmacenId", "DenominacionCentro", "NombreCentro" },
                values: new object[] { 6, "La vega - Edenorte", "N600" });

            migrationBuilder.InsertData(
                table: "Almacenes",
                columns: new[] { "AlmacenId", "DenominacionCentro", "NombreCentro" },
                values: new object[] { 7, "Espaillat - Edenorte", "N700" });

            migrationBuilder.InsertData(
                table: "Almacenes",
                columns: new[] { "AlmacenId", "DenominacionCentro", "NombreCentro" },
                values: new object[] { 8, "Valverde - Edenorte", "N800" });

            migrationBuilder.CreateIndex(
                name: "IX_EntradasAlmacenes_AlmacenOrigenAlmacenId",
                table: "EntradasAlmacenes",
                column: "AlmacenOrigenAlmacenId");

            migrationBuilder.CreateIndex(
                name: "IX_EntradasAlmacenes_TransportistaId",
                table: "EntradasAlmacenes",
                column: "TransportistaId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialesDespachados_MaterialId",
                table: "MaterialesDespachados",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialesDespachados_SalidaId",
                table: "MaterialesDespachados",
                column: "SalidaId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialesRecibidos_EntradaId",
                table: "MaterialesRecibidos",
                column: "EntradaId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialesRecibidos_MaterialId",
                table: "MaterialesRecibidos",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_SalidasAlmacen_AlmacenDestinoAlmacenId",
                table: "SalidasAlmacen",
                column: "AlmacenDestinoAlmacenId");

            migrationBuilder.CreateIndex(
                name: "IX_SalidasAlmacen_TransportistaId",
                table: "SalidasAlmacen",
                column: "TransportistaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialesDespachados");

            migrationBuilder.DropTable(
                name: "MaterialesRecibidos");

            migrationBuilder.DropTable(
                name: "SalidasAlmacen");

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
