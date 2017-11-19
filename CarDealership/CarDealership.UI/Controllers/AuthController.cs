using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using CarDealership.Models;
using CarDealership.Data;
using System.Threading.Tasks;

namespace CarDealership.UI.Controllers
{
    public class AuthController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            LoginModel model = new LoginModel
            {
                ReturnUrl = returnUrl
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var ctx = Request.GetOwinContext();
            var authMgr = ctx.Authentication;
            var userMgr = HttpContext.GetOwinContext().GetUserManager<UserManager<User>>();
            var allusers = userMgr.Users.ToList();
            var hash = userMgr.HasPassword(allusers.First().Id);
            User user = userMgr.Find(model.Email, model.Password);

            if (user == null)
            {
                return Redirect(Url.Action("Login", "Auth"));
            }

            var userToLogin = userMgr.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            string rolename = userMgr.GetRoles(userToLogin.GetUserId()).FirstOrDefault();

            authMgr.SignIn(userToLogin);

            if (string.IsNullOrEmpty(model.ReturnUrl) || !Url.IsLocalUrl(model.ReturnUrl))
            {

                if ("admin" == rolename)
                {
                    return RedirectToAction("Vehicles", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Sales");
                }
            }
            return Redirect(model.ReturnUrl);
        }

        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var authmgr = ctx.Authentication;

            authmgr.SignOut("ApplicationCookie");

            return RedirectToAction("Login");
        }
        [Authorize(Roles = "admin, sales")]
        public ActionResult UpdatePassword()
        {
            return View();
        }
        [Authorize(Roles = "admin, sales")]
        [HttpPost]
        public async Task<ActionResult> UpdatePassword(UpdatePasswordViewModel model)
        {
            CarDealershipDbContext context = new CarDealershipDbContext();
            UserStore<User> store = new UserStore<User>(context);
            UserManager<User> userManager = new UserManager<User>(store);
            var userId = User.Identity.GetUserId();
            User identityUser = await store.FindByIdAsync(userId);

            if (!ModelState.IsValid)
            {
                return View("UpdatePassword");
            }
            else
            {
                if (userManager.CheckPassword(identityUser, model.OldPassword))
                {
                    var newPassword = model.ConfirmPassword;
                    string hashedNewPassword = userManager.PasswordHasher.HashPassword(newPassword);
                    await store.SetPasswordHashAsync(identityUser, hashedNewPassword);
                    await store.UpdateAsync(identityUser);

                    TempData["PasswordUpdate"] = "Password has been successfully updated!";
                    return RedirectToAction("UpdatePassword");
                }
                else
                {
                    TempData["PasswordUpdate"] = "Error: The old password entered does not match your current password.";
                    return RedirectToAction("UpdatePassword");
                }
            }
        }
    }
}