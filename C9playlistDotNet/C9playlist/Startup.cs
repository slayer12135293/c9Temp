using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(C9playlist.Startup))]
namespace C9playlist
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
