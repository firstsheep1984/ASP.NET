using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcPartialViewResultDemo.Startup))]
namespace MvcPartialViewResultDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
