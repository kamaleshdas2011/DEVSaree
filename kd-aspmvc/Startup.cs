using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(kd_aspmvc.Startup))]
namespace kd_aspmvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
