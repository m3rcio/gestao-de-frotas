using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(gestaodefrotas.Startup))]
namespace gestaodefrotas
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
