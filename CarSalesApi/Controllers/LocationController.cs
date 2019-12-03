using CarApiClasses;
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
        [Route("LocationController/Location")]
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
        [Route("LocationController/Location/id")]
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

        public HttpResponseMessage Delete(int id)
        {
            Location c = db.Locations.Find(id);

            if (c == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Found");
            }

            db.Locations.Remove(c);

            try
            {
                // Persist our change.
                db.SaveChanges();
            }
            catch (Exception e)
            {
                // ERROR
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "An error occured, Cannot delete current record !");
            }

            // All OK
            return Request.CreateResponse(HttpStatusCode.OK);
        }


        [HttpPost]
        [Route("api/Location")]
        public HttpResponseMessage PostLocation([FromBody]ApiLocation lo)
        {
            try
            {
                DBAccess.PostLocation(lo);
            }
            catch (Exception e)
            {
                // ERROR
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Cannot create record.");
            }

            // All OK
            return Request.CreateResponse(HttpStatusCode.OK);
        }


    }
}