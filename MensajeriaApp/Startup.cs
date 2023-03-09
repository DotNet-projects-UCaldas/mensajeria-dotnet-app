using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MensajeriaApp.Startup))]
namespace MensajeriaApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
