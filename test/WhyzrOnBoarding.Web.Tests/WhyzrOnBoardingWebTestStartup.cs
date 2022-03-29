using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace WhyzrOnBoarding
{
    public class WhyzrOnBoardingWebTestStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<WhyzrOnBoardingWebTestModule>();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.InitializeApplication();
        }
    }
}