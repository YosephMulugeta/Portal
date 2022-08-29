using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PoralAARB.Startup))]
namespace PoralAARB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
