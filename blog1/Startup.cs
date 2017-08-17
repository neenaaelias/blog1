using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(blog1.Startup))]
namespace blog1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
