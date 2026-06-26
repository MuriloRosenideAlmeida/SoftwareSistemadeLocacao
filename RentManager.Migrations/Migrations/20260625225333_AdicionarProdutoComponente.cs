using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentManager.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarProdutoComponente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProdutosComponentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProdutoPaiId = table.Column<int>(type: "int", nullable: false),
                    ProdutoFilhoId = table.Column<int>(type: "int", nullable: false),
                    QuantidadePorUnidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutosComponentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdutosComponentes_Produtos_ProdutoFilhoId",
                        column: x => x.ProdutoFilhoId,
                        principalTable: "Produtos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProdutosComponentes_Produtos_ProdutoPaiId",
                        column: x => x.ProdutoPaiId,
                        principalTable: "Produtos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosComponentes_ProdutoFilhoId",
                table: "ProdutosComponentes",
                column: "ProdutoFilhoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosComponentes_ProdutoPaiId_ProdutoFilhoId",
                table: "ProdutosComponentes",
                columns: new[] { "ProdutoPaiId", "ProdutoFilhoId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutosComponentes");
        }
    }
}
