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
                name: "EntradasAlmacenes",
                columns: table => new
                {
                    EntradaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FechaEntrada = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TransportistaId = table.Column<int>(type: "INTEGER", nullable: false),
                    AlmacenId = table.Column<int>(type: "INTEGER", nullable: false),
                    PrecioTotal = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntradasAlmacenes", x => x.EntradaId);
                });

            migrationBuilder.CreateTable(
                name: "Materiales",
                columns: table => new
                {
                    MaterialId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
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
                name: "MaterialesRecibidos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cantidad = table.Column<decimal>(type: "TEXT", nullable: false),
                    EntradasAlmacenEntradaId = table.Column<int>(type: "INTEGER", nullable: false),
                    MaterialId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialesRecibidos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MaterialesRecibidos_EntradasAlmacenes_EntradasAlmacenEntradaId",
                        column: x => x.EntradasAlmacenEntradaId,
                        principalTable: "EntradasAlmacenes",
                        principalColumn: "EntradaId",
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

            migrationBuilder.InsertData(
                table: "Materiales",
                columns: new[] { "MaterialId", "Cantidad", "Costo", "Descripcion", "FechaRegistro", "UnidadesMedida", "ValorInventario" },
                values: new object[] { 1, 0m, 200.00m, "Poste Hormigón", new DateTime(2022, 6, 21, 0, 0, 0, 0, DateTimeKind.Local), "Unidad", 0.00m });

            migrationBuilder.InsertData(
                table: "Materiales",
                columns: new[] { "MaterialId", "Cantidad", "Costo", "Descripcion", "FechaRegistro", "UnidadesMedida", "ValorInventario" },
                values: new object[] { 2, 2m, 300.00m, "Cable Cobre", new DateTime(2022, 6, 21, 0, 0, 0, 0, DateTimeKind.Local), "Metros", 600.00m });

            migrationBuilder.InsertData(
                table: "Materiales",
                columns: new[] { "MaterialId", "Cantidad", "Costo", "Descripcion", "FechaRegistro", "UnidadesMedida", "ValorInventario" },
                values: new object[] { 3, 0m, 30.00m, "Tornillo", new DateTime(2022, 6, 21, 0, 0, 0, 0, DateTimeKind.Local), "Unidad", 0.00m });

            migrationBuilder.InsertData(
                table: "Transportistas",
                columns: new[] { "TransportistaId", "Apellidos", "FechaRegistro", "Nombres", "NumeroCarnet" },
                values: new object[] { 1, "Perez", new DateTime(2022, 6, 21, 0, 0, 0, 0, DateTimeKind.Local), "Juan Steven", 1000 });

            migrationBuilder.InsertData(
                table: "Transportistas",
                columns: new[] { "TransportistaId", "Apellidos", "FechaRegistro", "Nombres", "NumeroCarnet" },
                values: new object[] { 2, "Duran", new DateTime(2022, 6, 21, 0, 0, 0, 0, DateTimeKind.Local), "Samuel", 1001 });

            migrationBuilder.InsertData(
                table: "Transportistas",
                columns: new[] { "TransportistaId", "Apellidos", "FechaRegistro", "Nombres", "NumeroCarnet" },
                values: new object[] { 3, "Perez", new DateTime(2022, 6, 21, 0, 0, 0, 0, DateTimeKind.Local), "Juan", 1002 });

            migrationBuilder.CreateIndex(
                name: "IX_MaterialesDespachados_MaterialId",
                table: "MaterialesDespachados",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialesDespachados_SalidaId",
                table: "MaterialesDespachados",
                column: "SalidaId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialesRecibidos_EntradasAlmacenEntradaId",
                table: "MaterialesRecibidos",
                column: "EntradasAlmacenEntradaId");

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
                name: "Materiales");

            migrationBuilder.DropTable(
                name: "SalidasAlmacen");

            migrationBuilder.DropTable(
                name: "EntradasAlmacenes");

            migrationBuilder.DropTable(
                name: "Almacenes");

            migrationBuilder.DropTable(
                name: "Transportistas");
        }
    }
}
