using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SelfieLottery.Startup))]
namespace SelfieLottery
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            ConfigureAuth(app);
        }
    }
}
