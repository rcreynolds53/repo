using CarDealership.Data;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    [Authorize(Roles = "admin")]
    public class ReportsController : Controller
    {
        VehicleManager manager = VehicleManagerFactory.Create();
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult InventoryReport()
        {
            return View(manager.GetInventoryReport());
        }
        [HttpGet]
        public ActionResult SalesReport()
        {
            SalesFilterModel salesVM = new SalesFilterModel();
            salesVM.SetUserItems(manager.GetAllUsers());
            return View(salesVM);
        }

        public JsonResult GenerateSalesReport(SalesFilterModel filters)
        {
            return Json(manager.SalesReport(filters));
        }
    }
}