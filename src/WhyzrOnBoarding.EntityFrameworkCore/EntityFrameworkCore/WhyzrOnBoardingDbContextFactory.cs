using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace WhyzrOnBoarding.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class WhyzrOnBoardingDbContextFactory : IDesignTimeDbContextFactory<WhyzrOnBoardingDbContext>
    {
        public WhyzrOnBoardingDbContext CreateDbContext(string[] args)
        {
            WhyzrOnBoardingEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<WhyzrOnBoardingDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new WhyzrOnBoardingDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../WhyzrOnBoarding.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
