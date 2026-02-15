using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using EstruturaFesta.Data; 

namespace EstruturaFesta.Migrations
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EstruturaDataBase>
    {
        public EstruturaDataBase CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EstruturaDataBase>();

            var conn = "server=localhost;database=DataBaseEstrutura;user=root;password=Modoxclasher2004!;";

            optionsBuilder.UseMySql(conn, new MySqlServerVersion(new Version(8, 0, 34)), b => b.MigrationsAssembly("EstruturaFesta.Migrations")
 );

            return new EstruturaDataBase(optionsBuilder.Options);
        }
    }
}