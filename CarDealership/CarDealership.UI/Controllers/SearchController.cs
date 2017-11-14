using CarDealership.Data;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarDealership.UI.Controllers
{
    
    public class SearchController : ApiController
    {
        VehicleManager manager = VehicleManagerFactory.Create();

        [Route("search/usedresults")]
        [AcceptVerbs("POST")]
        public IHttpActionResult GetVehiclesFromUsedSearch(SearchViewModel viewmodel)
        {
            return Ok(manager.GetVehiclesFromUsedSearch(viewmodel));
        }

        [Route("search/allresults")]
        [AcceptVerbs("POST")]
        public IHttpActionResult GetAllVehiclesFromSearch(SearchViewModel viewmodel)
        {
            return Ok(manager.GetAllVehiclesFromSearch(viewmodel));
        }

        [Route("search/forsaleresults")]
        [AcceptVerbs("POST")]
        public IHttpActionResult GetForSaleVehiclesSearch(SearchViewModel viewmodel)
        {
            return Ok(manager.GetAllVehiclesForSaleSearch(viewmodel));
        }


        [Route("search/newresults")]
        [AcceptVerbs("POST")]
        public IHttpActionResult GetVehiclesFromNewSearch(SearchViewModel viewmodel)
        {
            return Ok(manager.GetVehiclesFromNewSearch(viewmodel));
        }
    }
}
