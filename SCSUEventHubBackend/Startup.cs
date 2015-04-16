using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SCSUEventHubBackend.Startup))]
namespace SCSUEventHubBackend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
