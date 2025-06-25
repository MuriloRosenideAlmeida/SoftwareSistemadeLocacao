using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstruturaFesta.Migrations
{
    /// <inheritdoc />
    public partial class AddContactToCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_clientes",
                table: "clientes");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "clientes");

            migrationBuilder.RenameTable(
                name: "clientes",
                newName: "Clientes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Contato",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Telefone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NomeContato = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClienteID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contato", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Contato_Clientes_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Clientes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Contato_ClienteID",
                table: "Contato",
                column: "ClienteID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contato");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.RenameTable(
                name: "Clientes",
                newName: "clientes");

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "clientes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_clientes",
                table: "clientes",
                column: "ID");
        }
    }
}
