using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstruturaFesta.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "produtos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    PrecoLocacao = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Especificacao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Material = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Modelo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PrecoCompra = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PrecoReposicao = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DataCompra = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produtos", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Entrega = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Devolucao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    ProdutoID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reserva_produtos_ProdutoID",
                        column: x => x.ProdutoID,
                        principalTable: "produtos",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_ProdutoID",
                table: "Reserva",
                column: "ProdutoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "produtos");
        }
    }
}
