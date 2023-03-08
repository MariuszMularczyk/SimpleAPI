using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SimpleAPI
{
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        private static DbContextOptions<DatabaseContext> _options = null;
        public DatabaseContextFactory()
        {
            // A parameter-less constructor is required by the EF Core CLI tools.
            if (_options == null)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

                var builder = new DbContextOptionsBuilder<DatabaseContext>();
                var connectionString = configuration.GetConnectionString("DatabaseContext");
                builder.UseSqlServer(connectionString);

                //var builder = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "SimpleAPI");

                builder.UseLazyLoadingProxies();
                _options = builder.Options;
            }
        }

        public DatabaseContext CreateDbContext(string[] args)
        {
            return new DatabaseContext(_options);
        }

    }
}
