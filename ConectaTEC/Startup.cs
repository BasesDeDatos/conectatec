using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ConectaTEC.Startup))]
namespace ConectaTEC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
