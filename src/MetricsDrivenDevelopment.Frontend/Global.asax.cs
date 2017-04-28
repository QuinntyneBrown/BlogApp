using MetricsDrivenDevelopment.Frontend.Configuration;
using Microsoft.Practices.Unity;
using System.Net.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Unity.Mvc5;

namespace MetricsDrivenDevelopment.Frontend
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            //_client.DefaultRequestHeaders.Add("Tenant", _appConfiguration.TenantId)

            container.RegisterType<HttpClient>(
                new ContainerControlledLifetimeManager(),
                new InjectionFactory(x => {
                    var client = new HttpClient();
                    client.DefaultRequestHeaders.Add("Tenant", AppConfiguration.Config.TenantId);
                    return client;
                }));

            container.RegisterInstance(AppConfiguration.Config);

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            UnityConfig.RegisterComponents();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Article",                                              
                "Article/{slug}",                           
                new { controller = "Article", action = "GetBySlug" }
            );

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }
            );
        }
    }
}
