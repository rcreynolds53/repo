﻿using CarDealership.Data;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    //[Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        VehicleManager manager = VehicleManagerFactory.Create();
        // GET: Vehicle
        public ActionResult Vehicles()
        {
            var model = manager.GetAllVehicles();
            return View(model);
        }

        [HttpGet]
        public ActionResult AddVehicle()
        {
            var vehicleVM = new VehicleViewModel();
            vehicleVM.SetCarMakeItems(manager.GetAllMakes());
            vehicleVM.SetCarModelItems(manager.GetAllCarModels());
            vehicleVM.SetVehicleTypeItems(manager.GetAllTypes());
            vehicleVM.SetBodyStyleItems(manager.GetAllStyles());
            vehicleVM.SetExColorItems(manager.GetAllExColors());
            vehicleVM.SetIntColorItems(manager.GetAllIntColors());
            vehicleVM.SetTransmissionItems(manager.GetAllTransmissions());

            return View(vehicleVM);
        }
        [HttpPost]
        public ActionResult AddVehicle(VehicleViewModel vehicleVM)
        {
            if (string.IsNullOrEmpty(vehicleVM.Vehicle.Vin))
            {
                ModelState.AddModelError("Vin", "Please enter a vin.");
            }
            if (ModelState.IsValid)
            {
                manager.ConvertVehicleVmToVehicle(vehicleVM);
                return RedirectToAction("Vehicles");
            }
            else
            {
                return View(vehicleVM);
            }
        }

        [HttpGet]
        public ActionResult EditVehicle(int id)
        {
            var viewModel = manager.ConvertVehicleToVM(id);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult EditVehicle(VehicleViewModel viewmodel)
        {
            manager.ConvertVehicleVmToVehicle(viewmodel);
            return RedirectToAction("Vehicles");
        }

        public ActionResult Users()
        {
            var model = manager.GetAllUsers();
            return View(model);
        }

        public ActionResult Specials()
        {
            var specials = manager.GetAllSpecials();
            return View(specials);
        }
        [HttpGet]
        public ActionResult AddSpecial()
        {
            return View();
        }

        public ActionResult AddSpecial(Promo special)
        {
            manager.AddSpecial(special);
            return View();
        }

        public JsonResult GetMakes()
        {
            return Json(manager.GetAllMakes().ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetModelsByMake(string makeId)
        {
            int id = Convert.ToInt32(makeId);
            var carModels = manager.GetModelsByMake(id);
            return Json(carModels);
        }

    }
}