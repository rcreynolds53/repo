using CarDealership.Data;
using CarDealership.Data.EFRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    public class HomeController : Controller
    {
        VehicleManager manager = VehicleManagerFactory.Create();
        public ActionResult Index()
        {
            var model = manager.GetFeaturedVehicles();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Specials()
        {
            var specials = manager.GetAllSpecials();

            return View(specials);
        }

        //public ActionResult Users()
        //{

        //    var model = new EFUserRepository().GetAllUsers();
        //    return View(model);
        //}
    }
}