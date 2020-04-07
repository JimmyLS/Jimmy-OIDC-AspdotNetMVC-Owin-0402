using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;


[assembly: OwinStartup(typeof(jimmy_oidc_test_0402.Startup))]

namespace jimmy_oidc_test_0402
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            ConfigureAuth(app);
        }
    }
}
