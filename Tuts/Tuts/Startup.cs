using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tuts.Startup))]
namespace Tuts
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
