using CarSalesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarSalesApi.Controllers
{
    public class CarController : ApiController
    {
       

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
            var car = db.GetCar(id);

            return Request.CreateResponse(HttpStatusCode.OK, car);
        }

    }
}