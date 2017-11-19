using CarDealership.Data;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;


namespace CarDealership.UI.Controllers
{
    [Authorize(Roles = "admin, sales")]
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
            return View(manager.ConvertVehicleToPurchase(vehicleToSell.VehicleId));
        }
        [HttpPost]
        public ActionResult PurchaseVehicle(InvoiceViewModel invoiceVM)
        {
            invoiceVM.Vehicle = manager.GetVehicle(invoiceVM.Vehicle.VehicleId);
            invoiceVM.UserName = User.Identity.GetUserName();
            manager.ConvertPurchaseToInvoice(invoiceVM);
            return RedirectToAction("Index");
        }
    }
}