using WhyzrOnBoarding.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace WhyzrOnBoarding.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class WhyzrOnBoardingController : AbpController
    {
        protected WhyzrOnBoardingController()
        {
            LocalizationResource = typeof(WhyzrOnBoardingResource);
        }
    }
}