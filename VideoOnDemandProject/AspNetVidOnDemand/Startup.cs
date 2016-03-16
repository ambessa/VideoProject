using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AspNetVidOnDemand.Startup))]
namespace AspNetVidOnDemand
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
