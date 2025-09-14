using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstruturaFesta.Migrations
{
    /// <inheritdoc />
    public partial class RelacaoPerdaProdutoComPedidoCorrigida : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Verifica se o índice já existe e só adiciona a FK
            migrationBuilder.Sql(@"
                SET @idx := (SELECT COUNT(*) 
                             FROM INFORMATION_SCHEMA.STATISTICS 
                             WHERE table_schema = DATABASE() 
                               AND table_name = 'PerdaProdutos' 
                               AND index_name = 'IX_PerdaProdutos_PedidoId');
                SET @sql := IF(@idx = 0, 
                               'CREATE INDEX IX_PerdaProdutos_PedidoId ON PerdaProdutos(PedidoId);', 
                               'SELECT 1;');
                PREPARE stmt FROM @sql;
                EXECUTE stmt;
                DEALLOCATE PREPARE stmt;
            ");

            // Adiciona a foreign key apenas se não existir
            migrationBuilder.Sql(@"
                SET @fk := (SELECT COUNT(*) 
                            FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS 
                            WHERE table_schema = DATABASE() 
                              AND table_name = 'PerdaProdutos' 
                              AND constraint_name = 'FK_PerdaProdutos_Pedidos_PedidoId');
                SET @sql := IF(@fk = 0, 
                               'ALTER TABLE PerdaProdutos ADD CONSTRAINT FK_PerdaProdutos_Pedidos_PedidoId FOREIGN KEY (PedidoId) REFERENCES Pedidos(ID) ON DELETE CASCADE;', 
                               'SELECT 1;');
                PREPARE stmt FROM @sql;
                EXECUTE stmt;
                DEALLOCATE PREPARE stmt;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove a foreign key apenas se existir
            migrationBuilder.Sql(@"
                SET @fk := (SELECT COUNT(*) 
                            FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS 
                            WHERE table_schema = DATABASE() 
                              AND table_name = 'PerdaProdutos' 
                              AND constraint_name = 'FK_PerdaProdutos_Pedidos_PedidoId');
                SET @sql := IF(@fk = 1, 
                               'ALTER TABLE PerdaProdutos DROP FOREIGN KEY FK_PerdaProdutos_Pedidos_PedidoId;', 
                               'SELECT 1;');
                PREPARE stmt FROM @sql;
                EXECUTE stmt;
                DEALLOCATE PREPARE stmt;
            ");

            // Remove o índice apenas se existir
            migrationBuilder.Sql(@"
                SET @idx := (SELECT COUNT(*) 
                             FROM INFORMATION_SCHEMA.STATISTICS 
                             WHERE table_schema = DATABASE() 
                               AND table_name = 'PerdaProdutos' 
                               AND index_name = 'IX_PerdaProdutos_PedidoId');
                SET @sql := IF(@idx = 1, 
                               'DROP INDEX IX_PerdaProdutos_PedidoId ON PerdaProdutos;', 
                               'SELECT 1;');
                PREPARE stmt FROM @sql;
                EXECUTE stmt;
                DEALLOCATE PREPARE stmt;
            ");
        }
    }
}
