using WhyzrOnBoarding.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace WhyzrOnBoarding
{
    [DependsOn(
        typeof(WhyzrOnBoardingEntityFrameworkCoreTestModule)
        )]
    public class WhyzrOnBoardingDomainTestModule : AbpModule
    {

    }
}