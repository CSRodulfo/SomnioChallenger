using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Presentation.MVC.Startup))]

namespace Presentation.MVC
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
