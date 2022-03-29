using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WhyzrOnBoarding.Data;
using Volo.Abp.DependencyInjection;

namespace WhyzrOnBoarding.EntityFrameworkCore
{
    public class EntityFrameworkCoreWhyzrOnBoardingDbSchemaMigrator
        : IWhyzrOnBoardingDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreWhyzrOnBoardingDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the WhyzrOnBoardingDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<WhyzrOnBoardingDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
