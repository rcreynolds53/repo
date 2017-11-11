using CarDealership.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    public class SalesController : Controller
    {
        VehicleManager manager = VehicleManagerFactory.Create();
        // GET: Sales
        public ActionResult Index()
        {
           var vehicles = manager.GetAllVehicles();
            return View(vehicles);
        }
    }
}