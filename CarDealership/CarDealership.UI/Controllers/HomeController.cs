using CarDealership.Data;
using CarDealership.Data.EFRepos;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vereyon.Web;

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

        public ActionResult ContactUs()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [Route("Home/Contact/{id}")]
        public ActionResult Contact(int id)
        {
            var contactRequest = new ContactRequest();
            contactRequest.Vehicle = manager.GetVehicle(id);        
            return View(contactRequest);
        }

        [HttpPost]
        public ActionResult Contact(ContactRequest request)
        {
            manager.AddContactRequest(request);
            FlashMessage.Confirmation("Your request has been recieved! A sales rep will be with you shortly.");
            return RedirectToAction("Index");
        }
        public ActionResult Specials()
        {
            var specials = manager.GetAllSpecials();

            return View(specials);
        }

        //public ActionResult GetVehiclesFromUsedSearch(SearchViewModel viewmodel)
        //{
        //         var vehicles = manager.GetVehiclesFromUsedSearch(viewmodel);
        //    return View("VehicleResultsPartialView", vehicles);
            
        //}
        //public ActionResult Users()
        //{

        //    var model = new EFUserRepository().GetAllUsers();
        //    return View(model);
        //}
    }
}