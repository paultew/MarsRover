using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MarsRover.Web.Startup))]
namespace MarsRover.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
