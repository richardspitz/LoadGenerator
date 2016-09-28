using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LoadGenerator.Startup))]
namespace LoadGenerator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
