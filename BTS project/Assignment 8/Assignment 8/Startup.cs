using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Assignment_8.Startup))]
namespace Assignment_8
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
