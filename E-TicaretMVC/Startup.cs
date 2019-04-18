using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(E_TicaretMVC.Startup))]
namespace E_TicaretMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
