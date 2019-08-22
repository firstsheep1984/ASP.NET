using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdmissionsOnlineSystem.Startup))]
namespace AdmissionsOnlineSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
