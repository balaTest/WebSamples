using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProductStore2.Startup))]
namespace ProductStore2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
