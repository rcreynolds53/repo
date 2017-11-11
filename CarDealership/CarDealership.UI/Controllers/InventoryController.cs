using CarDealership.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    public class InventoryController : Controller
    {
        VehicleManager manager = VehicleManagerFactory.Create();
        // GET: Inventory
        [Route("Inventory/VehicleDetails/{id}")]
        public ActionResult VehicleDetails(int id)
        {
            var vehicle = manager.GetVehicle(id);
            return View(vehicle);
        }

        public ActionResult NewVehicles()
        {
            var vehicles = manager.GetAllNewVehicles();
            return View(vehicles);
        }

        public ActionResult UsedVehicles()
        {
            var vehicles = manager.GetAllUsedVehicles();
            return View(vehicles);
        }
    }
}