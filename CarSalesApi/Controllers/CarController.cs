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
        [Route("CarController/Car")]
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
        [Route("CarController/Car/id")]
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

        public HttpResponseMessage Delete(int id)
        {
            Car c = db.Cars.Find(id);

            if (c == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Found");
            }

            db.Cars.Remove(c);
            
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
    }
}