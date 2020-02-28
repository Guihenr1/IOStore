using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace NerdStore.Catalogo.Data
{
    public class ContextFactory : IDesignTimeDbContextFactory<CatalogoContext>
    {
        public CatalogoContext CreateDbContext()
        {
            return CreateDbContext(null);
        }
        
        public CatalogoContext CreateDbContext(string[] args)
        {
            var settingPath = Path.GetFullPath(Path.Combine(@"../NerdStore.WebApp.MVC/appsettings.json"));
            var builderConfiguration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(settingPath);
            var configuration = builderConfiguration.Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var builder = new DbContextOptionsBuilder<CatalogoContext>();
            builder.UseSqlServer(connectionString);

            return new CatalogoContext(builder.Options);
        }
    }

}