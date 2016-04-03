using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StimulSoftSample.Startup))]
namespace StimulSoftSample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
