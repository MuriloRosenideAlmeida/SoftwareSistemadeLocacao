using RentManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
namespace RentManager.Data;

public class RentManagerDataBase : DbContext
{
    public RentManagerDataBase(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql(
                "server=localhost;port=3306;database=rentmanagerdb;user=RentManager_user;password=Modoxclasher2004!",
                new MySqlServerVersion(new Version(9, 7, 0)),
                b => b.MigrationsAssembly("RentManager.Migrations"));
        }
    }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Contato> Contatos { get; set; }
    public DbSet<SaldoEstoqueData> SaldosPorData { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<ProdutoPedido> ProdutosPedidos { get; set; }
    public DbSet<PerdaProduto> PerdaProdutos { get; set; }
    public DbSet<Pagamento> Pagamentos { get; set; }
    public DbSet<SaldoPedido> SaldoPedidos { get; set; }
    public DbSet<ReciboGerado> ReciboGerados { get; set; }
    public DbSet<ProdutoComponente> ProdutosComponentes { get; set; }



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
        modelBuilder.Entity<Produto>()
   .Property(p => p.PrecoLocacao)
   .HasColumnType("decimal(10,2)");

        modelBuilder.Entity<Produto>()
            .Property(p => p.PrecoReposicao)
            .HasColumnType("decimal(10,2)");

        modelBuilder.Entity<Produto>()
            .Property(p => p.PrecoCompra)
            .HasColumnType("decimal(10,2)");

        modelBuilder.Entity<ProdutoComponente>()
    .HasOne(pc => pc.ProdutoPai)
    .WithMany()
    .HasForeignKey(pc => pc.ProdutoPaiId)
    .OnDelete(DeleteBehavior.Cascade); // deletar pai remove os vínculos

        modelBuilder.Entity<ProdutoComponente>()
            .HasOne(pc => pc.ProdutoFilho)
            .WithMany()
            .HasForeignKey(pc => pc.ProdutoFilhoId)
            .OnDelete(DeleteBehavior.Restrict); // protege o filho de ser deletado enquanto vinculado

        modelBuilder.Entity<ProdutoComponente>()
            .HasIndex(pc => new { pc.ProdutoPaiId, pc.ProdutoFilhoId })
            .IsUnique(); // impede cadastrar o mesmo componente duas vezes no mesmo pai
    }
  
}

