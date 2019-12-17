using CarApiClasses;
using CarSalesApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace CarSalesApi.Controllers
{
    public class CarController : ApiController
    {

        CarSalesDBEntities2 db = new CarSalesDBEntities2();

        [HttpGet]
        [Route("api/Car")]
        // GET ALL THE CARS - Ariane
        public HttpResponseMessage GetCars()
        {
            HttpResponseMessage response;
            var cars = DBAccess.GetCars();
            if (cars.Count == 0)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "No cars were found");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, cars);
            }

            return response;
            
        }

        [HttpGet]
        [Route("api/Car/{id}")]
        // GET SPECIFIC CAR WITH ID - Hicham
        public HttpResponseMessage GetCar(int id)
        {
            HttpResponseMessage response;
            var car = DBAccess.GetCar(id);

            if (car == null){
                response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "No cars were found");
            }else{
                response = Request.CreateResponse(HttpStatusCode.OK, car);
            }

            return response;
        }
        [HttpDelete]
        [Route("api/Car/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                // Persist our change.
                DBAccess.DeleteCar(id);

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
        [Route("api/Car")]
        public HttpResponseMessage PostCar([FromBody]ApiCar ac)
        {
            try
            {
                DBAccess.PostCar(ac);
            }
            catch (Exception e)
            {
                // ERROR
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Cannot create record." + e.StackTrace);
            }

            // All OK
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPut]
        [Route("api/Car/{id}")]
        public HttpResponseMessage PutCar(int id, [FromBody]ApiCar ac)
        {
            try
            {
                // Persist our change.
                DBAccess.PutCar(id, ac);
            }
            catch (Exception e)
            {
                // ERROR
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Cannot update record: " + e);
            }

            // All OK
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}