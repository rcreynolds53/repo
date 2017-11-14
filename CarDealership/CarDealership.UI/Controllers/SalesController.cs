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
        [HttpGet]
        public ActionResult Makes()
        {
            var carMakes = manager.GetAllMakes();
            return View(carMakes);
        }

        [HttpGet]
        public ActionResult Models()
        {
            var carModels = manager.GetAllCarModels();
            return View(carModels);
        }

        [HttpGet]
        public ActionResult PurchaseVehicle(int id)
        {
            var vehicleToSell = manager.GetVehicle(id);
            return View(manager.ConvertVehicleToVM(vehicleToSell.VehicleId));
        }
    }
}