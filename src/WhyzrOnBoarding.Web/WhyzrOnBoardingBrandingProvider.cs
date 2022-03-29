using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace WhyzrOnBoarding.Web
{
    [Dependency(ReplaceServices = true)]
    public class WhyzrOnBoardingBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "WhyzrOnBoarding";
    }
}
