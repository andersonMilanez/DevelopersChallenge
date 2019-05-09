using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(challenge.Startup))]
namespace challenge
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
