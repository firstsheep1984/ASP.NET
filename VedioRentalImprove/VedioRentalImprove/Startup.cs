using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VedioRentalImprove.Startup))]
namespace VedioRentalImprove
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
