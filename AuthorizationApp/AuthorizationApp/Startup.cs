using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AuthorizationApp.Startup))]
namespace AuthorizationApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
