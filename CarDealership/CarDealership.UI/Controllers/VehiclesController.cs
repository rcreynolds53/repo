using CarDealership.Data;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CarDealership.UI.Controllers
{
    [EnableCors(origins: "*", methods: "*", headers: "*")]
    public class VehiclesController : ApiController
    {
        VehicleManager manager = VehicleManagerFactory.Create();

        [Route("vehicles")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllVehicles()
        {
           return Ok(manager.GetAllVehicles());

        }

        [Route("vehicle")]
        [AcceptVerbs("POST")]
        public IHttpActionResult AddVehicle(Vehicle newVehicle)
        {
            manager.AddVehicle(newVehicle);
            return Created($"vehicle/{newVehicle.Vin}", newVehicle);
        }

        [Route("makes")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetVehicleMake()
        {
            return Ok(manager.GetAllMakes());
        }

        [Route("models")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllModels()
        {
            return Ok(manager.GetModels());
        }

    }
}
