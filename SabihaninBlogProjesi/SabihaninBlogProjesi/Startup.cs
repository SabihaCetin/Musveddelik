using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SabihaninBlogProjesi.Startup))]
namespace SabihaninBlogProjesi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
