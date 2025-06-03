using EstruturaFesta.Clientes;
using Microsoft.EntityFrameworkCore;
namespace EstruturaFesta.DataBase
{
    public class EstruturaDataBase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;database=DataBaseEstrutura;user=root;password=Modoxclasher2004!",
                new MySqlServerVersion(new Version(8, 0, 40)));
        }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cliente> Contatos { get; set; }
        public DbSet<SaldoEstoqueData> SaldosPorData { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ProdutoPedido> ProdutosPedidos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cliente>()
        .HasMany(c => c.Contatos) // Um Cliente tem muitos Contatos
        .WithOne(c => c.Cliente) // Cada Contato tem um Cliente
        .HasForeignKey(c => c.ClienteID);
            modelBuilder.Entity<ClientePF>().HasBaseType<Cliente>();
            modelBuilder.Entity<ClientePJ>().HasBaseType<Cliente>();
           
            modelBuilder.Entity<Cliente>()
           .HasDiscriminator<string>("Discriminador")  // Nome da coluna discriminadora no banco de dados
           .HasValue<ClientePF>("ClientePF")  // ClientePF será associado a "ClientePF"
           .HasValue<ClientePJ>("ClientePJ");  // ClientePJ será associado a "ClientePJ"

            // Configura o nome como opcional para ClientePJ
            modelBuilder.Entity<ClientePJ>()
                .Property(c => c.Nome)
                .IsRequired(false);  // Nome não é obrigatório para ClientePJ

            modelBuilder.Entity<ProdutoPedido>()
    .HasKey(pp => new { pp.PedidoId, pp.ProdutoId });

            modelBuilder.Entity<ProdutoPedido>()
                .HasOne(pp => pp.Pedido)
                .WithMany(p => p.Produtos)
                .HasForeignKey(pp => pp.PedidoId);

            modelBuilder.Entity<ProdutoPedido>()
                .HasOne(pp => pp.Produto)
                .WithMany()
                .HasForeignKey(pp => pp.ProdutoId);

        }
    }
}

