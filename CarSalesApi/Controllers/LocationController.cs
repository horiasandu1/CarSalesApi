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

        CarSalesDBEntities2 db = new CarSalesDBEntities2();

        [HttpGet]
        [Route("api/Location")]
        // GET ALL THE LOCATIONS - Ariane
        public HttpResponseMessage GetLocations()
        {
            HttpResponseMessage response;

            var locations = DBAccess.GetLocations();
            if (locations.Count == 0)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "No cars were found");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, locations);
            }

            return response;
            
        }

        [HttpGet]
        [Route("api/Location/{id}")]
        // GET SPECIFIC LOCATION WITH ID - Hicham
        public HttpResponseMessage GetLocation(int id)
        {
            HttpResponseMessage response;
            var location = DBAccess.GetLocation(id);

            if (location == null)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "No locations were found");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, location);
            }

            return response;
        }


        [HttpDelete]
        [Route("api/Location/{id}")]
        public HttpResponseMessage Delete(int id)
        {

            try
            {
                // Persist our change.
                DBAccess.DeleteLocation(id);

            }
            catch (Exception e)
            {
                // ERROR
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "An error occured, Cannot delete current record !");
            }

            // All OK
            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}