using Owin;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(MetricsDrivenDevelopment.Frontend.Startup))]

namespace MetricsDrivenDevelopment.Frontend
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}
