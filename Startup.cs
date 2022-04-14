using Microsoft.Owin;
using Owin;
using System;

[assembly: OwinStartupAttribute(typeof(OCCSolution.Startup))]
namespace OCCSolution
{
    public partial class Startup
    {
        
        public void Configuration(IAppBuilder app)
        {
         
            ConfigureAuth(app);
        }

        
    }
}
