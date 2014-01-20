using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodeForGood.WebUI.Startup))]
namespace CodeForGood.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
