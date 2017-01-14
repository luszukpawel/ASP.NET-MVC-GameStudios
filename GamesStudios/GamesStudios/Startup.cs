using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GamesStudios.Startup))]
namespace GamesStudios
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
