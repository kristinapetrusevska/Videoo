using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Videoo.Startup))]
namespace Videoo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
