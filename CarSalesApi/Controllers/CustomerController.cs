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
    public class CustomerController : ApiController
    {

        CarSalesDBEntities2 db = new CarSalesDBEntities2();

        [HttpGet]
        [Route("CustomerController/Customer")]
        //GET ALL THE CUSTOMER - Ariane
        public HttpResponseMessage GetCustomers()
        {
            HttpResponseMessage response;
            var customers = DBAccess.GetCustomers();
            if (customers.Count == 0)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "No cars were found");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, customers);
            }

            return response;
        }

        [HttpGet]
        [Route("CustomerController/Customer/id")]
        // GET SPECIFIC CUSTOMER WITH ID - Hicham
        public HttpResponseMessage GetCustomer(int id)
        {
            HttpResponseMessage response;
            var customer = DBAccess.GetCustomer(id);

            if (customer == null)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "No customers were found");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, customer);
            }

            return response;
        }

        public HttpResponseMessage Delete(int id)
        {
            Customer c = db.Customers.Find(id);

            if (c == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Found");
            }

            db.Customers.Remove(c);

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
        [Route("api/Customer")]
        public HttpResponseMessage PostCustomer([FromBody]ApiCustomer ac)
        {
            try
            {
                DBAccess.PostCustomer(ac);
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