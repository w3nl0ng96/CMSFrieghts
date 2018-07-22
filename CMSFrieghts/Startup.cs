using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CMSFrieghts.Startup))]
namespace CMSFrieghts
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
