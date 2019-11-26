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
        DBAccess db = new DBAccess();


        // GET api/<controller>
        public HttpResponseMessage GetAllCars()
        {
            var cars = db.GetAllCars();
            return Request.CreateResponse(HttpStatusCode.OK, cars);
        }

        public HttpResponseMessage GetAllLocations()
        {
            var locations = db.GetAllLocations();
            return Request.CreateResponse(HttpStatusCode.OK, locations);
        }

        public HttpResponseMessage GetAllSalespersons()
        {
            var salepersons = db.GetAllSalespersons();
            return Request.CreateResponse(HttpStatusCode.OK, salespersons);
        }

        public HttpResponseMessage GetAllSales()
        {
            var sales = db.GetAllSales();
            return Request.CreateResponse(HttpStatusCode.OK, sales);
        }

        public HttpResponseMessage GetAllCustomers()
        {
            var customers = db.GetAllCustomers();
            return Request.CreateResponse(HttpStatusCode.OK, customers);
        }

        public HttpResponseMessage GetAllCustomerPhones()
        {
            var customerPhones = db.GetAllCustomerPhones();
            return Request.CreateResponse(HttpStatusCode.OK, customerPhones);
        }

        public HttpResponseMessage GetAllPhones()
        {
            var phones = db.GetAllPhones();
            return Request.CreateResponse(HttpStatusCode.OK, phones);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {





        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}