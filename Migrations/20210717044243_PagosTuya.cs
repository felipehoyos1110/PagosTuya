using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace PagosTuya.Migrations
{
    public partial class PagosTuya : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PEDIDO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TipoIdentificacion = table.Column<string>(maxLength: 2, nullable: false),
                    Identificacion = table.Column<string>(maxLength: 15, nullable: false),
                    Nombres = table.Column<string>(maxLength: 200, nullable: false),
                    Email = table.Column<string>(maxLength: 60, nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PEDIDO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 200, nullable: false),
                    ValorUnidad = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FACTURA",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TipoIdentificacion = table.Column<string>(maxLength: 2, nullable: false),
                    Identificacion = table.Column<string>(maxLength: 15, nullable: false),
                    Nombres = table.Column<string>(maxLength: 200, nullable: false),
                    Email = table.Column<string>(maxLength: 60, nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()"),
                    PedidoId = table.Column<int>(nullable: false),
                    Total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FACTURA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FACTURA_PEDIDO_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "PEDIDO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DETALLE_PEDIDO",
                columns: table => new
                {
                    DetallePedidoId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PedidoId = table.Column<int>(nullable: false),
                    ProductoId = table.Column<int>(nullable: false),
                    Item = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DETALLE_PEDIDO", x => x.DetallePedidoId);
                    table.ForeignKey(
                        name: "FK_DETALLE_PEDIDO_PEDIDO_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "PEDIDO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DETALLE_PEDIDO_PRODUCTO_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "PRODUCTO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DETALLE_FACTURA",
                columns: table => new
                {
                    DetalleFacturaId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FacturaId = table.Column<int>(nullable: false),
                    ProductoId = table.Column<int>(nullable: false),
                    Item = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    ValorUnidad = table.Column<double>(nullable: false),
                    ValorTotal = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DETALLE_FACTURA", x => x.DetalleFacturaId);
                    table.ForeignKey(
                        name: "FK_DETALLE_FACTURA_FACTURA_FacturaId",
                        column: x => x.FacturaId,
                        principalTable: "FACTURA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DETALLE_FACTURA_PRODUCTO_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "PRODUCTO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PAGO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TipoIdentificacion = table.Column<string>(maxLength: 2, nullable: false),
                    Identificacion = table.Column<string>(maxLength: 15, nullable: false),
                    Nombres = table.Column<string>(maxLength: 200, nullable: false),
                    Email = table.Column<string>(maxLength: 60, nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()"),
                    FacturaId = table.Column<int>(nullable: false),
                    Total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAGO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PAGO_FACTURA_FacturaId",
                        column: x => x.FacturaId,
                        principalTable: "FACTURA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DETALLE_FACTURA_FacturaId",
                table: "DETALLE_FACTURA",
                column: "FacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_DETALLE_FACTURA_ProductoId",
                table: "DETALLE_FACTURA",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_DETALLE_PEDIDO_PedidoId",
                table: "DETALLE_PEDIDO",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_DETALLE_PEDIDO_ProductoId",
                table: "DETALLE_PEDIDO",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_FACTURA_PedidoId",
                table: "FACTURA",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_PAGO_FacturaId",
                table: "PAGO",
                column: "FacturaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DETALLE_FACTURA");

            migrationBuilder.DropTable(
                name: "DETALLE_PEDIDO");

            migrationBuilder.DropTable(
                name: "PAGO");

            migrationBuilder.DropTable(
                name: "PRODUCTO");

            migrationBuilder.DropTable(
                name: "FACTURA");

            migrationBuilder.DropTable(
                name: "PEDIDO");
        }
    }
}
