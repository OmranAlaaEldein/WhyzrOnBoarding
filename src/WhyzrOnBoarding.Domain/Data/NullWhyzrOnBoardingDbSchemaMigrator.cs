using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace WhyzrOnBoarding.Data
{
    /* This is used if database provider does't define
     * IWhyzrOnBoardingDbSchemaMigrator implementation.
     */
    public class NullWhyzrOnBoardingDbSchemaMigrator : IWhyzrOnBoardingDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}