using Microsoft.EntityFrameworkCore;
using EstruturaFesta.Migracao.EntidadesAntigas;
public class SqlServerContext : DbContext
{
    public DbSet<ClienteAntigo> Clientes { get; set; }
    public DbSet<EnderecoAntigo> Enderecos { get; set; }
    public DbSet<MunicipioAntigo> Municipios { get; set; }
    public DbSet<EstadoAntigo> Estados { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(
            "Server=localhost\\SQLEXPRESS;Database=GSOFT;Trusted_Connection=True;TrustServerCertificate=True;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClienteAntigo>(entity =>
        {
            entity.ToTable("COF_CLIFOR", "dbo");

            entity.HasKey(e => e.CODCLIFOR);

            entity.Property(e => e.CODCLIFOR)
                  .HasColumnName("CODCLIFOR");

            modelBuilder.Entity<EnderecoAntigo>(entity =>
            {
                entity.ToTable("COF_ENDERECOS", "dbo");

                entity.HasKey(e => new { e.CODCLIFOR, e.IDENDER });
            });
            modelBuilder.Entity<MunicipioAntigo>()
             .ToTable("GLB_MUNICIPIO", "dbo")
             .HasKey(m => m.CODMUNICIPIO);

            modelBuilder.Entity<EstadoAntigo>()
                .ToTable("GLB_ESTADO", "dbo")
                .HasKey(e => e.SIGLAESTADO);

        });
    }

}
