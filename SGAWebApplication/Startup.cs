using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SGAWebApplication.Startup))]
namespace SGAWebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
