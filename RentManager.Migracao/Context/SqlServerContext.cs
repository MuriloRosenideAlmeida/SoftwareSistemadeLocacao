using Microsoft.EntityFrameworkCore;
using RentManager.Migracao.EntidadesAntigas;
public class SqlServerContext : DbContext
{
    // ── Clientes ─────────────────────────────────────────────────
    public DbSet<ClienteAntigo> Clientes { get; set; }
    public DbSet<EnderecoAntigo> Enderecos { get; set; }
    public DbSet<MunicipioAntigo> Municipios { get; set; }
    public DbSet<EstadoAntigo> Estados { get; set; }
    public DbSet<TelefoneAntigo> COF_TELEFONES { get; set; }

    // ── Produtos ─────────────────────────────────────────────────
    public DbSet<ProdutoAntigo> Produtos { get; set; }
    public DbSet<MaterialAntigo> Materiais { get; set; }
    public DbSet<ModeloAntigo> Modelos { get; set; }
    public DbSet<EspecificacaoAntiga> Especificacoes { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(
            "Server=localhost\\SQLEXPRESS;Database=GSOFT;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // ── Clientes ─────────────────────────────────────────────
        modelBuilder.Entity<ClienteAntigo>()
            .ToTable("COF_CLIFOR", "dbo")
            .HasKey(e => e.CODCLIFOR);

        modelBuilder.Entity<EnderecoAntigo>()
            .ToTable("COF_ENDERECOS", "dbo")
            .HasKey(e => new { e.CODCLIFOR, e.IDENDER });

        modelBuilder.Entity<MunicipioAntigo>()
            .ToTable("GLB_MUNICIPIO", "dbo")
            .HasKey(m => m.CODMUNICIPIO);

        modelBuilder.Entity<EstadoAntigo>()
            .ToTable("GLB_ESTADO", "dbo")
            .HasKey(e => e.SIGLAESTADO);

        modelBuilder.Entity<TelefoneAntigo>()
            .ToTable("COF_TELEFONES", "dbo")
            .HasNoKey();

        // ── Produtos ─────────────────────────────────────────────
        modelBuilder.Entity<ProdutoAntigo>()
            .ToTable("PRD_PRODUTO", "dbo")
            .HasKey(p => p.IDPRODUTO);

        modelBuilder.Entity<MaterialAntigo>()
            .ToTable("PRD_MATERIAL", "dbo")
            .HasKey(m => m.IDMATERIAL);

        modelBuilder.Entity<ModeloAntigo>()
            .ToTable("PRD_MODELO", "dbo")
            .HasKey(m => m.IDMODELO);

        modelBuilder.Entity<EspecificacaoAntiga>()
            .ToTable("PRD_ESPECIFICACAO", "dbo")
            .HasKey(e => e.IDESPEC);

        base.OnModelCreating(modelBuilder);
    }

}
