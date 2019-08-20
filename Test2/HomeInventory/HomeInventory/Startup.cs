using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HomeInventory.Startup))]
namespace HomeInventory
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
