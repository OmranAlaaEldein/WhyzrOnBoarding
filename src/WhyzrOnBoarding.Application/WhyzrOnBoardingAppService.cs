using System;
using System.Collections.Generic;
using System.Text;
using WhyzrOnBoarding.Localization;
using Volo.Abp.Application.Services;

namespace WhyzrOnBoarding
{
    /* Inherit your application services from this class.
     */
    public abstract class WhyzrOnBoardingAppService : ApplicationService
    {
        protected WhyzrOnBoardingAppService()
        {
            LocalizationResource = typeof(WhyzrOnBoardingResource);
        }
    }
}
