using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace WhyzrOnBoarding.Pages
{
    public class Index_Tests : WhyzrOnBoardingWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}
