using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SARSCOV2.Startup))]
namespace SARSCOV2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
