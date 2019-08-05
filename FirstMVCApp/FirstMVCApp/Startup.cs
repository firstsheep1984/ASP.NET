using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FirstMVCApp.Startup))]
namespace FirstMVCApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
