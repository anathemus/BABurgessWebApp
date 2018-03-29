using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BABurgessWebApp.Startup))]
namespace BABurgessWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
