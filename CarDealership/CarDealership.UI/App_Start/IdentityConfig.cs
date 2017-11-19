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
using CarDealership.Models;

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
            app.CreatePerOwinContext<UserManager<User>>((options, context) => new UserManager<User>(new UserStore<User>(context.Get<CarDealershipDbContext>())));
            app.CreatePerOwinContext(() => new CarDealershipDbContext());
            app.CreatePerOwinContext<RoleManager<Role>>((options, context) => new RoleManager<Role>(new RoleStore<Role>(context.Get<CarDealershipDbContext>())));
        }
    }
}