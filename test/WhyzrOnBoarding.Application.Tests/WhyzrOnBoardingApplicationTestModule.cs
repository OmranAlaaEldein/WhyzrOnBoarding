using Volo.Abp.Modularity;

namespace WhyzrOnBoarding
{
    [DependsOn(
        typeof(WhyzrOnBoardingApplicationModule),
        typeof(WhyzrOnBoardingDomainTestModule)
        )]
    public class WhyzrOnBoardingApplicationTestModule : AbpModule
    {

    }
}