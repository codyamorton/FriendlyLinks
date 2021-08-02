using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FriendlyLinks.Startup))]

namespace FriendlyLinks
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}