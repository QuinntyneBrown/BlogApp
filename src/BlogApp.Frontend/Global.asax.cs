using BlogApp.Frontend.Configuration;
using Microsoft.Practices.Unity;
using System.Net.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Unity.Mvc5;

namespace BlogApp.Frontend
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

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
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = "" }
            );
        }
    }
}
