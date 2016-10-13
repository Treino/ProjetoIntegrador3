using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PROJETO3.Startup))]
namespace PROJETO3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
