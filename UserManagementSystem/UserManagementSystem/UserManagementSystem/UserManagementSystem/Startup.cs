using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UserManagementSystem.Startup))]
namespace UserManagementSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
