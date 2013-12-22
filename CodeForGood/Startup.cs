using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodeForGood.Startup))]
namespace CodeForGood
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
