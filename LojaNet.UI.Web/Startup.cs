using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;

[assembly: OwinStartup(typeof(LojaNet.UI.Web.Startup))]

namespace LojaNet.UI.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(
                new CookieAuthenticationOptions
                {
                    AuthenticationType=DefaultAuthenticationTypes.ApplicationCookie,
                    LoginPath = new PathString("/usuario/login")
                }
            );
        }
    }
}
