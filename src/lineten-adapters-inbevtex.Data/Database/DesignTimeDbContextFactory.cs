using LineTen.DataAccess.EntityFramework.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MySql.Data.MySqlClient;

namespace lineten_adapters_inbevtex.Data.Database
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            return new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseMySql(new MySqlConnectionStringBuilder()
                {
                    Server = "127.0.0.1",
                    Database = "lineten_adapters_inbevtex",
                    UserID = "root",
                    // ReSharper disable once StringLiteralTypo
                    Password = "rootpassword"
                }.ToString())
                .Options, new DateSaveChangesShim());
        }
    }
}
