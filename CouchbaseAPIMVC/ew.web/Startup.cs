using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ew.web.Startup))]
namespace ew.web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
