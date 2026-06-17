using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using RentManager.Data; 

namespace RentManager.Migrations
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<RentManagerDataBase>
    {
        public RentManagerDataBase CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RentManagerDataBase>();
            optionsBuilder.UseMySql(
                "server=localhost;port=3306;database=rentmanagerdb;user=RentManager_user;password=Modoxclasher2004!",
                new MySqlServerVersion(new Version(9, 7, 0)),
                b => b.MigrationsAssembly("RentManager.Migrations"));
            return new RentManagerDataBase(optionsBuilder.Options);
        }
    }
}