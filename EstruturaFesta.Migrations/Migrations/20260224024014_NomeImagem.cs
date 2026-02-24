using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstruturaFesta.Migrations
{
    /// <inheritdoc />
    public partial class NomeImagem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeImagem",
                table: "Produtos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeImagem",
                table: "Produtos");
        }
    }
}
