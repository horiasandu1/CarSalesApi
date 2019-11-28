using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarSalesApi.Controllers
{
    public class LocationController
    {
        DBAccess db = new DBAccess();

        [HttpGet]
        [Route("LocationController/Location")]
        // GET ALL THE LOCATIONS - Ariane
        public HttpResponseMessage GetAllLocation()
        {
            var locations = db.GetAllLocation();
            return Request.CreateResponse(HttpStatusCode.OK, locations);
        }

        [HttpGet]
        [Route("LocationController/Location/id")]
        // GET SPECIFIC LOCATION WITH ID - Hicham
        public HttpResponseMessage GetLocationId(int id)
        {
            var location = db.GetLocationId(id);

            return Request.CreateResponse(HttpStatusCode.OK, location);
        }
    }
}