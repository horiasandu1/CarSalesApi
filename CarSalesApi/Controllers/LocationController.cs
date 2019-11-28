using CarSalesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarSalesApi.Controllers
{
    public class LocationController : ApiController
    {
        DBAccess db = new DBAccess();

        [HttpGet]
        [Route("LocationController/Location")]
        // GET ALL THE LOCATIONS - Ariane
        public HttpResponseMessage GetLocations()
        {
            var locations = db.GetLocations();
            return Request.CreateResponse(HttpStatusCode.OK, locations);
        }

        [HttpGet]
        [Route("LocationController/Location/id")]
        // GET SPECIFIC LOCATION WITH ID - Hicham
        public HttpResponseMessage GetLocation(int id)
        {
            var location = db.GetLocation(id);

            return Request.CreateResponse(HttpStatusCode.OK, location);
        }
    }
}