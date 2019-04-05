using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hirent.Startup))]
namespace Hirent
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
