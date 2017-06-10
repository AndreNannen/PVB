using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Delta_Impuls.Startup))]
namespace Delta_Impuls
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
