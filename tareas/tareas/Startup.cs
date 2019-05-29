using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(tareas.Startup))]
namespace tareas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
