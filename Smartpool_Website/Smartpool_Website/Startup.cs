using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Smartpool_Website.Startup))]
namespace Smartpool_Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
