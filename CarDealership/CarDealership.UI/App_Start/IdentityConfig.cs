using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarDealership.Data;

namespace CarDealership.UI.App_Start
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Home/Login"),
            });


            app.CreatePerOwinContext(() => new CarDealershipDbContext());
            app.CreatePerOwinContext<UserManager<IdentityUser>>((options, context) => new UserManager<IdentityUser>(new UserStore<IdentityUser>(context.Get<CarDealershipDbContext>())));
            app.CreatePerOwinContext(() => new CarDealershipDbContext());
            app.CreatePerOwinContext<RoleManager<IdentityRole>>((options, context) => new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context.Get<CarDealershipDbContext>())));
        }
    }
}