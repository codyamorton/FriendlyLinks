using FriendlyLinks.App_Start;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FriendlyLinks
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            WebApiConfig.Register();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}