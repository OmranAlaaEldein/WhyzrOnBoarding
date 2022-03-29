using WhyzrOnBoarding.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace WhyzrOnBoarding.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class WhyzrOnBoardingPageModel : AbpPageModel
    {
        protected WhyzrOnBoardingPageModel()
        {
            LocalizationResourceType = typeof(WhyzrOnBoardingResource);
        }
    }
}