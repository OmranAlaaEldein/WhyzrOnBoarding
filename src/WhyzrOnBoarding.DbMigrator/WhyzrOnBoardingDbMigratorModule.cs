using WhyzrOnBoarding.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace WhyzrOnBoarding.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(WhyzrOnBoardingEntityFrameworkCoreModule),
        typeof(WhyzrOnBoardingApplicationContractsModule)
        )]
    public class WhyzrOnBoardingDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
