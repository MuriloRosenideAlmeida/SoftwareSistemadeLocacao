using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstruturaFesta.Migrations
{
    /// <inheritdoc />
    public partial class CriarTabelaPedidoProdutoPedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataPedido = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pedidos_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProdutosPedidos",
                columns: table => new
                {
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    ValorUnitario = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutosPedidos", x => new { x.PedidoId, x.ProdutoId });
                    table.ForeignKey(
                        name: "FK_ProdutosPedidos_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdutosPedidos_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosPedidos_ProdutoId",
                table: "ProdutosPedidos",
                column: "ProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutosPedidos");

            migrationBuilder.DropTable(
                name: "Pedidos");
        }
    }
}
