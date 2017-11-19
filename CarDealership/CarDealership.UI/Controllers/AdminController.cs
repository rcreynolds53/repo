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
    [Authorize(Roles ="admin")]
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

        [HttpGet]
        public ActionResult AddUser()
        {
            var userVM = new UserViewModel();
            userVM.SetRoleItems(manager.GetAllRoles());
            return View(userVM);
        }

        [HttpPost]
        public ActionResult AddUser(UserViewModel userVM)
        {
            manager.ConvertUserVMtoUserAdd(userVM);
            return RedirectToAction("Users");
        }

        [HttpGet]
        public ActionResult EditUser(string id)
        {
            var userToEdit = manager.GetUser(id);
            return View(manager.ConvertUserToVM(userToEdit));
            
        }

        [HttpPost]
        public ActionResult EditUser(UserViewModel userVM)
        {
            manager.ConvertUserVMtoUserEdit(userVM);
            return RedirectToAction("Users");
        }
        [HttpGet]
        public ActionResult DeleteUser(string id)
        {
            var user = manager.GetUser(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult DeleteUser(User user)
        {
            manager.DisableUser(user.Id);
            return RedirectToAction("Users");
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
        [HttpGet]
        public ActionResult Makes()
        {
            return View(manager.GetAllMakes());
        }

        [HttpGet]
        public ActionResult AddMake()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMake(CarMake newMake)
        {
            newMake.UserName = User.Identity.GetUserName(); 
            manager.AddCarMake(newMake);
            return RedirectToAction("Makes");
        }
        [HttpGet]
        public ActionResult Models()
        {
            return View(manager.GetAllCarModels());
        }

        [HttpGet]
        public ActionResult AddModel()
        {
            var carmodelVM = new CarModelViewModel();
            carmodelVM.SetCarMakeItems(manager.GetAllMakes());
            return View(carmodelVM);
        }

        [HttpPost]
        public ActionResult AddModel(CarModelViewModel newModel)
        {
            newModel.UserName = User.Identity.GetUserName();
            manager.ConvertCarModelVMtoCarModel(newModel);
            return RedirectToAction("Models");
        }

        //public JsonResult GetMakes()
        //{
        //    return Json(manager.GetAllMakes().ToList(), JsonRequestBehavior.AllowGet);
        //}

        public JsonResult GetModelsByMake(string makeId)
        {
            int id = Convert.ToInt32(makeId);
            var carModels = manager.GetModelsByMake(id);
            return Json(carModels);
        }

    }
}