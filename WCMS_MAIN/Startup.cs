using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WCMS_MAIN.Startup))]
namespace WCMS_MAIN
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
