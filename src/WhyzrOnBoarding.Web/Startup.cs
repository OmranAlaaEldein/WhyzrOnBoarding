using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace WhyzrOnBoarding.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<WhyzrOnBoardingWebModule>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.InitializeApplication();
        }
    }
}
