using System.Net.Http.Headers;
using System.Web.Http;

namespace FriendlyLinks.App_Start
{
    public class WebApiConfig
    {
        public static void Register()
        {
            GlobalConfiguration
                .Configure(
                X =>
                {
                    X
                    .Formatters
                    .JsonFormatter
                    .SupportedMediaTypes
                    .Add(new MediaTypeHeaderValue("text/html"));

                    X.MapHttpAttributeRoutes();
                }
                );
        }
    }
}